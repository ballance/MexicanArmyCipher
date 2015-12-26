using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MexicanArmyCipherBreaker.Library
{
    public class FileHelper
    {
        public string GetCipherTextFromFile(string fileLocation)
        {
            var returnFullText = new StringBuilder();

            using (var fileReader = new StreamReader(fileLocation))
            {
                string line;
                while ((line = fileReader.ReadLine()) != null)
                {
                    returnFullText.Append(line);
                }
            }
            return returnFullText.ToString();
        }

        public void WritePlainTextToFile(string plainText, string wheelConfig)
        {
            using (var fileWriter = new StreamWriter($@"c:\home\temp\decoded\candidate_{wheelConfig}.txt"))
            {
                fileWriter.Write(plainText);
                fileWriter.Flush();
                fileWriter.Close();
            }
        }
    }
}