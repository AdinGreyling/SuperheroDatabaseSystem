using System;
using System.Collections.Generic;
using System.Linq;

namespace Project_PRG282
{
    internal class Hero
    {
        // Hero properties
        public string HeroID { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Superpower { get; set; }
        public int ExamScore { get; set; }
        public string Rank { get; set; }
        public string ThreatLevel { get; set; }

        // Default constructor
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

        // Constructor with parameters
        public Hero(string id, string name, int age, string superpower, int examScore)
        {
            HeroID = id;
            Name = name;
            Age = age;
            Superpower = superpower;
            ExamScore = examScore;
            Rank = "";
            ThreatLevel = "";
        }

        // Parse hero from file line - Day 2 addition
        public static Hero FromLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            // Split using commas (file format uses commas)
            var parts = line.Split(',');

            // Ensure we have at least 7 fields (to avoid crashes on short lines)
            if (parts.Length < 7)
                return null;

            // Parse numeric fields safely
            int.TryParse(parts[2].Trim(), out int age);
            int.TryParse(parts[4].Trim(), out int score);

            // Build and return a Hero object
            return new Hero
            {
                HeroID = parts[0].Trim(),
                Name = parts[1].Trim(),
                Age = age,
                Superpower = parts[3].Trim(),
                ExamScore = score,
                Rank = parts[5].Trim(),
                ThreatLevel = parts[6].Trim()
            };
        }

        // Format back to file line - Day 3 addition
        public string ToLine()
        {
            return $"ID: {HeroID}; Name: {Name}; Age: {Age}; Superpower: {Superpower}; Exam score: {ExamScore}; Rank: {Rank}; Level of Threat: {ThreatLevel}";
        }

        // Recalculate rank and threat level - Day 3 addition
        public void RecalculateRankAndThreat()
        {
            if (ExamScore >= 81) Rank = "S-Rank";
            else if (ExamScore >= 61) Rank = "A-Rank";
            else if (ExamScore >= 41) Rank = "B-Rank";
            else Rank = "C-Rank";

            switch (Rank)
            {
                case "S-Rank":
                    ThreatLevel = "Finals Week (threat to the entire academy)";
                    break;
                case "A-Rank":
                    ThreatLevel = "Midterm Madness (threat to a department)";
                    break;
                case "B-Rank":
                    ThreatLevel = "Group Project Gone Wrong (threat to a study group)";
                    break;
                default:
                    ThreatLevel = "Pop Quiz (potential threat to an individual student)";
                    break;
            }
        }
    }
}
