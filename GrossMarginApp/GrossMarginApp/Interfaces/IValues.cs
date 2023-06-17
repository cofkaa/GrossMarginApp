namespace GrossMarginApp.Interfaces
{
    public interface IValues
    {
        public string DirName { get; }
        public string ValuesFilePath { get; }
        public List<float> Values { get; }
        public float Sum { get; }
        public int Count { get; }

        public void WriteValueInFile(string value) { }

        public void WriteValueInFile(float value) { }

        public void ReadValuesFromFile() { }
    }
}
