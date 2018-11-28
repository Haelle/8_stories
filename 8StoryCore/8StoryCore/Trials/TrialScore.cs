using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace _8StoryCore.Trials
{
  public class TrialScore : ITrial
  {
    [XmlElement("Properties")]
    public override List<string> Properties { get; set; }
    public int? Objective { get; set; }
    public int PartialObjective { get; set; }

    public override TrialResultType Try(IContext ctx)
    {
      throw new NotImplementedException();
    }

    public override bool Valid()
    {
      foreach (var property in Properties)
        if (string.IsNullOrEmpty(property)) return false;

      return Objective != null &&
        Properties != null && Properties.Count > 0;
    }
  }
}
