/*
 * Thomas J. Lupinacci III
 * 3/7/22
 * ITSE 1430
*/
using System;

namespace ThomasJLupinacci.AdventureGame
{
    /// <summary>
    /// Represents a room.
    /// </summary>
    public class Room
    {
        /// <summary>
        /// Room constructor requiring a Room Name and Description.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="description"></param>
        public Room(string name, string description)
        {
            Name = name;
            Description = description;
        }

        /// <summary>
        /// Gets or sets a Room's Name.
        /// </summary>
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        private string _name;

        /// <summary>
        /// Gets or sets a Room's Description.
        /// </summary>
        public string Description
        {
            get { return _description; }
            set { _description = value; }
        }
        private string _description;

        /// <summary>
        /// Gets or sets which Room is North of the current Room.
        /// Default value is null, meaning no adjacent Room.
        /// </summary>
        public Room North
        {
            get { return _north; }
            set { _north = value; }
        }
        private Room _north;

        /// <summary>
        /// Gets or sets which Room is East of the current Room.
        /// Default value is null, meaning no adjacent Room.
        /// </summary>
        public Room East
        {
            get { return _east; }
            set { _east = value; }
        }
        private Room _east;

        /// <summary>
        /// Gets or sets which Room is South of the current Room.
        /// Default value is null, meaning no adjacent Room.
        /// </summary>
        public Room South
        {
            get { return _south; }
            set { _south = value; }
        }
        private Room _south;

        /// <summary>
        /// Gets or sets which Room is West of the current Room.
        /// Default value is null, meaning no adjacent Room.
        /// </summary>
        public Room West
        {
            get { return _west; }
            set { _west = value; }
        }
        private Room _west;
    }

    /// <summary>
    /// Represents and builds the game World out of Room instances.
    /// </summary>
    public class World
    {
        /// <summary>
        /// Generates game Rooms, links Rooms, and sets Starting Room.
        /// </summary>
        public World()
        {
            //Generate each room
            Room Room_1 = new Room("The Endless Mines", "A mineshaft with no end. Endless resources at the cost of endless danger.");

            Room Room_2 = new Room("Mt. Twinfang", "A pair of purdy twin peaks shaped like a snake's fangs.");

            Room Room_3 = new Room("The Badlands", "Godless lands just teamin' with bandits.");

            Room Room_4 = new Room("The Grizzly Woods", "A dense forest filled with a variety of flora and fauna.");

            Room Room_5 = new Room("The Great Plains", "Golden fields that stretch for miles.");

            Room Room_6 = new Room("The Snake Pits", "The pockets, divots, and craters that dot this rocky area make it a perfect breeding ground for deadly land serpents of all kinds.");

            Room Room_7 = new Room("Horseshoe Lake", "A flourishing sight to behold with fish in the curved lake and horses in the center delta.");

            Room Room_8 = new Room("The Town of Dysentery", "A small, crumbling hub town. Don't drink the water.");

            Room Room_9 = new Room("Wildstyle Ranch", "A decently-maintained cow, sheep, and horse ranch with ranchhands who like to party.");

            //Link each room
            Room_1.North = null;
            Room_1.East = Room_2;
            Room_1.South = Room_4;
            Room_1.West = null;

            Room_2.North = null;
            Room_2.East = Room_3;
            Room_2.South = Room_5;
            Room_2.West = Room_1;

            Room_3.North = null;
            Room_3.East = null;
            Room_3.South = Room_6;
            Room_3.West = Room_2;

            Room_4.North = Room_1;
            Room_4.East = Room_5;
            Room_4.South = Room_7;
            Room_4.West = null;

            Room_5.North = Room_2;
            Room_5.East = Room_6;
            Room_5.South = Room_8;
            Room_5.West = Room_4;

            Room_6.North = Room_3;
            Room_6.East = null;
            Room_6.South = Room_9;
            Room_6.West = Room_5;

            Room_7.North = Room_4;
            Room_7.East = Room_8;
            Room_7.South = null;
            Room_7.West = null;

            Room_8.North = Room_5;
            Room_8.East = Room_9;
            Room_8.South = null;
            Room_8.West = Room_7;

            Room_9.North = Room_6;
            Room_9.East = null;
            Room_9.South = null;
            Room_9.West = Room_8;

            //Set starting room
            StartingRoom = Room_8;
        }

        /// <summary>
        /// Gets and sets the World's introduction lines. Has a default vaule;
        /// </summary>
        public string Introduction { get; set; } = "Welcome to the Wild Wastes, pardner!\n" +
                                                   "Use the menu to explore!\n\n";

        /// <summary>
        /// Gets and sets the Room the Player starts in.
        /// </summary>
        public Room StartingRoom { get; set; }

    }

    /// <summary>
    /// Represents the Player. Sets Starting Room upon creation and tracks the Player's Current Room.
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Sets the Player's Current Room to the passed Room.
        /// </summary>
        /// <param name="Start"></param>
        public Player(Room Start)
        {
            CurrentRoom = Start;
        }

        /// <summary>
        /// Keeps track of the Player's Current Room.
        /// </summary>
        public Room CurrentRoom { get; set; }
    }
}
