using System;
using System.Collections.Generic;

namespace _8StoryCore.Events
{
  public class ChoiceOption
  {
    public string Text { get; set; }
    public ListOfEvents XmlConsecutiveEvents { get; set; }

    public bool Valid()
    {
      return false;
    }

    public IEnumerable<ISceneEvent> ConsecutiveEvents()
    {
      throw new Exception();
    } 

    public bool CanChoose(IContext ctx)
    {
      return false;
    }
  }
}
