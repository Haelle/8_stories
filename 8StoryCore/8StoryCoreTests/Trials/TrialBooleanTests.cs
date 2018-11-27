using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Trials;
using _8StoryCoreTests.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Trials.BooleanTests
{
  class TrialBooleanTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      TrialBoolean LoadTrial(string testFilePath)
      {
        TrialBoolean trial;
        var deserializer = new XmlSerializer(typeof(TrialBoolean));
        using (TextReader reader = new StreamReader(testFilePath))
          trial = (TrialBoolean)deserializer.Deserialize(reader);
        return trial;
      }

      [Test]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialBooleanValid.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsTrue(trial.Valid());
        Assert.IsTrue(trial.Objective);
        CollectionAssert.AreEqual(new List<string>(){ "HasMetMagician", "HasMagicWand" }, trial.Properties);
      }

      [Test]
      public void InvalidWithoutObjective()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialBooleanInvalidObjective.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsNull(trial.Objective);
      }

      [Test]
      public void InvalidWithPropertiesEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialBooleanInvalidPropertiesEmpty.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsEmpty(trial.Properties);
      }

      [Test]
      public void InvalidWithPropertiesError()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialBooleanInvalidPropertiesError.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsEmpty(trial.Properties[1]);
      }
    }
  }
}
