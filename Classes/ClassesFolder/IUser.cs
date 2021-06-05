namespace ClassesFolder
{
    public interface IUser
    {
        string Name { get; }
        string Specialization { get; }
        string Surname { get; }
        string Username { get; }

        string GetFullName();
    }
}