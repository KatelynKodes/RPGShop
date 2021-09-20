using System;
using System.Collections.Generic;
using System.Text;
using System.IO

namespace RPGShop
{
    class Player
    {
        //Private Variable
        private int _gold;
        private Item[] _inventory;

        //Properties
        public int Gold
        {
            get { return _gold; }
        }
        public Item[] Inventory
        {
            get { return _inventory; }
        }

        /// <summary>
        /// Constructor
        /// </summary>
        public Player()
        {
            
        }

        /// <summary>
        /// Saves the player's gold and inventory items
        /// </summary>
        /// <param name="writer"></param>
        public void Save(StreamWriter writer)
        { 

        }

        /// <summary>
        /// Loads the player's gold and inventory items
        /// </summary>
        /// <param name="reader"></param>
        public bool Load(StreamReader reader)
        { 

        }

        void Buy(Item ItemToBuy)
        {
            
        }

        public string[] GetItemNames()
        { 
        }

    }
}
