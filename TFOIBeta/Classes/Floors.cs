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
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\resources\\JSON\\JsonFloorList.json");

            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonFloor in deserializedItems)
            {
                var floor = new Floors();

                floor.Id = jsonFloor.Name;
                floor.Name = jsonFloor.First["name"];
                //character.Icon = new Bitmap(Environment.CurrentDirectory + "\\resources\\images\\chars\\bw\\" + character.Id + ".png");

                Floors.List.Add(floor);
            }
        }

        private string _id;
        public string Id
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

        private string _curse;
        public string Curse
        {
            get { return _curse; }
            set { _curse = value; }
        }

    }
}
