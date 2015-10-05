using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFOIBeta
{
    class Floors
    {
        public static List<Floors> List = new List<Floors>();

        public static void ParseJsonFloorList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\resources\\JSON\\JsonCharList.json");

            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonChar in deserializedItems)
            {
                var floor = new Characters();

                floor.Id = jsonChar.Name;
                floor.Name = jsonChar.First["name"];
                //character.Icon = new Bitmap(Environment.CurrentDirectory + "\\resources\\images\\chars\\bw\\" + character.Id + ".png");

                Characters.List.Add(floor);
            }
        }

        private int _id;
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }

        private string _name;
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
    }
}
