namespace _8StoryCore.Events
{
  public enum EventType
  {
    Telling = 0,
    Starting,
    Ending
  }

  public interface IStoryEvent
  {
    EventType Type { get; }
    bool Handled { get; }
    IStoryEvent NextEvent { get; }
  }
}