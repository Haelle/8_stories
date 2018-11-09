using System.Collections.Generic;
using _8StoryCore.Events.Choice.Options;

namespace _8StoryCore.Events.Choice
{
  public interface IChoiceEventInfo
  {
    List<IChoiceOption> Choices { get; }
  }
}