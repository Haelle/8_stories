using System.Collections.Generic;
using _8StoryCore;
using _8StoryCore.Choices;
using _8StoryCore.Events;

namespace ConsoleStory
{
  public class PlayerContext : IPlayerContext
  {
    public int Will { get; set; }
    public int Agility => 50;
    public bool CousinSaved { get; set; }

    public NotificationEvent IncreaseWill(int i)
    {
      Will += 1;
      return new NotificationEvent("Will Increase");
    }
  }

  public class Story : IStory
  {
    public enum StorySpeaker
    {
      King,
      Princess,
      Aunt,
      Narrator,
      Cousin
    }

    public IPlayerContext Context { get; }
    public StoryStatus Status { get; set; }
    public List<IStorySceneInfo> Scenes => new List<IStorySceneInfo>()
    {
      new IntroSceneInfo((PlayerContext)Context),
      new SnakeSceneInfo((PlayerContext)Context)
    };

    public Story()
    {
      Context = new PlayerContext();
    }
  }

  public class IntroSceneInfo : IStorySceneInfo
  {
    public string Name => "Intro";
    private PlayerContext Context { get; }

    public IntroSceneInfo(PlayerContext context)
    {
      Context = context;
    }

    public IEnumerable<IStoryEvent> NextEvent()
    {
      yield return new NarrationEvent(Story.StorySpeaker.King, text: "Yield before me !");
      yield return new NarrationEvent(Story.StorySpeaker.Princess, text: "No ! I'm the Princess here");
      yield return Context.IncreaseWill(1);
      yield return new NarrationEvent(Story.StorySpeaker.King, text: "I yield to the Princess");
      yield return new EndEvent();
    }
  }
  
  public class SnakeSceneInfo : IStorySceneInfo
  {
    public string Name => "Snake Scene";
    public PlayerContext Context { get; }

    public SnakeSceneInfo(PlayerContext context)
    {
      Context = context;
    }
    
    public IEnumerable<IStoryEvent> NextEvent()
    {
      yield return new NarrationEvent(Story.StorySpeaker.Princess, text: "What a wonderful day !");
      yield return new NarrationEvent(Story.StorySpeaker.Aunt, text: "Don't move a snake !");

      var snakeChoiceInfo = new SnakeChoiceEventInfo();
      var choiceEvent = new ChoiceEvent(snakeChoiceInfo);
      yield return choiceEvent;
      // TODO : automatically raise event if choice is not made
      if (choiceEvent.PlayerChoice.Text == SnakeChoiceEventInfo.HoldStill.Text)
      {
        var testEvent = new TestEvent(() => Context.Agility > 25);
        yield return testEvent;
        if (testEvent.Success)
        {
          yield return new NarrationEvent(Story.StorySpeaker.Cousin, "Oh you saved me");
          yield return new NarrationEvent(Story.StorySpeaker.Aunt, "It's too dangerous in here let's leave");
          Context.CousinSaved = true;
        }
        else
        {
          yield return new NarrationEvent(Story.StorySpeaker.Cousin, "Oh no I'm beaten");
          yield return new NarrationEvent(Story.StorySpeaker.Narrator, "She seems really really bad...");
          yield return new EndEvent("Cousin died", EndEventType.GameOver);
        }
      }
      else if (choiceEvent.PlayerChoice.Text == SnakeChoiceEventInfo.LookDown.Text)
      {
        yield return new NarrationEvent(Story.StorySpeaker.Aunt, "Why did you move you asshole !");
        yield return new NarrationEvent(Story.StorySpeaker.Narrator, "The snake bite your cousin !");
      }

      yield return new EndEvent("Victory", EndEventType.Victory);
    }
  }

  public class SnakeChoiceEventInfo : IChoiceEventInfo
  {
    public string Name => "Snake Event";
    public static ChoiceOption HoldStill => new ChoiceOption("Hold still");
    public static ChoiceOption LookDown => new ChoiceOption("Look down");
    
    public List<ChoiceOption> Choices => new List<ChoiceOption>() {HoldStill, LookDown};
  }
}
