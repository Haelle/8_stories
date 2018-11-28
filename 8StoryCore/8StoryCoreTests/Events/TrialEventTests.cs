using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.TrialTests
{
  class TrialEventTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      TrialEvent LoadTrial(string testFilePath)
      {
        TrialEvent trialEvent;
        var deserializer = new XmlSerializer(typeof(TrialEvent));
        using (TextReader reader = new StreamReader(testFilePath))
          trialEvent = (TrialEvent)deserializer.Deserialize(reader);
        return trialEvent;
      }

      [Test]
      public void Valid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Trial", "TrialValid.xml");
        var trialEvent = LoadTrial(testFilePath);

        Assert.IsTrue(trialEvent.Valid());
      }
    }
  }
}
