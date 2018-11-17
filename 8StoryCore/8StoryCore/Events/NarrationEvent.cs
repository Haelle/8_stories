using System;

namespace _8StoryCore.Events
{
  public sealed class NarrationEvent : IStoryEvent
  {
    public Enum Speaker { get; }
    public string Text { get; }
    public string Name => Text;

    public NarrationEvent(Enum storySpeaker, string text)
    {
      Speaker = storySpeaker;
      Text = text;
    }
  }
}