using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Events.ChoiceTests
{
  class ChoiceOptionTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      ChoiceOption LoadOption(string testFilePath)
      {
        ChoiceOption option;
        var deserializer = new XmlSerializer(typeof(ChoiceOption));
        using (TextReader reader = new StreamReader(testFilePath))
          option = (ChoiceOption)deserializer.Deserialize(reader);
        return option;
      }

      [Test]
      [Ignore("Pending")]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Options", "Valid.xml");
        var option = LoadOption(testFilePath);

        Assert.IsTrue(option.Valid());
        Assert.AreEqual("Try to climb", option.Text);
        foreach (var consecutiveEvent in option.XmlConsecutiveEvents)
        {
          Assert.IsInstanceOf<ISceneEvent>(consecutiveEvent);
          Assert.IsTrue(consecutiveEvent.Valid());
        }
      }

      [Test]
      [Ignore("Pending")]
      public void Invalid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "OptionInvalid.xml");
        var endEvent = LoadOption(testFilePath);

        Assert.IsFalse(endEvent.Valid());
      }
    }
  }
}
