using System.Collections.Generic;

namespace _8StoryCore.Events.Narrative
{
  public sealed class NarrativeEvent : IStoryEvent
  {
    public EventType Type => _eventInfo.Type;
    public bool Handled { get; private set; }
    public IStoryEvent NextEvent { get; }
    private readonly INarrativeEventInfo _eventInfo;

    public NarrativeEvent(INarrativeEventInfo firstEventInfo)
    {
      _eventInfo = firstEventInfo;
    }

    public IEnumerable<EventResult> PlayEvent(IPlayerContext context)
    {
      foreach (var result in _eventInfo.GetResults(context))
        yield return result;

      Handled = true;
    }
  }
}
