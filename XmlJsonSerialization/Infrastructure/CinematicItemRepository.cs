using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XmlJsonSerialization.Models;

namespace XmlJsonSerialization.Infrastructure
{
    public class CinematicItemRepository: ICinematicItemRepository
    {
        public List<CinematicItem> CinematicItems()
        {
            return new List<CinematicItem>
            {
                new CinematicItem
                {
                    Title = "Iron Man 1",
                    Description = "First movie to kick off the MCU.",
                    Rating = "PG-13",
                    ShortName = "IM1"
                },
                new CinematicItem
                {
                    Title = "Iron Man 2",
                    Description = "Sequel to the first Iron Man movie.",
                    Rating = "PG-13",
                    ShortName = "IM2"
                },
                new CinematicItem
                {
                    Title = "Iron Man 3",
                    Description = "Wraps up the Iron Man trilogy.",
                    Rating = "PG-13",
                    ShortName = "IM3"
                },
                new CinematicItem
                {
                    Title = "The Avengers",
                    Description = "End of MCU Phase 1",
                    Rating = "PG-13",
                    ShortName = "AV1"
                },
            }
            .OrderBy(ci => ci.Title).ToList();
        }
               
        public CinematicItem GetByShortName(string shortName)
        {
            var cinematicItems = CinematicItems();
            return cinematicItems.FirstOrDefault(ci => ci.ShortName == shortName);
        }
        
        public List<CinematicItem> GetByPartialName(string titleFragment)
        {
            return CinematicItems()
                .Where(ci => ci.Title
                    .IndexOf(titleFragment, 0, StringComparison.CurrentCultureIgnoreCase) != -1)
                .ToList();
        }

    }
}
