using System;
using System.Collections.Generic;
using _8StoryCore.Choices;

namespace _8StoryCore.Events
{
  public sealed class ChoiceEvent : IStoryEvent
  {
    public string Name => _choiceEventInfo.Name;
    private readonly IChoiceEventInfo _choiceEventInfo;

    public ChoiceEvent(IChoiceEventInfo choiceEventInfo)
    {
      _choiceEventInfo = choiceEventInfo;
    }

    public List<ChoiceOption> Choices => _choiceEventInfo.Choices;
    public ChoiceOption PlayerChoice { get; private set; }

    public void Choose(ChoiceOption choiceOption, IPlayerContext context)
    {
      if (!choiceOption.CanChoose(context)) throw new Exception("cannot choose this");
      PlayerChoice = choiceOption;
    }
  }
}