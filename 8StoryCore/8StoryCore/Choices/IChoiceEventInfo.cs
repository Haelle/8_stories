using System.Collections.Generic;

namespace _8StoryCore.Choices
{
  public interface IChoiceEventInfo
  {
    string Name { get; }
    List<ChoiceOption> Choices { get; }
  }
}