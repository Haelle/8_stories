using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.NarrativeTests
{
  class NarrativeEventTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      NarrativeEvent LoadEvent(string testFilePath)
      {
        NarrativeEvent narrative;
        var deserializer = new XmlSerializer(typeof(NarrativeEvent));
        using (TextReader reader = new StreamReader(testFilePath))
          narrative = (NarrativeEvent)deserializer.Deserialize(reader);
        return narrative;
      }

      [Test]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Narrative", "NarrativeValid.xml");
        var narrative = LoadEvent(testFilePath);
        Assert.IsTrue(narrative.Valid());
        Assert.AreEqual("King", narrative.Speaker);
        Assert.AreEqual("The King is speaking", narrative.Text);
      }

      [Test]
      public void InvalidWithEmptySpeaker()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Narrative", "NarrativeInvalidSpeakerEmpty.xml");
        var narrative = LoadEvent(testFilePath);

        Assert.IsFalse(narrative.Valid());
        Assert.IsEmpty(narrative.Speaker);
      }

      [Test]
      public void InvalidWithoutSpeaker()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Narrative", "NarrativeInvalidSpeaker.xml");
        var narrative = LoadEvent(testFilePath);
        
        Assert.IsFalse(narrative.Valid());
        Assert.IsNull(narrative.Speaker);
      }

      [Test]
      public void InvalidWithoutText()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Narrative", "NarrativeInvalidText.xml");
        var narrative = LoadEvent(testFilePath);

        Assert.IsFalse(narrative.Valid());
        Assert.IsNull(narrative.Text);
      }

      [Test]
      public void InvalidWithTextEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Narrative", "NarrativeInvalidTextEmpty.xml");
        var narrative = LoadEvent(testFilePath);

        Assert.IsFalse(narrative.Valid());
        Assert.IsEmpty(narrative.Text);
      }
    }
  }
}
