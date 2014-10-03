namespace RadDiagramSample.ViewModels
{
    public class ControlAViewModel:ControlViewModel
    {
        private string _firstName;
        public string FirstName
        {
            get { return _firstName; }
            set
            {
                if(_firstName != value)
                {
                    _firstName = value;
                    OnPropertyChanged("FirstName");
                }
            }
        }

        public ControlAViewModel()
        {
            Name = "Control A";
        }
    }
}