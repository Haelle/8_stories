using System.Collections.Generic;

namespace _8StoryCore.Events.Narrative
{
  public class NarrativeEvent : IStoryEvent
  {
    private readonly INarrativeEventInfo _eventInfo;
    private readonly IPlayerContext _context;

    public NarrativeEvent(INarrativeEventInfo firstEventInfo, IPlayerContext context)
    {
      _eventInfo = firstEventInfo;
      _context = context;
    }

    public IEnumerable<EventResult> PlayEvent()
    {
      foreach (var result in _eventInfo.GetResults(_context))
        yield return result;
    }
  }
}
