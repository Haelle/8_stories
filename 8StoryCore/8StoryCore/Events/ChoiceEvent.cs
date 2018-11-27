using System;
using _8StoryCore.Events;

public class ChoiceEvent : ISceneEvent
{
  public string Text { get; set; }

  public bool Valid()
  {
    throw new NotImplementedException();
  }
}