using System;
using System.IO;
using System.Xml;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.ListOfEventsTests
{
  class ListOfEventsTests : DeserializeToolsTests
  {
    [Category("XML")]
    class DeserializeMethod : ListOfEventsTests
    {
      private ListOfEvents LoadList(string testFilePath)
      {
        ListOfEvents listOfEvents;
        using (TextReader reader = new StreamReader(testFilePath))
          listOfEvents = ListOfEvents.Deserialize(reader);

        return listOfEvents;
      }

      [Test]
      public void OnlyNarrativeEvents()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "ValidOnlyNarrative.xml");
        var listOfEvents = LoadList(testFilePath);

        foreach (var sceneEvent in listOfEvents)
        {
          Assert.IsInstanceOf<NarrativeEvent>(sceneEvent);
          Assert.IsTrue(sceneEvent.Valid());
        }
      }

      [Test]
      public void VariousKindOfEvents()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "ValidVariousEvents.xml");
        var listOfEvents = LoadList(testFilePath);

        foreach (var sceneEvent in listOfEvents)
        {
          Assert.IsInstanceOf<ISceneEvent>(sceneEvent);
          Assert.IsTrue(sceneEvent.Valid());
        }
      }

      [Test]
      public void InvalidIfOneEventInvalid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "InvalidOneEvent.xml");
        var listOfEvents = LoadList(testFilePath);

        Assert.IsFalse(listOfEvents[1].Valid());
      }

      [Test]
      public void ThrowExceptionIfMisspellKey()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "InvalidMisspellKey.xml");
        var ex = Assert.Throws<InvalidOperationException>(() => LoadList(testFilePath));
        Assert.That(ex.InnerException, Is.TypeOf<XmlException>());
      }

      [Test]
      public void ThrowExceptionIfInvalidType()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "InvalidInvalidType.xml");
        var ex = Assert.Throws<InvalidOperationException>(() => LoadList(testFilePath));
        Assert.That(ex.InnerException, Is.TypeOf<ArgumentNullException>());
      }

      [Test]
      public void ThrowExceptionIfInconsistentType()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "ListOfEvents", "InvalidInconsistentType.xml");
        var ex = Assert.Throws<InvalidOperationException>(() => LoadList(testFilePath));
        Assert.That(ex.InnerException, Is.TypeOf<InvalidOperationException>());
      }
    }
  }
}
