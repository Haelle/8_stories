namespace _8StoryCore.Events.Choice.Options
{
  public interface IChoiceOption
  {
    string Text { get; }

    bool CanChoose(IPlayerContext context);
  }
}