using System;

namespace _8StoryCore
{
  public enum StoryStatus
  {
    Telling = 0,
    Ended
  }

  public class StoryEngine
  {
    public StoryStatus StoryStatus { get; private set; }
    public StoryScene CurrentScene { get; private set; }

    public StoryEngine(IPlayerContext context, StoryScene scene)
    {
    }

    public StoryScene NextScene()
    {
      return null;
    }
  }

  public class EndEventMissingException : Exception
  {
  }
}