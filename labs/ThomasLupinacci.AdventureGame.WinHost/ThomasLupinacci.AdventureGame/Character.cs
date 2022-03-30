namespace ThomasLupinacci.AdventureGame
{
    public class Character
    {
        /// <summary>
        /// Gets and sets character's Name.
        /// </summary>
        public string Name { get; set; } = "";

        /// <summary>
        /// Gets and sets character's Hobby.
        /// </summary>
        public string Hobby { get; set; } = "";

        /// <summary>
        /// Gets and sets character's Profession.
        /// </summary>
        public string Profession { get; set; } = "";

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
        public string Backstory { get; set; } = "";

        /// <summary>
        /// Determines if a character is valid or not.
        /// </summary>
        /// <returns>Returns true if valid, false otherwise.</returns>
        public bool Validate()
        {
            int min = 1;
            int max = 100;
            if (String.IsNullOrEmpty(Name) || String.IsNullOrEmpty(Hobby) || String.IsNullOrEmpty(Profession) ||
                StatGrit < min || StatGrit > max ||
                StatMuscle < min || StatMuscle > max ||
                StatMysticallity < min || StatMysticallity > max ||
                StatMoxie < min || StatMoxie > max ||
                StatGumption < min || StatGumption > max)
            {
                return false;
            } else
                return true;
        }
    }
}