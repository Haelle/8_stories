using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace ConsoleTests
{
  static class SerialiseInterface
  {
    public static void SerialiseAnimals()
    {
      string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      var filePath = wantedPath + "\\Xml\\InterfaceSerialize.xml";
      
      var animals = new ListOfIAnimal
      {
        new Dog() {Age = 5, Teeth = 30},
        new Cat() {Age = 6, Paws = 4}
      };
      
      var xmlSerializer = new XmlSerializer(animals.GetType());
      using (TextWriter writer = new StreamWriter(filePath))
      {
        xmlSerializer.Serialize(writer, animals);
      }
    }

    public static void DeserializeAnimals()
    {
      string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      var filePath = wantedPath + "\\Xml\\InterfaceSerialize.xml";

      XmlSerializer deserializer = new XmlSerializer(typeof(ListOfIAnimal));
      TextReader reader = new StreamReader(filePath);
      object obj = deserializer.Deserialize(reader);
      ListOfIAnimal XmlData = (ListOfIAnimal)obj;
      reader.Close();
    }
  }

  public class ListOfIAnimal : List<IAnimal>, IXmlSerializable
  {
    public ListOfIAnimal() : base()
    {
    }

    #region IXmlSerializable

    public System.Xml.Schema.XmlSchema GetSchema()
    {
      return null;
    }

    public void ReadXml(XmlReader reader)
    {
      reader.ReadStartElement("ListOfIAnimal");
      while (reader.IsStartElement("IAnimal"))
      {
        Type type = Type.GetType(reader.GetAttribute("AssemblyQualifiedName"));
        XmlSerializer serial = new XmlSerializer(type);

        reader.ReadStartElement("IAnimal");
        this.Add((IAnimal) serial.Deserialize(reader));
        reader.ReadEndElement(); //IAnimal
      }

      reader.ReadEndElement(); //ListOfIAnimal
    }

    public void WriteXml(XmlWriter writer)
    {
      foreach (IAnimal animal in this)
      {
        writer.WriteStartElement("IAnimal");
        writer.WriteAttributeString("AssemblyQualifiedName", animal.GetType().AssemblyQualifiedName);
        XmlSerializer xmlSerializer = new XmlSerializer(animal.GetType());
        xmlSerializer.Serialize(writer, animal);
        writer.WriteEndElement();
      }
    }

    #endregion
  }

  public interface IAnimal
  {
    int Age { get; set; }
  }

  public class Dog : IAnimal
  {
    public int Age { get; set; }
    public int Teeth { get; set; }
  }

  public class Cat : IAnimal
  {
    public int Age { get; set; }
    public int Paws { get; set; }
  }
}