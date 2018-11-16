namespace _8StoryCore.Events
{
    public class EndEvent : IStoryEvent
    {
      public EventType Type => EventType.Ending;
      public bool Handled { get; }
      public IStoryEvent NextEvent => null;
    }
}