using System.IO;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.ListOfEventsTests
{
  class ListOfEventsTests : DeserializeToolsTests
  {
    public class DeserializeMethod : ListOfEventsTests
    {
      [Test]
      [Ignore("Pending")]
      public void OnlyNarrativeEvents()
      {
        var testFilePath = Path.Combine(BasePath, "Scenes", "OnlyNarrative.xml");
        ListOfEvents listOfEvents;
        using (TextReader reader = new StreamReader(testFilePath))
          listOfEvents = ListOfEvents.Deserialize(reader);

        foreach (var sceneEvent in listOfEvents)
        {
          Assert.IsInstanceOf<NarrativeEvent>(sceneEvent);
          Assert.IsTrue(sceneEvent.Valid());
        }

        var event1 = (NarrativeEvent) listOfEvents[0];
        Assert.AreEqual(event1.Speaker, "King");
        Assert.AreEqual(event1.Text, "The King is speaking");

        var event2 = (NarrativeEvent)listOfEvents[1];
        Assert.AreEqual(event2.Speaker, "Princess");
        Assert.AreEqual(event2.Text, "The Princess is speaking");

        var event3 = (NarrativeEvent)listOfEvents[2];
        Assert.AreEqual(event3.Speaker, "Narrator");
        Assert.AreEqual(event3.Text, "The Narrator is speaking");
      }

      [Test]
      [Ignore("Pending")]
      public void OnlyChoicesEvents()
      {
        var testFilePath = Path.Combine(BasePath, "Scenes", "OnlyChoices.xml");
        ListOfEvents listOfEvents;
        using (TextReader reader = new StreamReader(testFilePath))
          listOfEvents = ListOfEvents.Deserialize(reader);

        foreach (var sceneEvent in listOfEvents)
        {
          Assert.IsInstanceOf<ChoiceEvent>(sceneEvent);
          Assert.IsTrue(sceneEvent.Valid());
        }
      }
    }
  }
}
