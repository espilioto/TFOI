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

        public static Floors GetFloorFromId(string stage, string altStage)
        {
            if (stage == "1" && altStage == "0")                                                //chapter 1
            {
                return Floors.List.Find(floor => floor.Name == "Basement I");
            }
            else if (stage == "1" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Cellar I");
            }
            else if (stage == "1" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Burning Basement II");
            }
            else if (stage == "2" && altStage == "0")
            {
                return Floors.List.Find(floor => floor.Name == "Basement II");
            }
            else if (stage == "2" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Cellar II");
            }
            else if (stage == "2" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Burning Basement II");
            }

            else if (stage == "3" && altStage == "0")                                            //chapter 2
            {
                return Floors.List.Find(floor => floor.Name == "Caves I");
            }
            else if (stage == "3" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Catacombs I");
            }
            else if (stage == "3" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Flooded Caves I");
            }
            else if (stage == "4" && altStage == "0")
            {
                return Floors.List.Find(floor => floor.Name == "Caves II");
            }
            else if (stage == "4" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Catacombs II");
            }
            else if (stage == "4" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Flooded Caves II");
            }

            else if (stage == "5" && altStage == "0")                                            //chapter 3
            {
                return Floors.List.Find(floor => floor.Name == "Depths I");
            }
            else if (stage == "5" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Necropolis I");
            }
            else if (stage == "5" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Dank Depths I");
            }
            else if (stage == "6" && altStage == "0")
            {
                return Floors.List.Find(floor => floor.Name == "Depths II");
            }
            else if (stage == "6" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Necropolis II");
            }
            else if (stage == "6" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Dank Depths II");
            }

            else if (stage == "7" && altStage == "0")                                            //chapter 4
            {
                return Floors.List.Find(floor => floor.Name == "Womb I");
            }
            else if (stage == "7" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Utero I");
            }
            else if (stage == "7" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Scarred Womb  I");
            }
            else if (stage == "8" && altStage == "0")
            {
                return Floors.List.Find(floor => floor.Name == "Womb II");
            }
            else if (stage == "8" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Utero II");
            }
            else if (stage == "8" && altStage == "2")
            {
                return Floors.List.Find(floor => floor.Name == "Scarred Womb  II");
            }

            else if (stage == "9" && altStage == "0")
            {
                return Floors.List.Find(floor => floor.Name == "Blue Womb");
            }

            else if (stage == "10" && altStage == "0")                                            //chapter 5
            {
                return Floors.List.Find(floor => floor.Name == "Sheol");
            }
            else if (stage == "10" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Cathedral");
            }

            else if (stage == "11" && altStage == "0")                                           //chapter 6
            {
                return Floors.List.Find(floor => floor.Name == "Dark Room");
            }
            else if (stage == "11" && altStage == "1")
            {
                return Floors.List.Find(floor => floor.Name == "Chest");
            }

            else
            {
                return null;
            }
        }

        public static Floors ConvertFloorToXL(Floors floor)
        {
            if (floor.Name.Contains("Basement"))
            {
                return Floors.List.Find(asd => asd.Name == "Basement XL");
            }
            else if (floor.Name.Contains("Cellar"))
            {
                return Floors.List.Find(asd => asd.Name == "Cellar XL");
            }
            else if (floor.Name.Contains("Burning"))
            {
                return Floors.List.Find(asd => asd.Name == "Burning Basement XL");
            }
            else if (floor.Name.Contains("Caves"))
            {
                return Floors.List.Find(asd => asd.Name == "Caves XL");
            }
            else if (floor.Name.Contains("Catacombs"))
            {
                return Floors.List.Find(asd => asd.Name == "Catacombs XL");
            }
            else if (floor.Name.Contains("Flooded"))
            {
                return Floors.List.Find(asd => asd.Name == "Flooded Caves XL");
            }
            else if (floor.Name.Contains("Depths"))
            {
                return Floors.List.Find(asd => asd.Name == "Depths XL");
            }
            else if (floor.Name.Contains("Necropolis"))
            {
                return Floors.List.Find(asd => asd.Name == "Necropolis XL");
            }
            else if (floor.Name.Contains("Dank"))
            {
                return Floors.List.Find(asd => asd.Name == "Dank Depths XL");
            }
            else if (floor.Name.Contains("Womb"))
            {
                return Floors.List.Find(asd => asd.Name == "Womb XL");
            }
            else if (floor.Name.Contains("Utero"))
            {
                return Floors.List.Find(asd => asd.Name == "Utero XL");
            }
            else if (floor.Name.Contains("Rotten"))
            {
                return Floors.List.Find(asd => asd.Name == "Rotten Womb XL");
            }
            else
            {
                return null;
            }
        }

        public static void ParseJsonFloorList()
        {
            string json = File.ReadAllText(Environment.CurrentDirectory + "\\resources\\JSON\\JsonFloorList.json");

            dynamic deserializedItems = JsonConvert.DeserializeObject(json);

            foreach (var jsonFloor in deserializedItems)
            {
                var floor = new Floors();

                floor.Id = jsonFloor.Name;
                floor.Name = jsonFloor.First["name"];

                if (floor.Name.Contains("Burning"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\13.png");
                }
                else if (floor.Name.Contains("Flooded"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\14.png");
                }
                else if (floor.Name.Contains("Dank"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\15.png");
                }
                else if (floor.Name.Contains("Scarred"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\16.png");
                }
                else if (floor.Name.Contains("Blue"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\18.png");
                }
                else if (floor.Name.Contains("Basement"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\1.png");
                }
                else if (floor.Name.Contains("Cellar"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\2.png");
                }
                else if (floor.Name == "Caves")
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\3.png");
                }
                else if (floor.Name.Contains("Catacombs"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\4.png");
                }
                else if (floor.Name.Contains("Depths"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\5.png");
                }
                else if (floor.Name.Contains("Necropolis"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\6.png");
                }
                else if (floor.Name.Contains("Womb"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\7.png");
                }
                else if (floor.Name.Contains("Utero"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\8.png");
                }
                else if (floor.Name.Contains("Sheol"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\9.png");
                }
                else if (floor.Name.Contains("Cathedral"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\10.png");
                }
                else if (floor.Name.Contains("Chest"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\11.png");
                }
                else if (floor.Name.Contains("Room"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\12.png");
                }
                else if (floor.Name.Contains("???"))
                {
                    floor.Icon = new Bitmap(Environment.CurrentDirectory + @"\resources\images\floors\17.png");
                }

                Floors.List.Add(floor);
            }
        }

        public string Id { get; set; }
        public string Name { get; set; }
        public string Curse { get; set; }

        public Bitmap Icon { get; set; }
    }
}
