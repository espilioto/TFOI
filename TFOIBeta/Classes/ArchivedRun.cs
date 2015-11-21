using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFOIBeta
{
    public class ArchivedRun
    {	//inheritance is for scrubs. yolobombar.
        public string Id { get; set; }
        public string Seed { get; set; }
        public string Timestamp { get; set; }
        public Characters Character { get; set; }
        public List<Items> Items { get; set; }
        public List<Floors> Floors { get; set; }
        public List<Bosses> Bosses { get; set; }
        public Bosses KilledBy { get; set; }
        public string Time { get; set; }
        public string Result { get; set; }


        public ArchivedRun()
        {
            Character = new Characters();
            Items = new List<Items>();
            Floors = new List<Floors>();
            Bosses = new List<Bosses>();
            KilledBy = new Bosses();
        }

    }
}
