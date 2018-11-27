namespace _8StoryCore.Events
{
  public enum NotificationType
  {
    Normal,
    Positive,
    Negative
  }

  public class NotificationEvent : ISceneEvent
  {
    public string Text { get; set; }
    public NotificationType? Type { get; set; }
    public bool Valid() => !string.IsNullOrEmpty(Text) &&
                           Type != null;
  }
}