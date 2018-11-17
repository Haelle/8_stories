using System;

namespace _8StoryCore.Events
{
  public sealed class TestEvent : IStoryEvent
  {
    public TestEvent(Func<bool> test)
    {
      Success = test();
    }

    public bool Success { get; private set; }

    public string ResultInfo => Success.ToString();
    public string Name { get; }
  }
}
