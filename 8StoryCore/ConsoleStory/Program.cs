using System;
using System.Collections.Generic;
using System.Linq;
using _8StoryCore;
using _8StoryCore.Events;
using _8StoryCore.Events.Choice;
using _8StoryCore.Events.Narrative;

namespace ConsoleStory
{
  class Program
  {
    class PlayerContext : IPlayerContext { }

    static void Main(string[] args)
    {
      var playerContext = new PlayerContext();
      var firstEvent = new NarrativeEvent(new StartingEventInfo());
      var firstScene = new StoryScene<PlayerContext>(firstEvent, playerContext);
      var engine = new StoryEngine<PlayerContext>(playerContext, firstScene);

      while (engine.StoryStatus != StoryStatus.Ended)
      {
        var currentScene = engine.NextScene();
        while (currentScene.SceneStatus != SceneStatus.Ended)
        {
          var currentEvent = currentScene.NextEvent();

          switch (currentEvent)
          {
            case NarrativeEvent _:
              var narrativeEvent = (NarrativeEvent) currentEvent;
              foreach (var narrativeResult in narrativeEvent.PlayEvent(playerContext))
                Console.WriteLine(narrativeResult.Text);

              break;
            case ChoiceEvent _:
              var choiceEvent = (ChoiceEvent) currentEvent;
              Console.WriteLine("Waiting for player choice");
              // TODO: have a foreach with index ?
              for (var i = 0; i < choiceEvent.Choices.Count(); i++)
              {
                var choice = choiceEvent.Choices[i];
                Console.WriteLine("{0}. {1}", i, choice.Text);
              }

              var input = Console.ReadLine();
              var intInput = short.Parse(input ?? throw new InvalidOperationException());
              if (intInput > choiceEvent.Choices.Count) throw new ArgumentOutOfRangeException("Choice not available !");

              choiceEvent.Choose(choiceEvent.Choices[intInput], playerContext);
              break;
            case EndEvent _:
              Console.WriteLine("Scene Ended");
              break;
            default:
              throw new InvalidCastException("unexpected child class");
          }
        }
      }

      Console.WriteLine("Story Ended");
    }
  }

  internal class StartingEventInfo : INarrativeEventInfo
  {
    public IEnumerable<EventResult> GetResults(IPlayerContext context)
    {
      throw new NotImplementedException();
    }

    public EventType Type { get; }
  }
}