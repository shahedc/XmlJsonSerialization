using System.Collections.Generic;
using XmlJsonSerialization.Models;

namespace XmlJsonSerialization.Infrastructure
{
    public interface ICinematicItemRepository
    {
        List<CinematicItem> CinematicItems();
        CinematicItem GetByShortName(string shortName);
        CinematicItem GetBySequel(string sequelShortName);
        List<CinematicItem> GetByPartialName(string nameSubstring);
    }
}