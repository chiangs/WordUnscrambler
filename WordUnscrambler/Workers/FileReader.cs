using System;
using System.IO;
namespace WordUnscrambler.Workers
{
    public class FileReader
    {
        // read all lines from a text file
        // try to assign it in a string[]
        // return or throw exception
        public string[] Read(string filename)
        {
            string[] fileContent;
            try {
                fileContent = File.ReadAllLines(filename);
            } catch (Exception ex) {
                throw new Exception(ex.Message);
            }
            return fileContent;
        }
    }
}
