using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace TFOIBeta
{
    class Bosses
    {
        public static List<Bosses> List = new List<Bosses>();

        public static void ParseJsonBossList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + @"\resources\JSON\JsonBossList.json");
            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonBoss in deserializedItems)
            {
                var boss = new Bosses();

                boss.Id = jsonBoss.Name;
                boss.Name = jsonBoss.First["name"];                                     //these four properties (should) exist for every boss
                boss.Text = jsonBoss.First["text"];
                boss.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\bosses\" + boss.Id + ".png");

                if (jsonBoss.First["alts1"] != null)
                    boss.Alts1 = jsonBoss.First["alts1"];
                if (jsonBoss.First["alts2"] != null)
                    boss.Alts1 = jsonBoss.First["alts2"];

                Bosses.List.Add(boss);
            }
        }
        private bool _killedPlayer;
        public bool KilledPlayer
        {
            get { return _killedPlayer; }
            set { _killedPlayer = value; }
        }
        private bool _killedByPlayer;
        public bool KilledByPlayer
        {
            get { return _killedByPlayer; }
            set { _killedByPlayer = value; }
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
        private string _BossHP;
        public string BossHP
        {
            get { return _BossHP; }
            set { _BossHP = value; }
        }
        private string _alts1;
        public string Alts1
        {
            get { return _alts1; }
            set { _alts1 = value; }
        }
        private string _alts2;
        public string Alts2
        {
            get { return _alts2; }
            set { _alts2 = value; }
        }
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }

        private Bitmap _icon;
        public Bitmap Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }
    }
}
