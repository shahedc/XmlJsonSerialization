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
                    ShortName = "IM1",
                    Sequel = "IM2"
                },
                new CinematicItem
                {
                    Title = "Iron Man 2",
                    Description = "Sequel to the first Iron Man movie.",
                    Rating = "PG-13",
                    ShortName = "IM2",
                    Sequel = "IM3"
                },
                new CinematicItem
                {
                    Title = "Iron Man 3",
                    Description = "Wraps up the Iron Man trilogy.",
                    Rating = "PG-13",
                    ShortName = "IM3",
                    Sequel = ""
                },
                new CinematicItem
                {
                    Title = "The Avengers",
                    Description = "End of MCU Phase 1",
                    Rating = "PG-13",
                    ShortName = "AV1",
                    Sequel = "AV2"
                },
                new CinematicItem
                {
                    Title = "Avengers: Age of Ultron",
                    Description = "2nd Avengers movie",
                    Rating = "PG-13",
                    ShortName = "AV2",
                    Sequel = "AV3"
                },
                new CinematicItem
                {
                    Title = "Avengers: Infinity War",
                    Description = "3rd Avengers movie",
                    Rating = "PG-13",
                    ShortName = "AV3",
                    Sequel = "AV4"
                },
                new CinematicItem
                {
                    Title = "Avengers: Endgame",
                    Description = "4th Avengers movie",
                    Rating = "PG-13",
                    ShortName = "AV4",
                    Sequel = ""
                },
            }
            .OrderBy(ci => ci.Title).ToList();
        }
               
        public CinematicItem GetByShortName(string shortName)
        {
            return CinematicItems().FirstOrDefault(ci => ci.ShortName == shortName);
        }

        public CinematicItem GetBySequel(string sequelShortName)
        {
            return CinematicItems().FirstOrDefault(ci => ci.Sequel == sequelShortName);
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
