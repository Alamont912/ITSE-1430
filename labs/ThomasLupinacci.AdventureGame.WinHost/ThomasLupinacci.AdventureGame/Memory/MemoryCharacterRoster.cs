using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThomasLupinacci.AdventureGame.Memory
{
    public class MemoryCharacterRoster : ICharacterRoster
    {
        private readonly List<Character> _characters = new List<Character>();

        public Character Add( Character character)
        {
            if(ValidateCharacter(character) != null)
            {
                character.Id = _id;
                _id++;

                _characters.Add( character );

                return character.Copy();
            }


            return null;
        }

        public Character ValidateCharacter( Character character ) //replace using IValidatableObject
        {
            if (character == null)
                return null;

            if (!String.IsNullOrEmpty(character.Validate()))
                return null;

            if (FindByName(character.Name) != null)
                return null;

            //If gotten this far, character is valid
            //assign ID, increment ID for next character,
            //put character in list, return a COPY of the character

            return character;
        }

        public Character FindByName( string name )
        {
            foreach(var character in _characters)
                if(String.Equals(character.Name, name, StringComparison.CurrentCultureIgnoreCase))
                    return character;

            return null;
        }

        //Simple identifier system
        private int _id = 1;
    }
}
