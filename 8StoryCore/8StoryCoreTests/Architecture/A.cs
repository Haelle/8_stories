using System.Collections.Generic;
using _8StoryCore;
using _8StoryCore.Events;
using _8StoryCoreTests.Architecture.Builders;
using _8StoryCoreTests.Events;

namespace _8StoryCoreTests.Architecture
{
  public static class A
  {
    public static List<IStoryEvent> SomeDummyRandomEvents()
    {
      return new List<IStoryEvent>() { new RandomEvent(), new RandomEvent() };
    }

    public static List<IStoryEvent> ValidEvents()
    {
      return new List<IStoryEvent>() { new RandomEvent(), new EndEvent() };
    }

    public static StoryScene Scene()
    {
      return new StorySceneBuilder().Build();
    }
  }

  public class RandomEvent : IStoryEvent
  {
  }
}
