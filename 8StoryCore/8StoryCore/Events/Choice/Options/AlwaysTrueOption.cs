namespace _8StoryCore.Events.Choice.Options
{
  public class AlwaysTrueOption : IChoiceOption
  {
    public string Text { get; }

    public AlwaysTrueOption(string text)
    {
      Text = text;
    }
    
    public bool CanChoose(IPlayerContext context)
    {
      return true;
    }
  }
}