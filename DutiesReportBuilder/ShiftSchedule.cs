public class Shift
{
    public DateTime StartTime { get; set; }
    public DateTime EndTime { get; set; }
    public string EmployeeName { get; set; }
    public string TaskName { get; set; }
    public Shift(DateTime startTime, DateTime endTime, string employeeName, string taskName)
    {
        StartTime = startTime;
        EndTime = endTime;
        EmployeeName = employeeName;
        TaskName = taskName;
    }
}

public class ShiftSchedule
{
    public Dictionary<DateTime, Dictionary<string, List<Shift>>> schedule;

    public ShiftSchedule()
    {
        schedule = new Dictionary<DateTime, Dictionary<string, List<Shift>>>();
    }

    public void AddShift(Shift shift)
    {
        TimeSpan duration = shift.EndTime - shift.StartTime;
        for (int i = 0; i < duration.Days; i++) {
            DateTime currentDate = shift.StartTime + new TimeSpan(i, 0, 0, 0);
            if (!schedule.ContainsKey(currentDate))
                schedule[currentDate] = new Dictionary<string, List<Shift>>();
            if (!schedule[currentDate].ContainsKey(shift.EmployeeName))
                schedule[currentDate][shift.EmployeeName] = new List<Shift>();
            schedule[currentDate][shift.EmployeeName].Add(shift);
        }
    }

    public List<Shift> GetShiftsForDate(DateTime date)
    {
        if (schedule.ContainsKey(date))
        {
            List<Shift> result = new List<Shift>();
            foreach (string key in schedule[date].Keys)
                result = result.Concat(schedule[date][key]).ToList();
            return result;
        }
        return new List<Shift>();
    }

    public void RemoveShift(DateTime date, Shift shift)
    {
        if (schedule.ContainsKey(date))
        {
            schedule[date][shift.EmployeeName].Remove(shift);
        }
    }
}