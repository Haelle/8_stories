using System.Collections.Generic;
using _8StoryCore;
using _8StoryCore.Events;
using _8StoryCore.Events.Choice;
using _8StoryCore.Events.Choice.Options;
using _8StoryCore.Events.Narrative;

namespace ConsoleStory
{
  public interface IStory
  {
    IEnumerable<StoryScene> NextScene();
  }

  public enum Mood
  {
    Willness
  }

  public class PlayerContext : IPlayerContext
  {
    public int Willness { get; private set; }
    public EventResult IncreaseMood(Mood mood, int value)
    {
      Willness += value;
      // TODO: create a sub class for notifications
      return new EventResult("NONE", "Willness", ResultType.Notification);
    }
  }

  public class Story1 : IStory
  {
    public PlayerContext Context;
    public IEnumerable<StoryScene> NextScene()
    {
      yield return new StoryScene(new IntroSceneInfo(), Context);
      yield return new StoryScene(new SnakeInfo(), Context);
    }
  }

  public class IntroSceneInfo : ISceneInfo
  {
    public IEnumerable<IStoryEvent> NextEvent()
    {
      yield return new NarrativeEvent(new IntroEventInfo());
      yield return new ChoiceEvent(new AuntChoiceInfo());
    }
  }

  public class IntroEventInfo : INarrativeEventInfo
  {
    public EventType Type => EventType.Starting;

    public IEnumerable<EventResult> GetResults(IPlayerContext icontext)
    {
      var context = (PlayerContext)icontext;
      yield return new EventResult("King", "Intro");
      yield return new EventResult("Princess", "No!");
      yield return new EventResult("King", "Yes !");
      yield return new EventResult("Princess", "I'm the Princess here");
      yield return context.IncreaseMood(Mood.Willness, 1);
    }
  }

  public class AuntChoiceInfo : IChoiceEventInfo
  {
    public List<IChoiceOption> Choices
    {
      get
      {
        return new List<IChoiceOption>() {
          new AlwaysTrueOption("Throw her in prison !"),
          new AlwaysTrueOption("I decide, she stays"),
          new AlwaysTrueOption("Please leave...")
        };
      }
    }
  }

  public class SnakeInfo : ISceneInfo
  {
    public IEnumerable<IStoryEvent> NextEvent()
    {
      throw new System.NotImplementedException();
    }
  }
}
