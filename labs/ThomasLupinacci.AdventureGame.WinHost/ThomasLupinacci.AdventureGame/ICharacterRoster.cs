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
        /// <summary>
        /// Adds a new character to the roster.
        /// </summary>
        /// <param name="character">Character to be validated and added</param>
        /// <returns>Returns a Character</returns>
        Character Add (Character character);

        /// <summary>
        /// Retrieves all characters in the roster
        /// </summary>
        /// <returns></returns>
        IEnumerable<Character> GetAll ();

        /// <summary>
        /// Updates a character within the roster.
        /// </summary>
        /// <param name="ID">ID of character</param>
        /// <param name="character">Character data</param>
        /// <returns>String with error message</returns>
        string Update(int ID, Character character);

        /// <summary>
        /// Removes a character from the roster.
        /// </summary>
        /// <param name="ID">ID of character</param>
        /// <returns>String with error message</returns>
        string Delete(int ID);
    }
}
