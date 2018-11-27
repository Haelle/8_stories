using System.Xml.Serialization;

namespace _8StoryCore.Events
{
  public class NarrativeEvent : ISceneEvent
  {
    public string Speaker { get; set; }
    public string Text { get; set; }
    public bool Valid() => !string.IsNullOrEmpty(Speaker) &&
                           !string.IsNullOrEmpty(Text);
  }
}