namespace GrossMarginApp.Interfaces
{
    public interface IValues
    {
        string DirName { get; }
        string ValuesFilePath { get; }
        List<float> Values { get; }
        float Sum { get; }
        int Count { get; }

        void WriteValueInFile(string value);

        void WriteValueInFile(float value);

        void ReadValuesFromFile();
    }
}
