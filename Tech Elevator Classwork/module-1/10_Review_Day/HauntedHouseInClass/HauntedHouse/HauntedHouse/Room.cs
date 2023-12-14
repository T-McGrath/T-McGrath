using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HauntedHouse
{
    public class Room
    {
        public string Description { get; private set; }
        public string RoomName { get; private set; }
        public List<string> Interactables { get; set; }
        public List<Room> AdjacentRooms { get; set; }

        public Room(string roomName, string description, List<string>interactables) 
        {
            RoomName = roomName;
            Description = description;
            Interactables = interactables;
            AdjacentRooms = new List<Room>();
        }
    }
}
