using GrossMarginApp.Interfaces;

namespace GrossMarginApp.BaseClasses
{
    public class ValuesBase : IValues
    {
        public delegate void ValueSavedDelegate(object sender, EventArgs args, float value);
        public event ValueSavedDelegate ValueSaved;
        private const string fileNameSuffix = "Values.txt";
        public string DirName { get; private set; }
        public string ValuesFilePath { get; private set; }
        public List<float> Values { get; private set; }
        public float Sum => Values.Sum();
        public int Count => Values.Count;
        public ValuesBase(string dirName, string fileNamePrefix)
        {
            this.DirName = dirName;
            this.ValuesFilePath = $"{dirName}\\{fileNamePrefix}{fileNameSuffix}";
            this.Values = new List<float>();
        }

        public void WriteValueInFile(string value)
        {
            if (float.TryParse(value, out float result))
                WriteValueInFile(result);
            else
                throw new Exception($"String value {value} is not a float.");
        }

        public void WriteValueInFile(float value)
        {
            FileUtils.WriteValueInFile(this.DirName, this.ValuesFilePath, value);
            if (this.ValueSaved != null)
            {
                this.ValueSaved(this, new EventArgs(), value);
            }
        }

        public void ReadValuesFromFile()
        {
            this.Values = FileUtils.ReadFloatValuesFromFile(this.ValuesFilePath);
        }
    }
}
