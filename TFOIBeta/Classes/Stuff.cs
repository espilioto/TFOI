using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace TFOIBeta
{
    public class Image : System.Windows.Controls.Image
    {
        public string ObjectName { get; set; }
        public string ObjectDescription { get; set; }
        public string ObjectMisc { get; set; }
        public string Tag2 { get; set; }
    }

    class Stuff
    {

        public static ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        // credit: https://stackoverflow.com/questions/9929279/to-count-the-frequency-of-each-word
        /// <summary>
        /// Returns a list that contains the top 10 items picked up from the string given.
        /// </summary>
        public static List<Items> SortTop10Items(string objectList, Dictionary<string, int> words)
        {
            var itemList = new List<Items>();
            var wordPattern = new Regex(@"\d+");

            foreach (Match match in wordPattern.Matches(objectList))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }

            foreach (var item in words)
            {
                if (itemList.Count < 10)
                {
                    itemList.Add(Items.GetItemFromId(item.Key));
                    itemList.Last().TimesCollected = item.Value;
                }
            }

            return itemList;
        }
        /// <summary>
        /// Returns a list that contains the top 5 bosses fought from the string given.
        /// </summary>
        public static List<Bosses> SortTop5Bosses(string objectList, Dictionary<string, int> words)
        {
            var bossList = new List<Bosses>();
            var wordPattern = new Regex(@"\d+");

            foreach (Match match in wordPattern.Matches(objectList))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }

            foreach (var boss in words)
            {
                if (bossList.Count < 5)
                {
                    bossList.Add(Bosses.GetBossFromId(boss.Key));
                    bossList.Last().TimesFought = boss.Value;
                }
            }

            return bossList;
        }
    }
}
