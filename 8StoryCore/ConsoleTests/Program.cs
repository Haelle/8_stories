using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace ConsoleTests
{
  class Program
  {
    public static void Main(string[] args)
    {
      // basic without interface ;)
      //AddressExample.RunDeserializeList();
      //AddressExample.RunSerialize();
      //AddressExample.RunDeserialize();

      SerialiseInterface.DeserializeAnimals();
    }
  }
}
