using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TFOIBeta
{
    class Run
    {
        public double Time { get; set; }
        public string Seed { get; set; }
        public Characters RunCharacter { get; set; }
        public List<Items> RunItems { get; set; }
        public List<Floors> RunFloors { get; set; }
        public List<Bosses> RunBosses { get; set; }

        public Run()
        {
            RunCharacter = new Characters();
            RunItems = new List<Items>();
            RunFloors = new List<Floors>();
            RunBosses = new List<Bosses>();
        }

        private bool _gameOver = false;
        public bool GameOver
        {
            get { return _gameOver; }
            set { _gameOver = value; }
        }

        private bool _victory = false;
        public bool Victory
        {
            get { return _victory; }
            set { _victory = value; }
        }

        public static void Initialise()
        {
            Log.LoadPathFromSettings();
        }

        public void AddCharacter(Characters character)
        {
            this.RunCharacter = character;
        }
        public bool AddItem(Items item)
        {
            if (!RunItems.Contains(item))           //check if the player already has picked up this item
            {
                RunItems.Add(item);
                return true;
            }
            else
            {
                return false;
            }
        }
        public void AddFloor(Floors floor)
        {
            this.RunFloors.Add(floor);
        }
        public void AddFloor(Floors floor, string curse)
        {
            floor.Curse = curse;
            this.RunFloors.Add(floor);
        }
        public bool AddBoss(Bosses boss)            //check if the played just re-entered the Boss room and the (= boss exists in the list)
        {
            if (!RunBosses.Contains(boss))
            {
                RunBosses.Add(boss);
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
