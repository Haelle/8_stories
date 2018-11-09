using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using _8StoryCore;
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
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo, _context);
        var results = narrativeEvent.PlayEvent().ToList();
        Assert.AreEqual(results.Count, 1);
      }

      [Test]
      public void It_tell_3_paragraphs()
      {
        var narrativeEventInfo = new DummyNarrativeEventInfo(resultCount: 3);
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo, _context);
        var results = narrativeEvent.PlayEvent().ToList();
        Assert.AreEqual(results.Count, 3);
      }

      [Test]
      public void It_tell_3_paragraphs_with_one_notification()
      {
        var narrativeEventInfo = new DummyNarrativeEventInfoWithNotif();
        var narrativeEvent = new NarrativeEvent(narrativeEventInfo, _context);

        var eventResults = narrativeEvent.PlayEvent().ToList();
        var notification = eventResults[1];

        Assert.AreEqual(notification.Type, ResultType.Notification);
      }

      [Test]
      public void Player_wins_battle()
      {
        var battleEventInfo = new BattleEventInfo();
      }
    }
  }

  public class BattleEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      
    }
  }

  public class DummyNarrativeEventInfoWithNotif : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext ctx)
    {
      yield return new EventResult("test");
      yield return new EventResult("test", ResultType.Notification);
    }
  }

  public class DummyNarrativeEventInfo : INarrativeEventInfo
  {
    private readonly int _resultCount;

    public DummyNarrativeEventInfo(int resultCount = 1)
    {
      this._resultCount = resultCount;
    }

    public IEnumerable<EventResult> GetResults(IPlayerContext ctx)
    {
      for (var i = 0; i < _resultCount; i++)
      {
        yield return new EventResult("test");
      }
    }
  }
}
