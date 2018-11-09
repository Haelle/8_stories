namespace _8StoryCore.Events.Narrative
{
  public enum ResultType
  {
    Narrative,
    Notification
  }

  public class EventResult
  {
    public EventResult(string text, ResultType type = ResultType.Narrative)
    {
      Text = text;
      Type = type;
    }

    public string Text { get; private set; }
    public ResultType Type { get; private set; }
  }
}