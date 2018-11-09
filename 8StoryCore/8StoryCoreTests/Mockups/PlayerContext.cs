using _8StoryCore;

namespace _8StoryCoreTests.Mockups
{
  class PlayerContext : IPlayerContext
  {
    public PlayerContext(int historicalKnowledge = 0)
    {
      HistoricalKnowledge = historicalKnowledge;
    }

    public int HistoricalKnowledge { get; }
  }
}