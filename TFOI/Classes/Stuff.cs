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

namespace TFOI
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
        static Dictionary<string,int> words = new Dictionary<string, int>(StringComparer.CurrentCultureIgnoreCase);

        public static ImageSource BitmapToImageSource(Bitmap bitmap)
        {
            return Imaging.CreateBitmapSourceFromHBitmap(bitmap.GetHbitmap(), IntPtr.Zero, Int32Rect.Empty, BitmapSizeOptions.FromEmptyOptions());
        }

        // credit: https://stackoverflow.com/questions/9929279/to-count-the-frequency-of-each-word

        /// <summary>
        /// Returns a list that contains the top 10 items picked up from the string given.
        /// </summary>
        /// <param name="objectList">The itemID string</param>
        /// <param name="count">The size of the list that will be returned</param>
        /// <param name="words">The dictionary that will be used to count and sort the objects</param>
        public static List<Items> SortTopItems(string objectList, int count)
        {
            var itemList = new List<Items>();
            var wordPattern = new Regex(@"\d+");
            words.Clear();

            foreach (Match match in wordPattern.Matches(objectList))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }

            foreach (var item in words.OrderByDescending(i => i.Value))
            {
                if (itemList.Count < count)
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
        /// <param name="objectList">The itemID string</param>
        /// <param name="count">The size of the list that will be returned</param>
        /// <param name="words">The dictionary that will be used to count and sort the objects</param>
        public static List<Bosses> SortTopBosses(string objectList, int count)
        {
            var bossList = new List<Bosses>();
            var wordPattern = new Regex(@"\d+");
            words.Clear();

            foreach (Match match in wordPattern.Matches(objectList))
            {
                int currentCount = 0;
                words.TryGetValue(match.Value, out currentCount);

                currentCount++;
                words[match.Value] = currentCount;
            }

            foreach (var boss in words.OrderByDescending(i => i.Value))
            {
                if (bossList.Count < count)
                {
                    bossList.Add(Bosses.GetBossFromId(boss.Key));
                    bossList.Last().TimesFought = boss.Value;
                }
            }

            return bossList;
        }
    }
}
