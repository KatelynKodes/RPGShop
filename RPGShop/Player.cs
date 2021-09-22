using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
        //public bool Load(StreamReader reader)

        public void Buy(Item ItemToBuy)
        {
            Item[] NewInventory = new Item[_inventory.Length+1];
            for (int i = 0; i < _inventory.Length; i++)
            {
                NewInventory[i] = _inventory[i];

            }

            NewInventory[NewInventory.Length - 1] = ItemToBuy;
            _inventory = NewInventory;
        }


        /// <summary>
        /// Gets Item Names
        /// </summary>
        /// <returns></returns>
        public string[] GetItemNames()
        {
            string[] ItemNames = new string[_inventory.Length];
            for (int i = 0; i < _inventory.Length; i++)
            {
                ItemNames[i] = _inventory[i].itemName;
            }

            return ItemNames;
        }
    }
}
