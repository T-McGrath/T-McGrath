﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseYourOwnAdventure
{
    public class Player
    {
        public List<string> Items = new List<string>();

        public void AddItem(string item)
        {
            Items.Add(item);
        }
        
    }
}