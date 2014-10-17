using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using RadDiagramSample.Models;

namespace RadDiagramSample.Views
{
    /// <summary>
    /// Interaction logic for ContextBar.xaml
    /// </summary>
    public partial class ContextBar : UserControl
    {
        #region [Public Properties]

        public delegate void ItemClickedEventHandler(object sender, ItemClickedEventArgs e);

        public event ItemClickedEventHandler ItemClicked;
        
        public string ItemDisplayPath
        {
            get { return _itemDisplayPath; }
            set
            {
                _itemDisplayPath = value;
            }
        }

        #endregion

        #region [Private Fields]

        private Stack<object> _items;
        private string _itemDisplayPath;

        #endregion

        #region [Constructors]

        public ContextBar()
        {
            InitializeComponent();
            _items = new Stack<object>();

            this.ContextBarLb.ItemsSource = null;
            UpdateContextBar();

        }

        #endregion

        #region [Event Handlers]

        private void Item_Click(object sender, MouseButtonEventArgs e)
        {
            ListBoxItem listBoxItem = (ListBoxItem)sender;
            object obj = listBoxItem.Content;

            //Notify subscribers of the item that was clicked
            ItemClickedEventArgs args = new ItemClickedEventArgs(obj);
            OnItemClicked(args);
        }

        #endregion

        #region [Public Methods]

        public void AddItem(ContextBarItem item)
        {
            AddItem(item.Value);
        }

        public void AddItem(object value)
        {
            _items.Push(value);
            UpdateContextBar();
        }

        public void RemoveItem(ContextBarItem item)
        {
            RemoveItem(item.Value);
        }

        public void RemoveItem(object value)
        {
            //One item must always be present
            //on the context bar
            if (_items.Count > 1)
            {
                //Check to see if top item on stack was clicked
                //Only pop off stack if they did not click this item
                while (value != null && !_items.Peek().Equals(value))
                {
                    _items.Pop();
                    UpdateContextBar();
                }
            }
        }

        #endregion

        #region [Private/Protected Methods]

        protected void UpdateContextBar()
        {
            this.ContextBarLb.ItemsSource = null;
            this.ContextBarLb.ItemsSource = _items.Reverse();
            this.ContextBarLb.DisplayMemberPath = this.ItemDisplayPath;
        }

        protected void OnItemClicked(ItemClickedEventArgs e)
        {
            //We need to determine if we should remove
            //the items automatically, let the invoker
            //remove it manually or make it configurable

            if (ItemClicked != null)
                ItemClicked(this, e);
        }

        #endregion
    }

    public class ItemClickedEventArgs : EventArgs
    {
        public Object Item { get; set; }

        public ItemClickedEventArgs(Object item)
        {
            Item = item;
        }
    }
}
