using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GCProject.Miscellanies
{
    static class FileReader
    {
        public static async Task<List<int>> ReadWhitelistAsync(string path)
        {
            List<int> numbersList = new List<int>();

            using (TextReader reader = File.OpenText(path))
            {
                string text = await reader.ReadToEndAsync();
                if (text == null)
                {
                    return null;
                }
                string[] lines = text.Split('\n');
                int tmp = 0;

                foreach (string line in lines)
                {
                    if (int.TryParse(line, out tmp))
                    {
                        numbersList.Add(tmp);
                    }
                }
            }

            return numbersList;
        }
    }
}
