using System.Xml.Serialization;

public class Person
{
    [XmlArray("vacations")]
    [XmlArrayItem("vacation")]
    List<Vacation> vacations;
    [XmlArray("sickleaves")]
    [XmlArrayItem("sickleave")]
    List<Sickleave> sickleaves;
    [XmlArray("services")]
    [XmlArrayItem("service")]
    List<Service> services;
    [XmlElement("name")]
    public string name;
}