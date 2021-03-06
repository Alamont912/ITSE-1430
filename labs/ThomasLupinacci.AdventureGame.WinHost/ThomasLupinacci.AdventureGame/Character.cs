/*
 * Written by Thomas J. Lupinacci III for TCCD ITSE-1430 on 3/31/2022
 * Lab #3
 */

using System;

namespace ThomasLupinacci.AdventureGame
{
    public class Character
    {
        /// <summary>
        /// Gets and sets character's Name.
        /// </summary>
        public string Name
        {
            get { return _name ?? ""; }
            set { _name = value; }
        }
        private string _name = "";

        /// <summary>
        /// Gets and sets character's Hobby.
        /// </summary>
        public string Hobby
        {
            get { return !String.IsNullOrEmpty(_hobby) ? _hobby : ""; }
            set { _hobby = value; }
        }
        private string _hobby = "";

        /// <summary>
        /// Gets and sets character's Profession.
        /// </summary>
        public string Profession
        {
            get { return !String.IsNullOrEmpty(_profession) ? _profession : ""; }
            set { _profession = value; }
        }
        private string _profession = "";

        /// <summary>
        /// Gets and sets character's StatGrit.
        /// </summary>
        public int StatGrit { get; set; }

        /// <summary>
        /// Gets and sets character's StatMuscle.
        /// </summary>
        public int StatMuscle { get; set; }

        /// <summary>
        /// Gets and sets character's StatMysticallity.
        /// </summary>
        public int StatMysticallity { get; set; }

        /// <summary>
        /// Gets and sets character's StatMoxie.
        /// </summary>
        public int StatMoxie { get; set; }

        /// <summary>
        /// Gets and sets character's StatGumption.
        /// </summary>
        public int StatGumption { get; set; }

        /// <summary>
        /// Gets and sets character's Backstory.
        /// </summary>
        public string Backstory
        {
            get { return !String.IsNullOrEmpty(_backstory) ? _backstory : ""; }
            set { _backstory = value; }
        }
        private string _backstory = "";

        /// <summary>
        /// Unique Id associated with the character. Is managed by an implemented roster, is '0' otherwise.
        /// </summary>
        public int Id
        {
            get { return _id; }
            set { _id = value; }
        }
        private int _id = 0;

        /// <summary>
        /// Determines if a character is valid or not.
        /// </summary>
        /// <returns>Returns true if valid, false otherwise.</returns>
        public string Validate()
        {
            if (String.IsNullOrEmpty(Name))
                return "A name is required.";
            if (String.IsNullOrEmpty(Hobby))
                return "A hobby is required.";
            if (String.IsNullOrEmpty(Profession))
                return "A profession is required.";

            if (StatGrit < 1 || StatGrit > 100)
                return "Your Grit must be between 1 and 100.";
            if (StatMuscle < 1 || StatMuscle > 100)
                return "Your Muscle must be between 1 and 100.";
            if (StatMysticallity < 1 || StatMysticallity > 100)
                return "Your Mysticallity must be between 1 and 100.";
            if (StatMoxie < 1 || StatMoxie > 100)
                return "Your Moxie must be between 1 and 100.";
            if (StatGumption < 1 || StatGumption > 100)
                return "Your Gumption must be between 1 and 100.";

            return "";
        }
        public override string ToString ()
        {
            return $"{_name} the {_hobby} {_profession}";
        }

        public Character Copy ()
        {
            return new Character() {
                Name = Name,
                Hobby = Hobby,
                Profession = Profession,
                StatGrit = StatGrit,
                StatMuscle = StatMuscle,
                StatMysticallity = StatMysticallity,
                StatMoxie = StatMoxie,
                StatGumption = StatGumption,
                Backstory = Backstory,
                Id = Id
            };
        }

        public void CopyFrom(Character source)
        {
            Name = source.Name;
            Hobby = source.Hobby;
            Profession = source.Profession;
            StatGrit = source.StatGrit;
            StatMuscle = source.StatMuscle;
            StatMysticallity = source.StatMysticallity;
            StatMoxie = source.StatMoxie;
            StatGumption = source.StatGumption;
            Backstory = source.Backstory;
        }
    }
}