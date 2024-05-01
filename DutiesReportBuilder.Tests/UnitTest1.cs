using System.Xml;

namespace DutiesReportBuilder.Tests;

public class ScheduleTests
{
    int problemCount = 0, vacationCount = 0, sickleaveCount = 0;
    private void Parse(string file_path)
    {
        string data = File.ReadAllText(file_path);
        string[] lines = data.Split(Environment.NewLine, StringSplitOptions.None);

        this.problemCount = lines.Count(line => line.StartsWith("- ") && line.Contains("**Проблемы:**"));
        this.vacationCount = lines.Count(line => line.StartsWith("- ") && line.Contains("**Отпуска:**"));
        this.sickleaveCount = lines.Count(line => line.StartsWith("- ") && line.Contains("**Болезни:**"));
    }

    [Fact]
    public void PetyaProblem()
    {
        Company DreamInc = new Company();
        DreamInc.Import("../../../../input_1.xml");
        DreamInc.Process();
        
        Assert.Equal("Петр одновременно дежурит на backend2, на Team 1, 29.4", DreamInc.problems[0]);
    }

    // [Fact]
    // public void Problems()
    // {
    //     Company DreamInc = new Company();
    //     DreamInc.Import("input_1.xml");
    //     DreamInc.Process();

    //     Parse("expected_result_1.txt");

    //     Assert.Equal(DreamInc.problemCount, this.problemCount);
    // }

    // [Fact]
    // public void Vacations()
    // {
    //     Company DreamInc = new Company();
    //     DreamInc.Import("input_1.xml");
    //     DreamInc.Process();

    //     Parse("expected_result_1.txt");

    //     Assert.Equal(DreamInc.vacationCount, this.vacationCount);
    // }

    // [Fact]
    // public void SickLeaves()
    // {
    //     Company DreamInc = new Company();
    //     DreamInc.Import("input_1.xml");
    //     DreamInc.Process();

    //     Parse("expected_result_1.txt");

    //     Assert.Equal(DreamInc.sickleaveCount, this.sickleaveCount);
    // }
}