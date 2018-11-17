using System;
using System.Collections.Generic;

namespace _8StoryCore
{
  public class StoryEngine
  {
    public readonly IStory Story;

    public IPlayerContext Context => Story.Context;

    public StoryEngine(IStory story)
    {
      Story = story;
    }
    
    public IEnumerable<StoryScene> NextScene()
    {
      foreach (var sceneInfo in Story.NextSceneInfo())
        yield return new StoryScene(sceneInfo);
    }

    public List<StoryScene> AvailableScenes()
    {
      throw new NotImplementedException();
    }

    public StoryScene MandatoryScene()
    {
      throw new NotImplementedException();
    }
  }
}