using System.Collections.Generic;
using System.Xml.Serialization;

namespace XmlDeserialization.Dominio.Entidades
{
    [XmlRoot("Library")]
    public class Library
    {
        [XmlArray("Books")]
        [XmlArrayItem("Book")]
        public List<Book> Books { get; set; }
    }
}
