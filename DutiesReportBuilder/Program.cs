class Program
{
    public static void Main()
    {
        Company DreamInc = new Company();
        DreamInc.Import("../input_1.xml");
        DreamInc.Process();
    }
}