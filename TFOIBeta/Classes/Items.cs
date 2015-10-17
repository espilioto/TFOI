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

        public static void ParseJsonItemList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\Resources\\JSON\\JsonItemList.json");
            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonItem in deserializedItems)
            {
                var item = new Items();

                item.Id = jsonItem.Name;                                     //these four properties (should) exist for every item
                item.Name = jsonItem.First["name"];
                item.Text = jsonItem.First["text"];
                item.Icon = new Bitmap(Environment.CurrentDirectory + "\\Resources\\images\\collectibles\\" + item.Id + ".png");

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
                if (jsonItem.First["guppy"] != null)
                {
                    item.Guppy = jsonItem.First["guppy"];
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
                    item.DetailsString += "TEAR RANGE: " + item.Range.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["tears"] != null)
                {
                    item.Tears = jsonItem.First["tears"];
                    item.DetailsString += "TEARS: " + item.Tears.ToString() + Environment.NewLine;
                }
                if (jsonItem.First["tearHeight"] != null)
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
                        item.DetailsString  = item.DetailsString.TrimEnd(Environment.NewLine.ToCharArray());

                Items.List.Add(item);
            }
        }



        private string _id;                                 //string
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
        private string _text;
        public string Text
        {
            get { return _text; }
            set { _text = value; }
        }
        private string _detailsString;
        public string DetailsString
        {
            get { return _detailsString; }
            set { _detailsString = value; }
        }


        private int _health;                                //int
        public int Health
        {
            get { return _health; }
            set { _health = value; }
        }
        private int _soulHearts;
        public int SoulHearts
        {
            get { return _soulHearts; }
            set { _soulHearts = value; }
        }
        private int _sinHearts;
        public int SinHearts
        {
            get { return _sinHearts; }
            set { _sinHearts = value; }
        }

        private bool _healthOnly;                           //bool
        public bool HealthOnly
        {
            get { return _healthOnly; }
            set { _healthOnly = value; }
        }
        private bool _space;
        public bool Space
        {
            get { return _space; }
            set { _space = value; }
        }
        private bool _guppy;
        public bool Guppy
        {
            get { return _guppy; }
            set { _guppy = value; }
        }


        private float _delay;                               //float
        public float Delay
        {
            get { return _delay; }
            set { _delay = value; }
        }
        private float _delayX;
        public float DelayX
        {
            get { return _delayX; }
            set { _delayX = value; }
        }
        private float _dmg;
        public float Damage
        {
            get { return _dmg; }
            set { _dmg = value; }
        }
        private float _dmgX;
        public float DamageX
        {
            get { return _dmgX; }
            set { _dmgX = value; }
        }
        private float _range;
        public float Range
        {
            get { return _range; }
            set { _range = value; }
        }
        private float _tears;
        public float Tears
        {
            get { return _tears; }
            set { _tears = value; }
        }
        private float _tearHeight;
        public float TearHeight
        {
            get { return _tearHeight; }
            set { _tearHeight = value; }
        }
        private float _shotSpeed;
        public float ShotSpeed
        {
            get { return _shotSpeed; }
            set { _shotSpeed = value; }
        }
        private float _speed;
        public float Speed
        {
            get { return _speed; }
            set { _speed = value; }
        }

        private Bitmap _icon;                               //icon
        public Bitmap Icon
        {
            get { return _icon; }
            set { _icon = value; }
        }

    }
}