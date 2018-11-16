using System;
using System.Collections.Generic;
using System.Linq;
using _8StoryCore.Events.Choice.Options;

namespace _8StoryCore.Events.Choice
{
  public sealed class ChoiceEvent : IStoryEvent
  {
    public EventType Type { get; }
    public bool Handled { get; private set; }
    public IStoryEvent NextEvent { get; }
    private readonly IChoiceEventInfo _choiceInfo;
    internal IChoiceOption CurrentChoice;

    public ChoiceEvent(IChoiceEventInfo choiceInfo)
    {
      this._choiceInfo = choiceInfo;
    }

    public List<IChoiceOption> Choices => _choiceInfo.Choices;

    public bool Choose(IChoiceOption choice, IPlayerContext ctx)
    {
      if (choice == null || ctx == null) throw new ArgumentNullException("one paramter is null but can't !");

      if (!Choices.Any(c => c.Text == choice.Text)) return false;
      if (!choice.CanChoose(ctx)) return false;

      CurrentChoice = choice;
      Handled = true;
      return true;
    }
  }
}
