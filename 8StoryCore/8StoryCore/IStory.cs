using System.Collections.Generic;

namespace _8StoryCore
{
  public enum StoryStatus
  {
    Telling = 0,
    Ended
  }
  public interface IStory
  {
    IPlayerContext Context { get; }
    StoryStatus Status { get; }
    List<IStorySceneInfo> Scenes { get; }
  }
}