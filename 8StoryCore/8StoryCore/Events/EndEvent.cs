namespace _8StoryCore.Events
{
  public enum EndEventType
  {
    Normal = 0,
    Victory,
    GameOver
  }
  public sealed class EndEvent : IStoryEvent
  {
    public string Name { get; }
    public EndEventType EndType { get; }

    public EndEvent()
    {
      Name = "Normal";
    }

    public EndEvent(string name, EndEventType endType)
    {
      Name = name;
      EndType = endType;
    }
  }
}