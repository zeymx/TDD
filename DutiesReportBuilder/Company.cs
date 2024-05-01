using System.Xml.Serialization;
using System.Xml;


[XmlRoot("company")]
public class Company : ICompany
{
    public List<string> problems;
    //public int problemCount = 0, vacationCount = 0, sickleaveCount = 0;
    [XmlArray("teams")]
    [XmlArrayItem("team")]
    public List<Team> Teams { get; set; }
    [XmlArray("dutyschedule")]
    [XmlArrayItem("duty")]
    public List<Duty> DutySchedule { get; set; }
    [XmlIgnore]
    public ShiftSchedule companySchedule { get; set; }
    public Company() 
    {
        problems = new List<string>();
        Teams = new List<Team>();
        DutySchedule = new List<Duty>();
        companySchedule = new ShiftSchedule();
    }
    public void Import(string fileName)
    {
        XmlReader reader = new XmlTextReader(fileName);
        XmlSerializer serializer = new XmlSerializer(typeof(Company));
        Company company = (Company)serializer.Deserialize(reader);
        this.Teams = company.Teams;
        this.DutySchedule = company.DutySchedule;
    }
    public void Process() 
    {
        foreach (Duty duty in this.DutySchedule)
        {
            companySchedule.AddShift(new Shift(duty.DateStart, duty.DateEnd, duty.Member, duty.Task));
        }
        
        foreach (DateTime date in companySchedule.schedule.Keys) {
            foreach (Team team in Teams)
                foreach (Person person in team.persons) {
                    if (companySchedule.schedule[date][person.name].Count > 1)
                    {
                        string problem = "";
                        problem += $"{person.name} одновременно дежурит ";
                        foreach (Shift shift in companySchedule.schedule[date][person.name])
                            problem += $"на {shift.TaskName}, ";
                        problem += $"{date.Day}.{date.Month}";
                        problems.Add(problem);
                    }

                }
        }
    }
}