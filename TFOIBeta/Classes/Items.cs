using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.IO;

namespace TFOIBeta
{
    class Items
    {
        public static List<Items> List = new List<Items>();

        public static void ParseJsonItemList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\resources\\JSON\\JsonItemList.json");
            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonItem in deserializedItems)
            {
                var item = new Items();

                item.Id = jsonItem.Name;                                     //these four properties (should) exist for every item
                item.Name = jsonItem.First["name"];
                item.Text = jsonItem.First["text"];
                item.Icon = new Bitmap(Environment.CurrentDirectory + "\\resources\\images\\collectibles\\" + item.Id + ".png");

                if (jsonItem.First["health"] != null)                                     //int
                    item.Health = jsonItem.First["health"];
                if (jsonItem.First["soulhearts"] != null)
                    item.SoulHearts = jsonItem.First["soulhearts"];
                if (jsonItem.First["sinhearts"] != null)
                    item.SinHearts = jsonItem.First["sinhearts"];

                if (jsonItem.First["healthOnly"] != null)                                 //bool
                    item.HealthOnly = jsonItem.First["healthOnly"];
                if (jsonItem.First["space"] != null)
                    item.Space = jsonItem.First["space"];

                if (jsonItem.First["delay"] != null)                                       //float
                    item.Delay = jsonItem.First["delay"];
                if (jsonItem.First["delayX"] != null)
                    item.DelayX = jsonItem.First["delayX"];
                if (jsonItem.First["dmg"] != null)
                    item.Damage = jsonItem.First["dmg"];
                if (jsonItem.First["dmgX"] != null)
                    item.DamageX = jsonItem.First["dmgX"];
                if (jsonItem.First["range"] != null)
                    item.Range = jsonItem.First["range"];
                if (jsonItem.First["tears"] != null)
                    item.Tears = jsonItem.First["tears"];
                if (jsonItem.First["tearHeight"] != null)
                    item.TearHeight = jsonItem.First["tearHeight"];
                if (jsonItem.First["speed"] != null)
                    item.Speed = jsonItem.First["speed"];

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