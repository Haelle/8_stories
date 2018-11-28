using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using _8StoryCore.Trials;

namespace _8StoryCore.Events
{
  public class TrialEvent : ISceneEvent
  {
    [XmlElement("TrialScore", typeof(TrialScore))]
    [XmlElement("TrialBoolean", typeof(TrialBoolean))]
    public ITrial Trial { get; set; }
    public string Text { get; set; }
    //public ListOfEvents SuccessEvents { get; set; }
    //public ListOfEvents PartialSuccessEvents { get; set; }
    //public ListOfEvents FailureEvents { get; set; }

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
