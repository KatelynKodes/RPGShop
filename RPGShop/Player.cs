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
        private int _inventoryLength;

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
            _gold = 100;
            _inventory = new Item[0];
        }

        /// <summary>
        /// Saves the player's gold and inventory items
        /// </summary>
        /// <param name="writer"></param>
        public void Save(StreamWriter writer)
        {
            writer.WriteLine(_gold);
            writer.WriteLine(_inventoryLength);
            for (int i = 0; i < _inventory.Length; i++)
            {
                writer.WriteLine(_inventory[i].itemName);
                writer.WriteLine(_inventory[i].Cost);
            }
        }

        /// <summary>
        /// Loads the player's gold and inventory items
        /// </summary>
        /// <param name="reader"></param>
        public bool Load(StreamReader reader)
        {
            if (!int.TryParse(reader.ReadLine(), out _gold))
            {
                return false;
            }

            if (!int.TryParse(reader.ReadLine(), out _inventoryLength))
            {
                return false;
            }

            for (int i = 0; i < _inventoryLength; i++)
            {
                if (reader.ReadLine() != _inventory[i].itemName)
                {
                    return false;
                }
                if (!int.TryParse(reader.ReadLine(), out _inventory[i].Cost))
                {
                    return false;
                }
            }
             
            return true;
        }

        public void Buy(Item ItemToBuy)
        {
            _gold -= ItemToBuy.Cost;
            Item[] NewInventory = new Item[_inventory.Length+1];
            for (int i = 0; i < _inventory.Length; i++)
            {
                NewInventory[i] = _inventory[i];

            }

            NewInventory[NewInventory.Length - 1] = ItemToBuy;
            _inventory = NewInventory;
            _inventoryLength = _inventory.Length;
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
