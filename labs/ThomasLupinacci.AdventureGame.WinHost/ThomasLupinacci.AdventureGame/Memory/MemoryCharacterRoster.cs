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

        public IEnumerable<Character> GetAll ()
        {
            foreach (var character in _characters)
            {
                yield return character.Copy();
            }
        }

        public string Update(int ID, Character character)
        {
            if (ID <= 0)
                return "ID must be greater than 0.";

            if (character == null)
                return "Character does not exist.";

            if (!String.IsNullOrEmpty(character.Validate()))
                return character.Validate(); ;

            if (FindByID(ID) == null)
                return "Character does not exist in roster.";

            if (FindByName(character.Name) != null)                 //if name exists in roster
                if (FindByName(character.Name).Id != ID)            //but ID's don't match
                    return "Another movie already has this Title."; //then another movie has this name already
                                                                    //else, continue

            FindByID(ID).CopyFrom(character);
            return "Update Successful!";
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

        public Character FindByID(int ID)
        {
            foreach(var character in _characters)
                if(ID == character.Id)
                    return character;
            return null;
        }

        //Simple identifier system
        private int _id = 1;
    }
}
