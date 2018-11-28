using System;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.EndTests
{
  class EndEventTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      EndEvent LoadEvent(string testFilePath)
      {
        EndEvent endEvent;
        var deserializer = new XmlSerializer(typeof(EndEvent));
        using (TextReader reader = new StreamReader(testFilePath))
          endEvent = (EndEvent)deserializer.Deserialize(reader);
        return endEvent;
      }

      [Test]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "End", "EndValid.xml");
        var endEvent = LoadEvent(testFilePath);

        Assert.IsTrue(endEvent.Valid());
        Assert.AreEqual("You are dead", endEvent.Text);
        Assert.AreEqual(EndEventType.GameOver, endEvent.Type);
      }

      [Test]
      public void InvalidWithTextEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "End", "EndInvalidTextEmpty.xml");
        var endEvent = LoadEvent(testFilePath);

        Assert.IsFalse(endEvent.Valid());
        Assert.IsEmpty(endEvent.Text);
      }

      [Test]
      public void InvalidWithoutText()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "End", "EndInvalidText.xml");
        var endEvent = LoadEvent(testFilePath);

        Assert.IsFalse(endEvent.Valid());
        Assert.IsNull(endEvent.Text);
      }

      [Test]
      public void InvalidWithTypeEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "End", "EndInvalidTypeEmpty.xml");
        Assert.Throws<InvalidOperationException>(() => LoadEvent(testFilePath));
      }

      [Test]
      public void InvalidWithoutType()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "End", "EndInvalidType.xml");
        var endEvent = LoadEvent(testFilePath);

        Assert.IsFalse(endEvent.Valid());
        Assert.IsNull(endEvent.Type);
      }
    }
  }
}
