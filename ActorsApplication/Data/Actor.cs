using System.Collections.Specialized;
using System.ComponentModel;

namespace ActorsApplication.Data
{
    public class Actor : INotifyPropertyChanged
    {
        //Originele code, maar deze synchroniseert niet goed wanneer een property verandert
        //
        //public string LastName { get; set; } = "";
        //public string FirstName { get; set; } = "";
        //public string ProfilePicture { get; set; } = "";
        //public int BirthYear { get; set; } = 1950;
        //public string ShortBio { get; set; } = "";



        //Nieuwe manier die wel zorgt dat het goed gesynchroniseert wordt

        private string _lastName = "";
        public string LastName
        {
            get => _lastName;
            set 
            { 
                _lastName = value;
                RaiseEventPropChanged(nameof(LastName));
                RaiseEventPropChanged(nameof(FullName));
            }
        }

        private string _firstName = "";
        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                RaiseEventPropChanged(nameof(FirstName));
                RaiseEventPropChanged(nameof(FullName));
            }
        }

        private string _profilePicture = "";
        public string ProfilePicture
        {
            get => _profilePicture;
            set
            {
                _profilePicture = value;
                RaiseEventPropChanged(nameof(ProfilePicture));
            }
        }

        private int _birthYear = 1950;
        public int BirthYear
        {
            get => _birthYear;
            set
            {
                _birthYear = value;
                RaiseEventPropChanged(nameof(BirthYear));
            }
        }

        private string _shortBio = "";
        public string ShortBio
        {
            get => _shortBio;
            set
            {
                _shortBio = value;
                RaiseEventPropChanged(nameof(ShortBio));
            }
        }

        //Aangezien deze geen setter heeft, wordt de raiseevent gezet in de LastName en FirstName properties, aangezien het daar ook gesynchroniseerd wordt moest er een lastname of firstname aangepast zou worden
        public string FullName
        {
            get
            { 
                return _firstName + " " + _lastName;
            }
        }



        public event PropertyChangedEventHandler? PropertyChanged;

        public void RaiseEventPropChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this,new PropertyChangedEventArgs(propertyName));
        }
    }
}
