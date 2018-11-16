namespace _8StoryCore.Events.Narrative
{
  public enum ResultType
  {
    Narrative,
    Notification
  }

  public class EventResult
  {
    public EventResult(string speaker, string text, ResultType type = ResultType.Narrative)
    {
      Speaker = speaker;
      Text = text;
      Type = type;
    }

    public string Speaker { get; private set; }
    public string Text { get; private set; }
    public ResultType Type { get; private set; }
  }
}