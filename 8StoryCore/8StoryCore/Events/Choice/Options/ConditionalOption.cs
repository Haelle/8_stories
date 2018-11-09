using System;

namespace _8StoryCore.Events.Choice.Options
{
  public class ConditionalOption : IChoiceOption
  {
    private readonly Func<IPlayerContext, bool> _func;

    public ConditionalOption(string text, Func<IPlayerContext, bool> func)
    {
      Text = text;
      _func = func;
    }

    public string Text { get; }
    public bool CanChoose(IPlayerContext ctx)
    {
      return _func(ctx);
    }
  }
}