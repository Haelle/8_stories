using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace _8StoryCore.Events
{
  public class ListOfEvents : List<ISceneEvent>, IXmlSerializable
  {
    public static ListOfEvents Deserialize(TextReader reader)
    {
      var deserializer = new XmlSerializer(typeof(ListOfEvents));
      return (ListOfEvents)deserializer.Deserialize(reader);
    }

    #region IXmlSerializable

    public XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      reader.ReadStartElement("ListOfEvents");
      while (reader.IsStartElement("ISceneEvent"))
      {
        var type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
        var serializer = new XmlSerializer(type);
        reader.ReadStartElement("ISceneEvent");
        var sceneEvent = (ISceneEvent) serializer.Deserialize(reader);
        this.Add(sceneEvent);
        reader.ReadEndElement();
      }

      reader.ReadEndElement();
    }

    public void WriteXml(XmlWriter writer)
    {
      throw new NotImplementedException();
    }
    #endregion
  }
}