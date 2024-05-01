using System.Xml.Serialization;

public class Duty
{
    [XmlElement("date_start")]
    public DateTime DateStart { get; set; }

    [XmlElement("date_end")]
    public DateTime DateEnd { get; set; }

    [XmlElement("task")]
    public string Task { get; set; }

    [XmlElement("person")]
    public string Member { get; set; }
}