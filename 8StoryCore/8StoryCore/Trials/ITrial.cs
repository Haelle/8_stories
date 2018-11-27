using System.Collections.Generic;

namespace _8StoryCore.Trials
{
  public enum TrialResultType
  {
    Success,
    PartialSuccess,
    Failure
  }

  public interface ITrial
  {
    bool Valid();
    TrialResultType Try(IContext ctx);
    List<string> Properties { get; set; }
  }
}