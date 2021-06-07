using static ClassesFolder.Enums;

namespace ClassesFolder
{
    public class User
    {
        protected string _username;
        protected string _name;
        protected string _surname;
        protected Specialization _specialization;

        public string Username => _username;
        public string Name => _name;
        public string Surname => _surname;
        public Specialization Specialization => _specialization;

        public User(string username,
                    string name,
                    string surname,
                    Specialization property)
        {
            _username = username;
            _name = name;
            _surname = surname;
            _specialization = property;
        }

        public string GetFullName()
        {
            return $"{_name} {_surname}";
        }
    }
}
