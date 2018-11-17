using System.Collections.Generic;
using _8StoryCore.Events;

namespace _8StoryCore
{
  public interface IStorySceneInfo
  {
    IEnumerable<IStoryEvent> NextEvent();
    string Name { get; }
  }
}