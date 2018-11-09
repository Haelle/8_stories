using System;
using System.Collections.Generic;
using NUnit.Framework;
using _8StoryCore;
using _8StoryCore.Events.Choice;
using _8StoryCore.Events.Choice.Options;

namespace _8StoryCoreTests.Events.Choice
{
  public class ChoiceEventTests
  {
    private ChoiceEvent _choiceEvent;

    [SetUp]
    public void BeforeAll()
    {
      var choiceInfo = new DummyChoiceEventInfo();
      _choiceEvent = new ChoiceEvent(choiceInfo);
    }

    public class ChoicesAttributes : ChoiceEventTests
    {
      [Test]
      public void It_has_3_choices()
      {
        var choiceInfo = new DummyChoiceEventInfo();
        var choiceEvent = new ChoiceEvent(choiceInfo);

        Assert.AreEqual(choiceEvent.Choices.Count, 3);
      }
    }

    public class ChooseMethod : ChoiceEventTests
    {
      [Test]
      public void Throw_exception_if_choice_is_null()
      {
        Assert.Throws<ArgumentNullException>(() => _choiceEvent.Choose(null, new DummyContext()));
      }

      [Test]
      public void Throw_exception_if_context_is_null()
      {
        var firstChoice = _choiceEvent.Choices[0];

        Assert.Throws<ArgumentNullException>(() => _choiceEvent.Choose(firstChoice, null));
      }

      [Test]
      public void Choose_option_one()
      {
        var firstChoice = _choiceEvent.Choices[0];

        Assert.IsTrue(_choiceEvent.Choose(firstChoice, new DummyContext()));
        Assert.AreEqual(_choiceEvent.CurrentChoice, firstChoice);
      }

      [Test]
      public void Returns_false_if_choice_not_in_the_list()
      {
        var newChoice = new AlwaysTrueOption("Yeah !");

        Assert.IsFalse(_choiceEvent.Choose(newChoice, new DummyContext()));
        Assert.IsNull(_choiceEvent.CurrentChoice);
      }

      [Test]
      public void Returns_false_if_player_cannot_choose_it()
      {
        var choiceInfo = new FailChoiceEventInfo();
        var choiceEvent = new ChoiceEvent(choiceInfo);
        var unavailableChoice = choiceEvent.Choices[0];

        Assert.IsFalse(choiceEvent.Choose(unavailableChoice, new DummyContext()));
        Assert.IsNull(choiceEvent.CurrentChoice);
      }

      [Test]
      public void Returns_true_if_player_passes_condition()
      {
        var choiceInfo = new CheckChoiceEventInfo();
        var choiceEvent = new ChoiceEvent(choiceInfo);
        var firstChoice = choiceEvent.Choices[0];

        Assert.IsTrue(choiceEvent.Choose(firstChoice, new DummyContext()));
        Assert.AreEqual(choiceEvent.CurrentChoice, firstChoice);
      }
    }
  }

  class DummyContext : IPlayerContext
  {
    public int Strength => 25;
  }

  class CheckChoiceEventInfo : IChoiceEventInfo
  {
    public List<IChoiceOption> Choices => new List<IChoiceOption>() { new ConditionalOption("Yeah !", (ctx) => ((DummyContext)ctx).Strength > 10) };
  }

  class FailChoiceEventInfo : IChoiceEventInfo
  {
    public List<IChoiceOption> Choices => new List<IChoiceOption>() { new ConditionalOption("Yeah !", (ctx) => false) };
  }

  class DummyChoiceEventInfo : IChoiceEventInfo 
  {
    public List<IChoiceOption> Choices => new List<IChoiceOption>() { new AlwaysTrueOption("1"), new AlwaysTrueOption("2"), new AlwaysTrueOption("3") };
  }
}