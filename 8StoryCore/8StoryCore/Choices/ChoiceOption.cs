namespace _8StoryCore.Choices
{
  public class ChoiceOption
  {
    public string Text { get; }

    public ChoiceOption(string text)
    {
      Text = text;
    }

    public bool CanChoose(IPlayerContext context)
    {
      return true;
    }
  }
}