using System.Xml.Serialization;

public class Team
{
    [XmlAttribute("name")]
    public string name;
    [XmlArray("persons")]
    [XmlArrayItem("person")]
    public List<Person> persons {get; set;}
}