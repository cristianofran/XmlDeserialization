using System.Xml.Serialization;

namespace XmlDeserialization.Dominio.Entidades
{
    public class Book
    {
        [XmlElement("Title")]
        public string Title { get; set; }

        [XmlElement("Author")]
        public string Author { get; set; }
    }
}
