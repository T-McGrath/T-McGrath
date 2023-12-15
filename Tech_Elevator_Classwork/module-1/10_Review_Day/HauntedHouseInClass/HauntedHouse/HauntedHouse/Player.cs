using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse
{
    public class Player
    {
        public string Name { get; set; }
        public int Health { get; set; } = 3;
        public Dictionary<string, int> Inventory { get; set; }
        public Room CurrentRoom { get; set; }
        public int DamageDealt { get; set; } = 1;

        public Player(string name, Room startingRoom)
        {
            Name = name;
            CurrentRoom = startingRoom;
            Inventory = new Dictionary<string, int>();
        }

        public bool MoveToRoom(Room room)
        {
            if (CurrentRoom.AdjacentRooms.Contains(room))
            {
                CurrentRoom = room;
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PickUpItem(string itemName)
        {
            if (Inventory.ContainsKey(itemName))
            {
                Inventory[itemName] += 1;
            }
            else
            {
                Inventory[itemName] = 1;
            }
        }
        public bool RemoveItem(string itemName)
        {
            if (Inventory.ContainsKey(itemName))
            {
                Inventory[itemName] -= 1;
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
