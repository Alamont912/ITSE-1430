using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasLupinacci.AdventureGame
{
    /// <summary>
    /// Public interface for making rosters of characters
    /// </summary>
    public interface ICharacterRoster
    {
        Character Add (Character character);
    }
}
