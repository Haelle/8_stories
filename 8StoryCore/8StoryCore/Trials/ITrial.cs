using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;
using _8StoryCore.Events;

namespace _8StoryCore.Trials
{
  public enum TrialResultType
  {
    Success,
    PartialSuccess,
    Failure
  }

  public abstract class ITrial
  {
    [XmlElement("Properties")]
    public abstract List<string> Properties { get; set; }
    public abstract bool Valid();
    public abstract TrialResultType Try(IContext ctx);
  }
}