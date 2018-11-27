using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Trials;
using _8StoryCoreTests.Events;

// ReSharper disable once CheckNamespace
namespace _8StoryCoreTests.Trials.ScoreTests
{
  class TrialScoreTests
  {
    [Category("XML")]
    class DeserializeMethod : DeserializeToolsTests
    {
      TrialScore LoadTrial(string testFilePath)
      {
        TrialScore trial;
        var deserializer = new XmlSerializer(typeof(TrialScore));
        using (TextReader reader = new StreamReader(testFilePath))
          trial = (TrialScore)deserializer.Deserialize(reader);
        return trial;
      }

      [Test]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialScoreValid.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsTrue(trial.Valid());
        Assert.AreEqual(75, trial.Objective);
        Assert.AreEqual(50, trial.PartialObjective);
        CollectionAssert.AreEqual(new List<string>(){ "Athletic", "Climbing" }, trial.Properties);
      }

      [Test]
      public void IsValidWithMinimalInfos()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialScoreValidMinimal.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsTrue(trial.Valid());
        Assert.AreEqual(75, trial.Objective);
        CollectionAssert.AreEqual(new List<string>() { "Athletic" }, trial.Properties);
      }

      [Test]
      public void InvalidWithoutObjective()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialScoreInvalidObjective.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsNull(trial.Objective);
      }

      [Test]
      public void InvalidWithPropertiesEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialScoreInvalidPropertiesEmpty.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsEmpty(trial.Properties);
      }

      [Test]
      public void InvalidWithPropertiesError()
      {
        var testFilePath = Path.Combine(BasePath, "Trials", "TrialScoreInvalidPropertiesError.xml");
        var trial = LoadTrial(testFilePath);

        Assert.IsFalse(trial.Valid());
        Assert.IsEmpty(trial.Properties[0]);
      }
    }
  }
}
