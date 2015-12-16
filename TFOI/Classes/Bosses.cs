using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Drawing;
using System.IO;

namespace TFOI
{
    public class Bosses
    {
        public static List<Bosses> List = new List<Bosses>();

        public static Bosses GetBossFromName(string bossName)
        {
            return Bosses.List.Find(boss => boss.Name == bossName);
        }
        public static Bosses GetBossFromId(string bossId)
        {
            return Bosses.List.Find(boss => boss.Id == bossId);
        }

        public static void ParseJsonBossList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + @"\resources\JSON\JsonBossList.json");
            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonBoss in deserializedItems)
            {
                var boss = new Bosses();

                boss.Id = jsonBoss.Name;
                boss.Name = jsonBoss.First["name"];                                     //these five properties (should) exist for every boss
                boss.Text = jsonBoss.First["text"];
                boss.HP = jsonBoss.First["bossHP"]; ;
                boss.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\bosses\" + boss.Id + ".png");

                if (jsonBoss.First["alts1"] != null)
                {
                    boss.Alts1 = jsonBoss.First["alts1"];
                    boss.DetailsString += boss.Alts1 + Environment.NewLine;
                }
                if (jsonBoss.First["alts2"] != null)
                {
                    boss.Alts1 = jsonBoss.First["alts2"];
                    boss.DetailsString += boss.Alts2 + Environment.NewLine;
                }

                boss.NameLogo = new Bitmap(Environment.CurrentDirectory + @"\resources\images\bosses\" + boss.Id + "_2.png");

                Bosses.List.Add(boss);
            }
        }
        public bool KilledByPlayer { get; set; }                //bool

        public string Id { get; set; }                          //string
        public string Name { get; set; }
        public string HP { get; set; }
        public string Alts1 { get; set; }
        public string Alts2 { get; set; }
        public string Text { get; set; }
        public string DetailsString { get; set; }

        public int TimesFought { get; set; }                    //int

        public Bitmap Icon { get; set; }                        //icon
        public Bitmap NameLogo { get; set; }
    }
}
