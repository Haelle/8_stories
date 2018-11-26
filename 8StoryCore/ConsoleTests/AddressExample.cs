using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace ConsoleTests
{
  public class AddressExample
  {
    public static void RunSerialize()
    {
      AddressDetails details = new AddressDetails();
      details.HouseNo = 4;
      details.StreetName = "Rohini";
      details.City = "Delhi";
      Serialize(details);
    }

    public static void RunDeserializeList()
    {
      string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      var filePath = wantedPath + "\\Xml\\AddressDeserializeList.xml";

      XmlSerializer deserializer = new XmlSerializer(typeof(AddressDirectory));
      TextReader reader = new StreamReader(filePath);
      object obj = deserializer.Deserialize(reader);
      AddressDirectory XmlData = (AddressDirectory)obj;
      reader.Close();
    }

    public static void RunDeserialize()
    {
      string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      var filePath = wantedPath + "\\Xml\\AddressDeserialize.xml";

      XmlSerializer deserializer = new XmlSerializer(typeof(Address));
      TextReader reader = new StreamReader(filePath);
      object obj = deserializer.Deserialize(reader);
      Address XmlData = (Address)obj;
      reader.Close();
    }

    static public void Serialize(AddressDetails details)
    {
      string wantedPath = Path.GetDirectoryName(Path.GetDirectoryName(System.IO.Directory.GetCurrentDirectory()));
      var filePath = wantedPath + "\\Xml\\AddressSerialize.xml";

      XmlSerializer serializer = new XmlSerializer(typeof(AddressDetails));
      using (TextWriter writer = new StreamWriter(filePath))
      {
        serializer.Serialize(writer, details);
      }
    }

    public class AddressDetails
    {
      public int HouseNo { get; set; }
      public string StreetName { get; set; }
      public string City { get; set; }
      private string PoAddress { get; set; }
    }

    public class AddressDirectory
    {
      [XmlElement("DirectoryOwner")]
      public string Owner { get; set; }
      [XmlElement("PinCode")]
      public string PinCode { get; set; }
      [XmlElement("Address")]
      public List<Address> Address { get; set; }
      [XmlElement("Designation")]
      public Designation designation { get; set; }
    }

    public class Designation
    {
      [XmlAttribute("place")]
      public string place { get; set; }
      [XmlText]
      public string JobType { get; set; }
    }

    public class Address
    {
      [XmlAttribute("AddressId")]
      public string AddressId { get; set; }
      [XmlElement("HouseNo")]
      public string Number { get; set; }
      [XmlElement("StreetName")]
      public string StreetName { get; set; }
      [XmlElement("City")]
      public string City { get; set; }
    }
  }
}