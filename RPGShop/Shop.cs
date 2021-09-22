using System;
using System.Collections.Generic;
using System.Text;
using System.IO;


namespace RPGShop
{
    class Shop
    {
        //Private vars
        private int _gold;
        private Item[] _item;

        /// <summary>
        /// Sets the inventory for the shop so the player is able to buy
        /// RENAMED THE FUNCTION BECAUSE THE ORIGINAL NAME WAS UNCLEAR
        /// </summary>
        /// <param name="ForSale"></param>
        public void shopItemsAvailable(Item[] ForSale)
        {
            _item = new Item[ForSale.Length];

            for (int i = 0; i < ForSale.Length; i++)
            {
                _item[i] = ForSale[i];
            }
        }

        /// <summary>
        /// Checks if the item can be sold to the player
        /// </summary>
        /// <param name="player"></param>
        /// <param name="SellPrice"></param>
        /// <returns></returns>
        public bool SellItem(Player player, int ItemIndex)
        {
            if (player.Gold < _item[ItemIndex].Cost)
            {
                player.Buy(_item[ItemIndex]);
                return false;
            }
            else
            {
                return true;
            }
        }


        /// <summary>
        /// Gets Item names from the shops inventory
        /// </summary>
        /// <returns></returns>
        public string[] GetItemNames()
        {
            string[] ItemNames = new string[_item.Length];
            for (int i = 0; i < _item.Length; i++)
            {
                ItemNames[i] = _item[i].itemName;
            }

            return ItemNames;
        }

    }
}
