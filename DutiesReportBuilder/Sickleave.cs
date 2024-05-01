using System.Xml.Serialization;
class Sickleave
{
    [XmlElement("start")]
    DateTime start;
    [XmlElement("end")]
    DateTime end;
    Person person;
}