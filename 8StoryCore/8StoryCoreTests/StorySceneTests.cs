using System;
using System.Collections.Generic;
using NUnit.Framework;
using _8StoryCore;
using _8StoryCore.Events;
using _8StoryCore.Events.Narrative;
using _8StoryCoreTests.Mockups;

namespace _8StoryCoreTests
{
  public class StorySceneTests
  {
    public class ConstructorMethod
    {
      [Test]
      public void Throws_exception_if_not_a_start_event()
      {
        var narrativeEvent = new NarrativeEvent(new RandomEventInfo());
        var context = new PlayerContext();

        Assert.Throws<ArgumentException>(() => new StoryScene<PlayerContext>(narrativeEvent, context));
      }

      [Test]
      public void Throws_exception_if_invalid_cast_context()
      {
        var randomEvent = new NarrativeEvent(new OnlyStartingEventInfo());
        var context = new InvalidPlayerContext();

        Assert.Throws<InvalidCastException>(() => new StoryScene<PlayerContext>(randomEvent, context));
      }
    }

    public class NextEventMethod
    {
      [Test]
      public void It_returns_the_next_event()
      {
        var narrativeEvent = new NarrativeEvent(new StartingEventInfo());
        var context = new PlayerContext();
        var scene = new StoryScene<PlayerContext>(narrativeEvent, context);

        Assert.IsInstanceOf<IStoryEvent>(scene.NextEvent());
      }

      [Test]
      public void Throws_exception_if_do_not_have_end_event()
      {
        var narrativeEvent = new NarrativeEvent(new OnlyStartingEventInfo());
        var context = new PlayerContext();
        var scene = new StoryScene<PlayerContext>(narrativeEvent, context);

        Assert.Throws<SceneMissingEndEventException>(() => scene.NextEvent());
      }

      [Test]
      public void Cannot_have_next_event_if_last_one_not_handled()
      {
        var narrativeEvent = new NarrativeEvent(new StartingEventInfo());
        var context = new PlayerContext();
        var scene = new StoryScene<PlayerContext>(narrativeEvent, context);

        Assert.Throws<UnhandledStoryEventException>(() => scene.NextEvent());
      }
    }
  }

  public class RandomEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      yield return new EventResult("Yeah !");
    }

    public EventType Type { get; }
  }

  public class StartingEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      throw new NotImplementedException();
    }

    //public IStoryEvent NextEvent => new EndEvent();
    public EventType Type => EventType.Starting;
  }

  public class OnlyStartingEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      throw new NotImplementedException();
    }

    public EventType Type => EventType.Starting;
  }

  public class InvalidPlayerContext : IPlayerContext { }
}
