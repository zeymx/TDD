using System.Xml.Serialization;
class Vacation 
{
    [XmlElement("start")]
    DateTime start;
    [XmlElement("end")]
    DateTime end;
    Person owner;
}