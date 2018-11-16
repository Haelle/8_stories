using System.Collections.Generic;

namespace _8StoryCore.Events.Narrative
{
  public interface INarrativeEventInfo
  {
    IEnumerable<EventResult> GetResults(IPlayerContext context);
    EventType Type { get; }
  }
}
