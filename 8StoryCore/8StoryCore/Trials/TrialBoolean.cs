using System.Collections.Generic;
using System.Xml.Serialization;

namespace _8StoryCore.Trials
{
  public class TrialBoolean : ITrial
  {
    [XmlElement("Properties")]
    public List<string> Properties { get; set; }
    public bool? Objective { get; set; }

    public bool Valid()
    {
      foreach (var property in Properties)
        if (string.IsNullOrEmpty(property)) return false;

      return Objective != null &&
             Properties != null && Properties.Count > 0;
    }

    public TrialResultType Try(IContext ctx)
    {
      throw new System.NotImplementedException();
    }

    
  }
}
