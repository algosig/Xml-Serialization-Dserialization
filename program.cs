using System;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;

namespace Reflection
{
	public class XMLWrite
	{

		static void Main(string[] args)
		{
			WriteXML();
			ReadXML();
		}


		public class World
		{
			public string Country;
			public string CountryName;
			public string Capital;
		}


		public static void WriteXML()
		{
			World name = new World();
			name.Country = "Country";
			Console.WriteLine("Enter Country Name:");
			name.CountryName = Console.ReadLine();
			Console.WriteLine("Enter Capital Name");
			name.Capital = Console.ReadLine();
			XmlSerializer writer = new XmlSerializer(typeof(World));
			var path = Directory.GetCurrentDirectory() + "//CountryNames.xml";
			FileStream file = System.IO.File.Create(path);

			writer.Serialize(file, name);
			file.Close();
		}


		public static void ReadXML()
		{
			System.Xml.Serialization.XmlSerializer reader =
				new System.Xml.Serialization.XmlSerializer(typeof(World));
			System.IO.StreamReader file = 
				new System.IO.StreamReader(Directory.GetCurrentDirectory() + "\\CountryNames.xml");
			World overview = (World)reader.Deserialize(file);
			file.Close();

			Console.WriteLine(overview.CountryName);
			string Country = overview.Country;
			Console.WriteLine(Country);
			string Capital = overview.Capital;
			Console.WriteLine(Capital);
			Console.ReadLine();

		}
	}
}
