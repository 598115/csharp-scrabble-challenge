using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace csharp_scrabble_challenge.Main
{
    public class Scrabble(string word)
    {
        private string _word = word.ToUpper();
        public string Word { get => _word; set => _word = value.ToUpper(); }
        private Dictionary<char, int> _scoreDict = InitiateScores();
        public int score()
        {
            int score = 0;
            int multiplier = 1;
            bool doubledActive = false;
            bool tripledActive = false;
           
            if (this._word.Equals("") || this._word.Equals(" \t\n"))
            {
                return 0;
            }

            foreach (char c in this._word)
            {
                if (c.Equals('}') && !doubledActive) { return 0; }
                if(c.Equals(']') && !tripledActive) { return 0; }

                if (c.Equals('{')) { multiplier = multiplier * 2; doubledActive = true; }
                if (c.Equals('[')) { multiplier = multiplier * 3; tripledActive = true; }
                if (c.Equals('}') && doubledActive) { multiplier = multiplier / 2; doubledActive = false; }
                if (c.Equals(']') && tripledActive) { multiplier = multiplier / 3; tripledActive = false; }

                if (this._scoreDict.ContainsKey(c))
                {
                    score += this._scoreDict[c] * multiplier;
                }
                else if (!"{}[]".Contains(c))
                {
                    return 0;
                }
            }

            if (doubledActive || tripledActive) { return 0; }
            return score;
        }

        private static Dictionary<char, int> InitiateScores()
        {
            List<char> score1 = new List<char>(new char[]{'A', 'E', 'I', 'O', 'U', 'L', 'N', 'R', 'S', 'T'});
            List<char> score2 = new List<char>(new char[] {'D', 'G'});
            List<char> score3 = new List<char>(new char[] {'B', 'C', 'M', 'P'});
            List<char> score4 = new List<char>(new char[] {'F', 'H', 'V', 'W', 'Y'});
            List<char> score5 = new List<char>(new char[] {'K'});
            List<char> score8 = new List<char>(new char[] { 'J', 'X'});
            List<char> score10 = new List<char>(new char[] { 'Q', 'Z'});

            Dictionary<char, int> scoreDict = new Dictionary<char, int>();

            foreach (char c in score1) { scoreDict.Add(c, 1); }
            foreach (char c in score2) { scoreDict.Add(c, 2); }
            foreach (char c in score3) { scoreDict.Add(c, 3); }
            foreach (char c in score4) { scoreDict.Add(c, 4); }
            foreach (char c in score5) { scoreDict.Add(c, 5); }
            foreach (char c in score8) { scoreDict.Add(c, 8); }
            foreach (char c in score10) { scoreDict.Add(c, 10); }

            return scoreDict;
        }
    }

}
