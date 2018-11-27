namespace _8StoryCore.Events
{
  public enum EndEventType
  {
    SceneEnd,
    Victory,
    GameOver
  }
  public class EndEvent : ISceneEvent
  {
    public string Text { get; set; }
    public EndEventType? Type { get; set; }

    public bool Valid() => !string.IsNullOrEmpty(Text) &&
                            Type != null;
  }
}
