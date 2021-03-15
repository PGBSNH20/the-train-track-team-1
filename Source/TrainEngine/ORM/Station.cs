using System;
using System.IO;
namespace TrainEngine
{
    public class Station
    {
        public string ID { get; set; }
        public long Distance { get; set; }

        public static string GetNameByID(char id)
        {
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "/stations.txt");
            string input;
            string name = "[][]"; //Weird default-value to indicate if parsing succeeded.
            while ((input = reader.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                string[] temp = input.Split('|');
                if (temp[1] == id.ToString())
                {
                    name = temp[0];
                }
            }

            if (name == "[][]")
            {
                throw new Exception("Parsing failed; ID not found in stations.txt");
            }
            else
            {
                return name; 
            }
            
        }

        public static char GetIDByName(string name)
        {
            StreamReader reader = new StreamReader(Environment.CurrentDirectory + "/stations.txt");
            string input;
            char id = '*';
            while ((input = reader.ReadLine()) != null && (!String.IsNullOrWhiteSpace(input)))
            {
                string[] temp = input.Split('|');
                if (temp[0] == name)
                {
                    id = char.Parse(temp[1]);
                }
            }

            if (id == '*')
            {
                throw new Exception("Parsing failed; Name not found in stations.txt");
            }
            else
            {
                return id;
            }
        }
        
    }
}