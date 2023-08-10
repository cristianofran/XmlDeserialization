using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Xml.Serialization;
using XmlDeserialization.Dominio.Entidades;

namespace XmlDeserialization.Tests
{
    [TestClass]
    public class XmlDeserializationTest
    {
        [TestMethod]
        public void Deserialize_Simple()
        {
            var expectedPerson = new Person { Name = "John Doe", Age = 30};
            var xmlData = "<Person>" +
                              "<Name>John Doe</Name>" +
                              "<Age>30</Age>" +
                          "</Person>";
            
            var person = DeserializeXmlData<Person>(xmlData);
            
            Assert.IsNotNull(person);
            Assert.AreEqual(expectedPerson.Name, person.Name);
            Assert.AreEqual(expectedPerson.Age, person.Age);
        }

        [TestMethod]
        public void Deserialize_Complex()
        {
            var complexXML = "<Library>" +
                                "<Books>" +
                                    "<Book>" +
                                        "<Title>Book 1</Title>" +
                                        "<Author>Author 1</Author>" +
                                    "</Book>" +
                                    "<Book>" +
                                        "<Title>Book 2</Title>" +
                                        "<Author>Author 2</Author>" +
                                    "</Book>" +
                                "</Books>" +
                            "</Library>";

            var library = DeserializeXmlData<Library>(complexXML);

            Assert.IsNotNull(library);
            Assert.IsNotNull(library.Books);
            Assert.AreEqual(2, library.Books.Count);

            Assert.AreEqual("Book 1", library.Books[0].Title);
            Assert.AreEqual("Author 1", library.Books[0].Author);

            Assert.AreEqual("Book 2", library.Books[1].Title);
            Assert.AreEqual("Author 2", library.Books[1].Author);
        }

        [TestMethod]
        public void Deserialize_File()
        {
            var expectedPerson = new Person { Name = "John Doe", Age = 30 };

            var serializer = new XmlSerializer(typeof(Person));
            using var stream = new FileStream("data.xml", FileMode.Open);
            var person = (Person)serializer.Deserialize(stream);

            Assert.IsNotNull(person);
            Assert.AreEqual(expectedPerson.Name, person.Name);
            Assert.AreEqual(expectedPerson.Age, person.Age);
        }

        private T DeserializeXmlData<T>(string xmlData)
        {
            var serializer = new XmlSerializer(typeof(T));
            using var reader = new StringReader(xmlData);
            return (T)serializer.Deserialize(reader);
        }
    }
}
