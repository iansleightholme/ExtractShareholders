using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DAL;

namespace Model
{
    public class ReportReader
    {
        public IEnumerable<Share> GetShares(string text, string countryCode)
        {
            switch (countryCode.ToUpper())
            {
                case "AT":
                    return GetATShares(text);
                case "GB":
                    return GetGBShares(text);
                default:
                    throw new NotImplementedException();
            }
        }

        IEnumerable<Share> GetATShares(string text)
        {
            string[] shareLines = GetATShareLines(text).ToArray();
            List<Share> shares = new List<Share>();

            for (int i = 0; i < shareLines.Length; i += 3)
            {
                string line1 = shareLines[i];
                string line2 = shareLines[i + 1];
                string line3 = shareLines[i + 2];

                int s = line1.IndexOf(' ');
                string type = line1.Substring(0, s).Trim();
                string name = line1.Substring(s + 1).Trim();
                s = line2.IndexOf(' ');
                int quantity = int.Parse(line2.Substring(0, s).Trim());
                string description = line2.Substring(s + 1).Trim(new char[] { ' ', '.' });

                shares.Add(new Share(description, quantity, name, type));
            }

            return shares;
        }

        IEnumerable<string> GetATShareLines(string text)
        {
            bool active = false;

            foreach (string line in GetLines(text))
            {
                if (line.StartsWith("GESELLSCHAFTER"))
                {
                    active = true;
                    continue;
                }
                else if (line.StartsWith("------------------"))
                    active = false;

                if (active && !string.IsNullOrEmpty(line.Trim()))
                    yield return line.Trim();
            }
        }

        IEnumerable<Share> GetGBShares(string text)
        {
            string[] shareLines = GetGBShareLines(text).ToArray();
            List<Share> shares = new List<Share>();

            for (int i = 0; i < shareLines.Length; i += 2)
            {
                string line1 = shareLines[i];
                string l1c = line1.Substring(line1.IndexOf(':') + 1).Trim();
                int s = l1c.IndexOf(' ');
                int quantity = int.Parse(l1c.Substring(0, s).Trim());
                string description = l1c.Substring(s + 1).Trim();
                string name = shareLines[i + 1].Substring(5).Trim();

                shares.Add(new Share(description, quantity, name, string.Empty));
            }

            return shares;
        }

        IEnumerable<string> GetGBShareLines(string text)
        {
            bool active = false;

            foreach (string line in GetLines(text))
            {
                if (line.StartsWith("Shareholding"))
                    active = true;
                else if (line.StartsWith("Confirmation Statement"))
                    active = false;

                if (active && !string.IsNullOrEmpty(line.Trim()))
                    yield return line.Trim().Replace("held as at the date of this confirmation statement", string.Empty);
            }
        }

        IEnumerable<string> GetLines(string text)
        {
            using (StringReader reader = new StringReader(text))
            {
                string line;
                while ((line = reader.ReadLine()) != null)
                    yield return line;
            }
        }
    }
}

