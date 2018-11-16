using System;
using System.Collections.Generic;
using _8StoryCore.Events;

namespace _8StoryCore
{
  public enum SceneStatus
  {
    Telling = 0,
    Ended
  }

  public interface ISceneInfo
  {
    IEnumerable<IStoryEvent> NextEvent();
  }

  public class StoryScene
  {
    internal IStoryEvent CurrentEvent { get; private set; }

    public StoryScene(ISceneInfo sceneInfo, IPlayerContext context)
    {
      //if (startingEvent.Type != EventType.Starting) throw new ArgumentException("not a starting event !");
      //if (!(context is T)) throw new InvalidCastException("context is not a good type");

      //CurrentEvent = startingEvent;
    }

    public SceneStatus SceneStatus { get; private set; }

    public IStoryEvent NextEvent()
    {
      if (!CurrentEvent.Handled) throw new UnhandledStoryEventException();
      if (CurrentEvent.NextEvent == null && CurrentEvent.Type != EventType.Ending) throw new SceneMissingEndEventException();

      return CurrentEvent.NextEvent;
    }
  }

  public class SceneMissingEndEventException : Exception { }
  public class UnhandledStoryEventException : Exception { }
}