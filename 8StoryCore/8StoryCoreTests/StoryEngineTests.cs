using System;
using NUnit.Framework;
using _8StoryCore;
using _8StoryCoreTests.Architecture;

namespace _8StoryCoreTests
{
  public class StoryEngineTests
  {

    public class ConstructorMethods : StoryEngineTests
    {
      [Test]
      public void It_starts_with_the_first_scene()
      {
        var scene = new StoryScene();
        var engine = An.Engine().WithScene(scene).Build();
        engine.NextScene();

        Assert.AreEqual(engine.CurrentScene, scene);
      }

      [Test]
      public void It_requires_a_scene_to_start()
      { 
        Assert.Throws<ArgumentNullException>(() => An.Engine().Build());
      }
    }

    /*
    [Test]
    public void Constructor_require_at_least_one_event()
    {
      Assert.Throws<ArgumentNullException>(() => An.Engine().Build());
    }

    [Test]
    public void Raise_error_if_no_more_events()
    {
      Assert.Throws<ArgumentException>(() => new StoryEngine(new List<StoryEvent>()));
    }

    [Test]
    public void Event_registered()
    {
      var engine = An.Engine()
        .WithEvents(A.SomeDummyRandomEvents())
        .Build();
      Assert.AreEqual(2, engine.Events.Count);
    }
  }

  public class CurrentEventMethod : StoryEngineTests
  {
    [Test]
    public void Initialized_at_null()
    {

    }

    [Test]
    public void Not_null_after_pop_next_event()
    {

    }

    [Test]
    public void Null_after_it_was_handled()
    {

    }
  }

  public class StoryStatusAttribute : StoryEngineTests
  {
    [Test]
    public void Default_status_is_telling()
    {
      var events = new List<StoryEvent>() { new RandomEvent() };
      var engine = An.Engine().WithEvents(events).Build();

      Assert.AreEqual(StoryStatus.Telling, engine.StoryStatus);
    }

    [Test]
    public void EndEvent_change_status_to_ended()
    {
      var events = new List<StoryEvent>() { new EndEvent() };
      var engine = An.Engine().WithEvents(events).Build();

      engine.PopNextEvent();
      Assert.AreEqual(StoryStatus.Ended, engine.StoryStatus);
    }
  }

  public class PopNextEventMethod : StoryEngineTests
  {
    [Test]
    public void Raise_error_if_no_more_events()
    {
      var events = new List<StoryEvent>() { new RandomEvent() };
      var engine = An.Engine().WithEvents(events).Build();

      engine.PopNextEvent();
      Assert.Throws<EndEventMissingException>(() => engine.PopNextEvent());
    }

    [Test]
    public void Cannot_pop_next_event_if_previous_not_handled()
    {

    }

    [Test]
    public void First_in_first_out_events()
    {
      var event1 = new RandomEvent();
      var event2 = new RandomEvent();
      var engine = An.Engine()
        .WithEvents(new List<StoryEvent>() {event1, event2})
        .Build();

      Assert.AreEqual(event1, engine.PopNextEvent());
      Assert.AreEqual(event2, engine.PopNextEvent());
    }

    [Test]
    public void Story_has_ended()
    {

    }
  }
  */
    }
  }