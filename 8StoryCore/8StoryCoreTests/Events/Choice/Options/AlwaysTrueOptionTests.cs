using NUnit.Framework;
using _8StoryCore;
using _8StoryCore.Events.Choice.Options;
using _8StoryCoreTests.Mockups;

namespace _8StoryCoreTests.Events.Choice.Options
{
  public class AlwaysTrueOptionTests
  {
    [Test]
    public void Options_always_possible()
    {
      var option = new AlwaysTrueOption("Yeah !");

      Assert.IsTrue(option.CanChoose(null));
    }

    [Test]
    public void True_with_player_context()
    {
      var option = new AlwaysTrueOption("Yeah !");

      Assert.IsTrue(option.CanChoose(new PlayerContext()));
    }
  }
}