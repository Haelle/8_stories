using System;
using System.Collections;
using System.Collections.Generic;
using _8StoryCore.Events;

namespace _8StoryCore
{
  public class StoryScene
  {
    private readonly IStorySceneInfo _sceneInfo;

    public StoryScene(IStorySceneInfo sceneInfo)
    {
      _sceneInfo = sceneInfo;
    }

    public string Name => _sceneInfo.Name;
    public bool Played { get; private set; }
    public bool Available { get; private set; }

    public IEnumerable<IStoryEvent> NextEvent()
    {
      foreach (var storyEvent in _sceneInfo.NextEvent())
      {
        yield return storyEvent;
      }
    }
  }
}