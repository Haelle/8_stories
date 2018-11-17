namespace _8StoryCore.Events
{
  public sealed class NotificationEvent : IStoryEvent
  {
    public string Name => Text;
    public string Text { get; }

    public NotificationEvent(string text)
    {
      Text = text;
    }
  }
}