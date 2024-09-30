using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obligatorisk_Opg1
{
    public class TrophiesRepository
    {
        private List<Trophy> trophies = new List<Trophy>();
        private int nextId = 1;

        public Trophy AddTrophy(Trophy trophy)
        {
            trophy.ValidateAll();
            trophy.ID = nextId++;
            trophies.Add(trophy);
            return trophy;
        }
        public List<Trophy> GetTrophies(int? year = null, string? sortBy = null)
        {
            List<Trophy> result = new List<Trophy>(trophies);
            if (year != null)
            {
                result = result.Where(t => t.Year > year).ToList();
            }
            if (sortBy != null)
            {
                switch (sortBy.ToLower())
                {
                    case "competition":
                        result.Sort((t1, t2) => t1.Competition.CompareTo(t2.Competition));
                        break;
                    case "competitiondesc":
                        result.Sort((t1, t2) => t2.Competition.CompareTo(t1.Competition));
                        break;
                    case "year":
                        result.Sort((t1, t2) => (t1.Year ?? 0) - (t2.Year ?? 0));
                        break;
                    default:
                        throw new ArgumentException("Sorting error");
                }
            }
            return result;
        }
        public Trophy GetTrophyById(int id)
        {
            return trophies.FirstOrDefault(t => t.ID == id);
        }
        public void RemoveTrophy(int id)
        {
            trophies.Remove(GetTrophyById(id));
        }
        public Trophy UpdateTrophy(int id, Trophy values)
        {
            Trophy existingTrophy = GetTrophyById(id);
            if (existingTrophy != null)
            {
                existingTrophy.Competition = values.Competition;
                existingTrophy.Year = values.Year;
                existingTrophy.ValidateAll();
            }
            else
            {
                return null;
            }
            return existingTrophy;
        }
    }
}
