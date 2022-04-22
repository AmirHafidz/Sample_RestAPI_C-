using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace AmirRestAPI.Services
{
    public class Jason
    {
        private static StreamReader srArray;

        public static void SaveJsonFile<T>(List<T> inputList, string filename) where T : new()
        {
            string listOutput = JsonConvert.SerializeObject(inputList, Formatting.Indented);

            if (File.Exists(filename))
            {
                File.Delete(filename);
            }

            File.WriteAllText(filename, listOutput);
        }

        public static List<T> LoadJsonFile<T>(string jsonFilename) where T : new()
        {
            try
            {
                srArray = new StreamReader(jsonFilename);
                string outputFromFile = srArray.ReadToEnd();

                List<T> usrArray = JsonConvert.DeserializeObject<List<T>>(outputFromFile);

                srArray.Close();

                return usrArray;
            }
            catch (Exception)
            {
                return null;
                //throw;
            }
        }
    }
}
