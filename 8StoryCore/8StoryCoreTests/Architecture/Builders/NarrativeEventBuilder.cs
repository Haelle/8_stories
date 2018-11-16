using _8StoryCore.Events.Narrative;

namespace _8StoryCoreTests.Architecture.Builders
{
  public class NarrativeEventBuilder
  {
    private INarrativeEventInfo _eventInfo;

    public NarrativeEventBuilder(INarrativeEventInfo eventInfo)
    {
      _eventInfo = eventInfo;
    }

    public NarrativeEventBuilder WithEventInfo(INarrativeEventInfo eventInfo)
    {
      _eventInfo = eventInfo;
      return this;
    }

    public NarrativeEvent Build()
    {
      return new NarrativeEvent(_eventInfo);
    }
  }
}
