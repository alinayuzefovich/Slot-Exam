namespace Domain;

class User
{
    private static int _currentId;
    public int Id { get; }
    public int TelegramId { get;}
    public FullName? FullName { get; }
    public Group? Group { get; }
    public DateTime? CreateTime { get; }
    public List<Booking>? bookings { get; }
    public bool? IsCreator { get; }
    public bool? IsNotificationsEnabled { get; }
    public bool IsProfileCorrect => FullName != null && Group != null;


    public User(int telergamId, FullName? fullName=null, Group? group=null,
        bool? isCreator=null, bool? isNotificationEnabled=null)
    {
        Id = _currentId++;
        FullName = fullName;
        Group = group;
        CreateTime = DateTime.Now;
        IsCreator = isCreator;
        IsNotificationsEnabled = isNotificationEnabled;
    }
}