using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using _8StoryCore;
using _8StoryCore.Events;
using _8StoryCore.Events.Narrative;
using _8StoryCoreTests.Mockups;

namespace _8StoryCoreTests.Events.Narrative
{
  public sealed class NarrativeEventTests
  {
    public class PlayEventMethod
    {
      private PlayerContext _context;

      [SetUp]
      public void BeforeAll()
      {
        _context = new PlayerContext();
      }

      [Test]
      public void It_tells_1_paragraph()
      {
        var narrativeEventInfo = new DummyNarrativeEventInfo();
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo);
        var results = narrativeEvent.PlayEvent(_context).ToList();

        Assert.AreEqual(results.Count, 1);
      }

      [Test]
      public void It_tell_3_paragraphs()
      {
        var narrativeEventInfo = new DummyNarrativeEventInfo(resultCount: 3);
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo);
        var results = narrativeEvent.PlayEvent(_context).ToList();

        Assert.AreEqual(results.Count, 3);
      }

      [Test]
      public void It_tell_2_paragraphs_with_one_notification()
      {
        var narrativeEventInfo = new DummyNarrativeEventInfoWithNotif();
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo);

        var eventResults = narrativeEvent.PlayEvent(_context).ToList();
        var notification = eventResults[1];

        Assert.AreEqual(notification.Type, ResultType.Notification);
      }

      [Test]
      public void Player_wins_battle()
      {
        var battleEventInfo = new BattleEventInfo();
        var narrativeEvent = new NarrativeEvent(battleEventInfo);
        var result = narrativeEvent.PlayEvent(_context).ToList()[0];

        Assert.AreEqual(result.Text, "Fail");
        Assert.AreEqual(result.Type, ResultType.Notification);
      }

      [Test]
      public void Player_loses_battle()
      {
        var battleEventInfo = new BattleEventInfo();
        var narrativeEvent = new NarrativeEvent(battleEventInfo);
        var result = narrativeEvent.PlayEvent(new PlayerContext(historicalKnowledge: 50)).ToList()[0];

        Assert.AreEqual(result.Text, "Success");
        Assert.AreEqual(result.Type, ResultType.Notification);
      }

      [Test]
      public void PlayerContext_cast_error_exception()
      {
        var eventInfo = new BattleEventInfo();
        var narrativeEvent = new NarrativeEvent(eventInfo);

        Assert.Throws<InvalidCastException>(() => narrativeEvent.PlayEvent(new WrongPlayerContext()).ToList());
      }

      [Test]
      public void It_is_handled_when_played()
      {
        var narrativeEvent = new NarrativeEvent(new DummyNarrativeEventInfo(resultCount:2));
        narrativeEvent.PlayEvent(new PlayerContext()).ToList();

        Assert.IsTrue(narrativeEvent.Handled);
      }

      [Test]
      public void It_is_not_handled_when_not_fully_played()
      {
        var narrativeEvent = new NarrativeEvent(new DummyNarrativeEventInfo(resultCount: 2));
        narrativeEvent.PlayEvent(new PlayerContext()).First();

        Assert.IsFalse(narrativeEvent.Handled);
      }
    }
  }

  public class WrongPlayerContext : IPlayerContext { }

  public class BattleEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      var pContext = (PlayerContext) context;
      if (pContext.HistoricalKnowledge > 25)
        yield return new EventResult("Success", ResultType.Notification);
      else
        yield return new EventResult("Fail", ResultType.Notification);
    }

    public EventType Type { get; }
  }

  public class DummyNarrativeEventInfoWithNotif : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext ctx)
    {
      yield return new EventResult("test");
      yield return new EventResult("test", ResultType.Notification);
    }

    public EventType Type { get; }
  }

  public class DummyNarrativeEventInfo : INarrativeEventInfo
  {
    private readonly int _resultCount;

    public DummyNarrativeEventInfo(int resultCount = 1)
    {
      _resultCount = resultCount;
    }

    public IEnumerable<EventResult> GetResults(IPlayerContext ctx)
    {
      for (var i = 0; i < _resultCount; i++)
        yield return new EventResult("test");
    }

    public EventType Type { get; }
  }
}
