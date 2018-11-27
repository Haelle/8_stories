using System;
using System.IO;
using System.Xml.Serialization;
using NUnit.Framework;
using _8StoryCore.Events;

namespace _8StoryCoreTests.Events.NotificationTests
{
  class NotificationEventTests
  {
    class DeserializeMethod : DeserializeToolsTests
    {
      NotificationEvent LoadEvent(string testFilePath)
      {
        NotificationEvent notification;
        var deserializer = new XmlSerializer(typeof(NotificationEvent));
        using (TextReader reader = new StreamReader(testFilePath))
          notification = (NotificationEvent)deserializer.Deserialize(reader);
        return notification;
      }

      [Test]
      public void IsValid()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Notification", "NotificationValid.xml");
        var notificationEvent = LoadEvent(testFilePath);
        Assert.IsTrue(notificationEvent.Valid());
        Assert.AreEqual(NotificationType.Normal, notificationEvent.Type);
        Assert.AreEqual("This is a notification", notificationEvent.Text);
      }

      [Test]
      public void InvalidWithTypeEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Notification", "NotificationInvalidTypeEmpty.xml");
        Assert.Throws<InvalidOperationException>(() => LoadEvent(testFilePath));
      }

      [Test]
      public void InvalidWithoutType()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Notification", "NotificationInvalidType.xml");
        var notificationEvent = LoadEvent(testFilePath);

        Assert.IsFalse(notificationEvent.Valid());
        Assert.IsNull(notificationEvent.Type);
      }

      [Test]
      public void InvalidWithTextEmpty()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Notification", "NotificationInvalidTextEmpty.xml");
        var notificationEvent = LoadEvent(testFilePath);

        Assert.IsFalse(notificationEvent.Valid());
        Assert.IsEmpty(notificationEvent.Text);
      }

      [Test]
      public void InvalidWithoutText()
      {
        var testFilePath = Path.Combine(BasePath, "Events", "Notification", "NotificationInvalidText.xml");
        var notificationEvent = LoadEvent(testFilePath);

        Assert.IsFalse(notificationEvent.Valid());
        Assert.IsNull(notificationEvent.Text);
      }
    }
  }
}
