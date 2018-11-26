using System;
using System.Collections.Generic;
using System.Linq;
using _8StoryCore.Events;

namespace _8StoryCore
{
  public class StoryEngine
  {
    public StoryStatus Status => Story.Status;
    public readonly IStory Story;
    private StoryScene _curentScene = null;
    private readonly List<StoryScene> _allScenes = new List<StoryScene>();

    public IPlayerContext Context => Story.Context;

    public StoryEngine(IStory story)
    {
      Story = story;
      foreach (var sceneInfo in Story.Scenes)
      {
        _allScenes.Add(new StoryScene(sceneInfo));
      }
    }
    
    public List<StoryScene> AvailableScenes()
    {
      if (_curentScene != null && !_curentScene.Played) throw new Exception("Previous scene not played");
      
      var scenes = _allScenes.Where(x => !x.Played && x.Available).ToList();

      if (scenes.Count == 0 && Status != StoryStatus.Ended) throw new Exception("No more scene and not ended !");

      return scenes;
    }

    public StoryScene MandatoryScene()
    {
      throw new NotImplementedException();
    }
  }
}