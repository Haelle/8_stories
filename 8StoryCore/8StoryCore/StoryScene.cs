using _8StoryCore.Events;

namespace _8StoryCore
{
  public enum SceneStatus
  {
    Telling = 0,
    Ended
  }

  public class StoryScene
  {
    public SceneStatus SceneStatus { get; private set; }

    public IStoryEvent NextEvent()
    {
      throw new System.NotImplementedException();
    }
  }
}