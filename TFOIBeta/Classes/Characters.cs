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
    class Characters
    {
        public static List<Characters> List = new List<Characters>();

        public static void ParseJsonCharList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\resources\\JSON\\JsonCharList.json");

            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonChar in deserializedItems)
            {
                var character = new Characters();

                character.Id = jsonChar.Name;
                character.Name = jsonChar.First["name"];
                character.Icon = new Bitmap(Environment.CurrentDirectory + "\\resources\\images\\chars\\bw\\" + character.Id + ".png");

                Characters.List.Add(character);
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

        private Bitmap _icon;
        public Bitmap Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

    }
}
