using NUnit.Framework;
using _8StoryCore.Events.Choice.Options;
using _8StoryCoreTests.Mockups;

namespace _8StoryCoreTests.Events.Choice.Options
{
  public class ConditionalOptionTests
  {
    [Test]
    public void Always_true_condition()
    {
      var option = new ConditionalOption("Yeah !", (ctx) => true);

      Assert.IsTrue(option.CanChoose(null));
    }

    [Test]
    public void Player_historical_knowledge_OK()
    {
      var option = new ConditionalOption("Yeah !", (ctx) => ((PlayerContext)ctx).HistoricalKnowledge > 50);

      Assert.IsTrue(option.CanChoose(new PlayerContext(75)));
    }

    [Test]
    public void Player_historical_knowledge_KO()
    {
      var option = new ConditionalOption("Yeah !", (ctx) => ((PlayerContext)ctx).HistoricalKnowledge > 50);

      Assert.IsFalse(option.CanChoose(new PlayerContext(25)));
    }
  }
}