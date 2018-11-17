using System;
using _8StoryCore;
using _8StoryCore.Events;

namespace ConsoleStory
{
  class Program
  {
    static void Main(string[] args)
    {
      var story = new Story();
      // TODO: check story integrity
      // TODO: all scenes are logical (define logical...) (no same scene name, choice name etc...)
      var engine = new StoryEngine(story);

      while (story.Status != StoryStatus.Ended)
      {
        Console.WriteLine("Choose what you want to do:");
        // TODO: raise error if empty and story not ended !
        var availableScenes = engine.AvailableScenes();
        for (var i = 0; i < availableScenes.Count; i++)
        {
          var scene = availableScenes[i];
          Console.WriteLine("{0}. {1}", i, scene.Name);
        }

        var inputScene = Console.ReadLine();
        var intInputScene = short.Parse(inputScene ?? throw new InvalidOperationException());
        var selectedScene = availableScenes[intInputScene];
        PlayScene(engine, selectedScene);

        // TODO: raise error if more than one mandatory scene
        var mandatoryScene = engine.MandatoryScene();
        if (mandatoryScene != null) PlayScene(engine, mandatoryScene);

        Console.ReadKey();
      }

      Console.WriteLine("Story Ended");
    }

    private static void PlayScene(StoryEngine engine, StoryScene selectedScene)
    {
      // TODO: raise error if no more scene and not ended
      foreach (var currentEvent in selectedScene.NextEvent())
      {
        switch (currentEvent)
        {
          case NarrationEvent _:
            var narrationEvent = (NarrationEvent)currentEvent;
            Console.WriteLine("{0}: {1}", narrationEvent.Speaker.ToString(), narrationEvent.Text);
            break;

          case ChoiceEvent _:
            var choiceEvent = (ChoiceEvent)currentEvent;
            Console.WriteLine("Waiting for player choice");
            // TODO : foreach with index ?
            for (var i = 0; i < choiceEvent.Choices.Count; i++)
            {
              var choice = choiceEvent.Choices[i];
              Console.WriteLine("{0}. {1}", i, choice.Text);
            }

            var input = Console.ReadLine();
            var intInput = short.Parse(input ?? throw new InvalidOperationException());
            choiceEvent.Choose(choiceEvent.Choices[intInput], engine.Context);
            break;

          case NotificationEvent _:
            var notification = (NotificationEvent)currentEvent;
            Console.WriteLine("Notification: {0}", notification.Text);
            break;

          case TestEvent _:
            var test = (TestEvent)currentEvent;
            Console.WriteLine("Test: {0}", test.ResultInfo);
            break;

          case EndEvent _:
            var endEvent = (EndEvent)currentEvent;
            Console.WriteLine("Scene Ended: {0} - {1}", endEvent.Name, endEvent.EndType);
            break;
        }
      }
    }
  }
}