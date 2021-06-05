namespace ClassesFolder
{
    public class User : IUser
    {
        protected string _username;
        protected string _name;
        protected string _surname;
        protected string _specialization;

        public string Username => _username;
        public string Name => _name;
        public string Surname => _surname;
        public string Specialization => _specialization;

        public User(string username,
                    string name,
                    string surname,
                    string property)
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
