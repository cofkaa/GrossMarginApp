namespace GrossMarginApp.BaseClasses
{
    public abstract class FileUtils
    {
        private static void CreateDirectoryIfNotExists(string dirName)
        {
            if (!Directory.Exists(dirName))
                Directory.CreateDirectory(dirName);
        }

        public static void DeleteFileIfExists(string filePath)
        {
            if (File.Exists(filePath))
                File.Delete(filePath);
        }

        public static void WriteValueInFile(string dirName, string filePath, float value)
        {
            CreateDirectoryIfNotExists(dirName);

            using (var writer = File.AppendText(filePath))
            {
                writer.WriteLine(value);
            }
        }

        public static List<float> ReadFloatValuesFromFile(string filePath)
        {
            string line;
            List<float> values = new List<float>();
            if (File.Exists(filePath))
            {
                using (var reader = File.OpenText(filePath))
                {
                    do
                    {
                        line = reader.ReadLine();
                        if (line != null && float.TryParse(line, out float value))
                            values.Add(value);
                    } while (line != null);
                }
            }
            return values;
        }
    }
}
