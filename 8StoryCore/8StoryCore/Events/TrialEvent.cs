using System;
using _8StoryCore.Trials;

namespace _8StoryCore.Events
{
  public class TrialEvent : ISceneEvent
  {
    public string Text { get; set; }
    public ITrial Trial { get; set; }
    public ListOfEvents SuccessEvents { get; set; }
    public ListOfEvents PartialSuccessEvents { get; set; }
    public ListOfEvents FailureEvents { get; set; }

    public bool Valid()
    {
      return !string.IsNullOrEmpty(Text) &&
        Trial != null;
    }

    public bool CanOvercome(IContext ctx)
    {
      return false;
    }
  }
}
