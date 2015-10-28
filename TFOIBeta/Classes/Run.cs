using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace TFOIBeta
{
    class Run : IDisposable
    {
        bool disposed = false;
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public int _cubeOfMeatLevel;
        public int _ballOfBandagesLevel;
        public float Time { get; set; }
        public string Seed { get; set; }
        public bool PlayerFightingBoss { get; set; }
        public bool Victory { get; set; }
        public bool GameOver { get; set; }
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
                return;

            if (disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.
                //
            }
            // Free any unmanaged objects here.
            //
            _cubeOfMeatLevel = 0;
            _ballOfBandagesLevel = 0;
            Time = 0;
            Seed = null;
            PlayerFightingBoss = false;
            RunCharacter = null;
            RunItems = null;
            RunFloors = null;
            RunBosses = null;

            disposed = true;
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
            if (item.Id == "73")                            //if the item is cube of meat...
            {
                if (_cubeOfMeatLevel == 0)
                {
                    RunItems.Add(item);
                    _cubeOfMeatLevel++;
                    return true;
                }
                else if (_cubeOfMeatLevel == 1)
                {
                    RunItems.Add(Items.List.Find(com => com.Id == "73_2"));
                    _cubeOfMeatLevel++;
                    return true;
                }
                else if (_cubeOfMeatLevel == 2)
                {
                    RunItems.Add(Items.List.Find(com => com.Id == "73_3"));
                    _cubeOfMeatLevel++;
                    return true;
                }
                else if (_cubeOfMeatLevel == 3)
                {
                    RunItems.Add(Items.List.Find(com => com.Id == "73_4"));
                    _cubeOfMeatLevel++;
                    return true;
                }
                else
                {
                    RunItems.Add(item);
                    _cubeOfMeatLevel = 1;
                    return true;
                }
            }
            else if (item.Id == "207")                      //...or ball of bandages, display upgrade instead of the lvl 1 orbital
            {
                if (_ballOfBandagesLevel == 0)
                {
                    RunItems.Add(item);
                    _ballOfBandagesLevel++;
                    return true;
                }
                else if (_ballOfBandagesLevel == 1)
                {
                        var asd = (Items.List.Find(bob => bob.Id == "207_2"));
                    RunItems.Add(asd);
                    _ballOfBandagesLevel++;
                    return true;
                }
                else if (_ballOfBandagesLevel == 2)
                {
                    RunItems.Add(Items.List.Find(bob => bob.Id == "207_3"));
                    _ballOfBandagesLevel++;
                    return true;
                }
                else if (_ballOfBandagesLevel == 3)
                {
                    RunItems.Add(Items.List.Find(bob => bob.Id == "207_4"));
                    _ballOfBandagesLevel++;
                    return true;
                }
                else
                {
                    RunItems.Add(item);
                    _ballOfBandagesLevel = 1;
                    return true;
                }
            }
            else if (!RunItems.Contains(item))               //check if the player already has picked up this item
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
            this.RunFloors.Add(floor);
            floor.Curse = curse;
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
