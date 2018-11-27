using System;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace _8StoryCore.Trials
{
  public class TrialScore : ITrial
  {
    public int? Objective { get; set; }
    public int PartialObjective { get; set; }
    [XmlElement("Properties")]
    public List<string> Properties { get; set; }

    public TrialResultType Try(IContext ctx)
    {
      throw new NotImplementedException();
    }

    public bool Valid()
    {
      foreach (var property in Properties)
        if (string.IsNullOrEmpty(property)) return false;

      return Objective != null &&
        Properties != null && Properties.Count > 0;
    }
  }
}
