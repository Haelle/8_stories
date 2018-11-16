using System;

namespace _8StoryCore
{
  public enum StoryStatus
  {
    Telling = 0,
    Ended
  }

  public class StoryEngine<T>
  {
    public StoryStatus StoryStatus { get; private set; }
    public StoryScene<T> CurrentScene { get; private set; }

    public StoryEngine(IPlayerContext context, StoryScene<T> scene)
    {
    }

    public StoryScene<T> NextScene()
    {
      return null;
    }
  }

  public class EndEventMissingException : Exception
  {
  }
}