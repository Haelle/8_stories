using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;
using _8StoryCore.Events;

namespace _8StoryCoreTests.Events
{
  public class EndEventTests
  {
    [Test]
    public void It_is_the_ending_event()
    {
      Assert.AreEqual(new EndEvent().Type, EventType.Ending);
    }

    [Test]
    public void It_has_no_next_event()
    {
      Assert.IsNull(new EndEvent().NextEvent);
    }
  }
}
