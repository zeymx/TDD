using System.Xml.Serialization;

public class DateRange
{
    [XmlElement("start")]
    public string Start { get; set; }

    [XmlElement("end")]
    public string End { get; set; }
}
