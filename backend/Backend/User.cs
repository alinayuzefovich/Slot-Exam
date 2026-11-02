namespace Domain;

class User
{
    private static int _currentId;
    public int Id { get; }
    public int TelegramId { get;}
    public FullName FullName { get; }
    public Group Group { get; }
    public DateTime CreateTime { get; }

    public List<Booking> bookings { get; }


    public User(int telergamId, FullName fullName, Group group)
    {
        Id = _currentId++;
        FullName = fullName;
        Group = group;
        CreateTime = DateTime.Now;
    }
}