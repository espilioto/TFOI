using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;
using System.Collections;

namespace TFOIBeta
{
    class Items
    {
        public static List<Items> List = new List<Items>();

        public static Items GetItemFromId(string itemId)
        {
            return Items.List.Find(item => item.Id == itemId);
        }

        public static void ParseJsonItemList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + @"\resources\JSON\JsonItemList.json");
            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonItem in deserializedItems)
            {
                var item = new Items();

                item.Id = jsonItem.Name;                                     //these four properties (should) exist for every item
                item.Name = jsonItem.First["name"];
                item.Text = jsonItem.First["text"];
                item.Icon = new Bitmap(Environment.CurrentDirectory + @"\Resources\images\collectibles\" + item.Id + ".png");

                if (jsonItem.First["details"] != null)                                                              //string
                {
                    item.Details = jsonItem.First["details"];
                    item.DetailsString += item.Details.ToUpper() + Environment.NewLine;
                }

                if (jsonItem.First["health"] != null)                                                              //int
                {
                    item.Health = jsonItem.First["health"];
                    item.DetailsString += "HP: " + item.Health.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["soulhearts"] != null)
                {
                    item.SoulHearts = jsonItem.First["soulhearts"];
                    item.DetailsString += "SOUL HEARTS +" + item.SoulHearts.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["sinhearts"] != null)
                {
                    item.SinHearts = jsonItem.First["sinhearts"];
                    item.DetailsString += "SIN HEARTS +" + item.SinHearts.ToString() + Environment.NewLine;
                }

                if (jsonItem.First["healthOnly"] != null)                                                        //bool
                {
                    item.HealthOnly = jsonItem.First["healthOnly"];
                }
                if (jsonItem.First["space"] != null)
                {
                    item.Space = jsonItem.First["space"];
                }

                if (jsonItem.First["tform"] != null)                                                            //transformations
                {
                    item.Tform = jsonItem.First["tform"];
                }

                if (jsonItem.First["delay"] != null)                                                             //float
                {
                    item.Delay = jsonItem.First["delay"];
                    item.DetailsString += "TEAR DELAY: " + item.Delay.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["delayX"] != null)
                {
                    item.DelayX = jsonItem.First["delayX"];
                    item.DetailsString += "TEAR DELAY MULTI: " + item.DelayX.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["dmg"] != null)
                {
                    item.Damage = jsonItem.First["dmg"];
                    item.DetailsString += "DAMAGE: " + item.Damage.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["dmgX"] != null)
                {
                    item.DamageX = jsonItem.First["dmgX"];
                    item.DetailsString += "TEAR DAMAGE MULTI: " + item.DamageX.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["range"] != null)
                {
                    item.Range = jsonItem.First["range"];
                    item.DetailsString += "RANGE: " + item.Range.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["tears"] != null)
                {
                    item.Tears = jsonItem.First["tears"];
                    item.DetailsString += "TEARS: " + item.Tears.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["height"] != null)
                {
                    item.TearHeight = jsonItem.First["height"];
                    item.DetailsString += "TEAR HEIGHT: " + item.TearHeight.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["shotspeed"] != null)
                {
                    item.ShotSpeed = jsonItem.First["shotspeed"];
                    item.DetailsString += "SHOT SPEED: " + item.ShotSpeed.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["speed"] != null)
                {
                    item.Speed = jsonItem.First["speed"];
                    item.DetailsString += "SPEED: " + item.Speed.ToString() + Environment.NewLine;
                }

                if (!string.IsNullOrEmpty(item.DetailsString))
                    if (item.DetailsString.EndsWith(Environment.NewLine))
                        item.DetailsString = item.DetailsString.TrimEnd(Environment.NewLine.ToCharArray());

                Items.List.Add(item);
            }
        }



        public string Id { get; set; }                              //string
        public string Name { get; set; }
        public string Text { get; set; }
        public string Details { get; set; }
        public string DetailsString { get; set; }
        public string Tform { get; set; }

        public int Health { get; set; }                             //int
        public int SoulHearts { get; set; }
        public int SinHearts { get; set; }

        public bool HealthOnly { get; set; }                        //bool
        public bool Space { get; set; }

        public float Delay { get; set; }                            //float
        public float DelayX { get; set; }
        public float Damage { get; set; }
        public float DamageX { get; set; }
        public float Range { get; set; }
        public float Tears { get; set; }
        public float TearHeight { get; set; }
        public float ShotSpeed { get; set; }
        public float Speed { get; set; }

        public Bitmap Icon { get; set; }                    //icon   
    }
}