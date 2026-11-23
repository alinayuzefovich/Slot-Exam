using Domain.Entities;
using Domain.ValueTypes;

namespace Domain.Aggregates;

public class User: AggregateRoot
{
    public Guid UserId { get; }
    public long TelegramId { get; }
    public FullName FullName { get; private set; }
    public Guid GroupId { get; private set; }
    public DateTime CreatedAt { get; private set; }
    public bool IsCreator { get; private set; }
    public bool IsNotificationsEnabled { get; set; }
    public bool IsProfileCorrect => FullName != null && GroupId != Guid.Empty;

    private User(Guid id, long telegramId, bool isCreator = false, bool isNotificationEnabled = false,
        FullName fullName=null, Guid groupId=default(Guid))
    {
        UserId = id;
        TelegramId = telegramId;
        FullName = fullName;
        GroupId = groupId;
        CreatedAt = DateTime.UtcNow;
        IsCreator = isCreator;
        IsNotificationsEnabled = isNotificationEnabled;
    }

    public static User CreateUser(long telegramId)
    {
        return new User(Guid.NewGuid(), telegramId);
    }

    public void SetGroupId(Guid groupId)
    {
        if (groupId == Guid.Empty)
            throw new ArgumentException("Id группы не может быть пустым");

        GroupId = groupId;
    }

    public void SetFullName(FullName name)
    {
        if (name == null)
            throw new ArgumentNullException("Имя пользователя не может быть пустым");

        FullName = name;
    }

    public string? GetFullName()
    {
        return FullName != null ? FullName.ToString() : null;
    }
}