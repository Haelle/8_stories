namespace _8StoryCore.Events
{
  public interface ISceneEvent
  {
    string Text { get; set; }
    bool Valid();
  }
}