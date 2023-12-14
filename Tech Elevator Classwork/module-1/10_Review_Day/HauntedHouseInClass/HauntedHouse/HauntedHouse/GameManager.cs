using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse
{
    public class GameManager
    {
        public Room FirstRoom { get; set; }
        public Player Player { get; set; }


        public void DisplayRoom(Room room)
        {
            Console.WriteLine(room.RoomName);
            Console.WriteLine(room.Description);
            foreach(string thing in room.Interactables)
            {
                Console.WriteLine($"There is a {thing}");
            }
        }

        public void DisplayChoices(string[] choices)
        {
            string choice = MenuDisplay.Prompt(choices);

        }

        public void StartGame()
        {
            string choice = MenuDisplay.Prompt(new string[] { "Start Game", "Quit Game" });
            if(choice.Equals("Start Game"))
            {
                Player = MakePlayer();
                DisplayRoom(Player.CurrentRoom);
            }
        }

        public Player MakePlayer()
        {
            Player player = new Player("Bob", FirstRoom);
            return player;
        }
        public GameManager()
        {
            FirstRoom = new Room("The Wet Oval Office", "It is wet in here.", new List<string>() { "desk", "light in the distance", "surplus of water", "presidential rocket ship" });
        }
    }
}
