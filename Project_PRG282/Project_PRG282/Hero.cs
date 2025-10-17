using System;

namespace Project_PRG282
{
    internal class Hero
    {
        // Basic Hero properties - Day 1 foundation
        public string HeroID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Superpower { get; set; }
        public int ExamScore { get; set; }
        public string Rank { get; set; }
        public string ThreatLevel { get; set; }

        // Constructor for Day 1
        public Hero()
        {
            HeroID = "";
            Name = "";
            Age = 0;
            Superpower = "";
            ExamScore = 0;
            Rank = "";
            ThreatLevel = "";
        }

        // Basic constructor with parameters
        public Hero(string id, string name, int age, string superpower, int examScore)
        {
            HeroID = id;
            Name = name;
            Age = age;
            Superpower = superpower;
            ExamScore = examScore;
            Rank = ""; // Will be calculated in future days
            ThreatLevel = ""; // Will be calculated in future days
        }
    }
}
