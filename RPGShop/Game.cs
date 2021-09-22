using System;
using System.Collections.Generic;
using System.Text;

namespace RPGShop
{
    public struct Item
    {
        public int Cost;
        public string itemName;
    }


    class Game
    {
        private bool _Gameover;
        private int _currentscene;
        private Shop _shop;
        private Player _player;

        public void Run()
        {
            Start();
            while (!_Gameover)
            {
                Update();
            }
        }

        void Start()
        {
            _currentscene = 1;
            _player = new Player();
            _shop = new Shop();
            InitializeItems();
        }

        void Update()
        {
            DisplayCurrentScene();
        }

        void End()
        {
            Console.WriteLine("This is the end of the program, please close the application.");
        }

        void Save()
        {

        }

        //bool Load()

        void InitializeItems()
        {
            Item Sword = new Item { Cost = 30, itemName = "Sword" };
            Item Apple = new Item { Cost = 5, itemName = "Apple" };
            Item MagicDust = new Item { Cost = 50, itemName = "Magic Dust" };
            Item LegendSword = new Item { Cost = 100, itemName = "Legendary Sword." };

            Item[] ShopInventory = new Item[] { Sword, Apple, MagicDust, LegendSword };
            _shop.shopItemsAvailable(ShopInventory);
        }


        /// <summary>
        /// Displays a set of options for the player to chose from.
        /// </summary>
        /// <param name="desc"></param>
        /// <param name="options"></param>
        /// <returns></returns>
        int GetInput(string desc, params string[] options)
        {
            int InputRecieved = -1;

            //Write out the options
            Console.WriteLine(desc);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine("[" + (i+1) + "] " + options[i]);
            }
            Console.Write(">");

            //Start taking input
            while (InputRecieved == -1)
            {
                string PlayerInput = Console.ReadLine();
                bool InputSuccess = int.TryParse(PlayerInput, out InputRecieved);

                // check if input was actually a number
                if (InputSuccess)
                {
                    //If the input is greater than the length of options or less than 0
                    //return invalid input
                    if (InputRecieved > options.Length || InputRecieved < 0)
                    {
                        InputRecieved = -1;
                        Console.WriteLine("Invalid input.");
                        Console.Write(">");
                    }
                }
                else
                {
                    //If not actually a number, return invalid input
                    InputRecieved = -1;
                    Console.WriteLine("Invalid input.");
                    Console.Write(">");
                }
            }

            return InputRecieved;
        }


        /// <summary>
        /// Displays the current scene the player is in
        /// </summary>
        void DisplayCurrentScene()
        {
            switch (_currentscene)
            {
                case 1:
                    DisplayOpeningMenu();
                    break;
                case 2:
                    DisplayShopMenu();
                    break;
            }
        }

        /// <summary>
        /// Displays the opening menu allowing the player to start/quit the game
        /// </summary>
        void DisplayOpeningMenu()
        {
            int EnterShop = GetInput("Enter shop?", "Yes", "No");
            if (EnterShop == 1)
            {
                _currentscene = 2;
            }
            else
            {
                _Gameover = true;
            }
        }

        string[] GetShopMenuOptions(string[] ItemOptions)
        {
            string[] ShopOptions = new string[ItemOptions.Length + 2];

            for (int i = 0; i < ItemOptions.Length; i++)
            {
                ShopOptions[i] = ItemOptions[i];
            }

            ShopOptions[ShopOptions.Length - 2] = "Save";
            ShopOptions[ShopOptions.Length - 1] = "Load";

            return ShopOptions;
        }

        void DisplayShopMenu()
        {
            Console.Clear();
            string[] MenuOptions = GetShopMenuOptions(_shop.GetItemNames());
            int DisplayShop = GetInput("What would you like to purchase?", MenuOptions);
            if (DisplayShop != ((MenuOptions.Length - 2) + 1) || DisplayShop != ((MenuOptions.Length - 1) + 1))
            {
                int BuyItem = GetInput("Would you like to buy" + MenuOptions[DisplayShop] + "?", "Yes", "No");
                if (BuyItem == 1)
                {
                    if (_shop.SellItem(_player, ))
                    {

                    }
                    else
                    {
                        Console.WriteLine("You cannot buy" + MenuOptions[DisplayShop]+ ".");
                        Console.ReadKey(true);
                    }
                }
                else if (BuyItem == 2)
                {
                    return;
                }
            }
            else
            {
                if (DisplayShop == ((MenuOptions.Length - 2) + 1))
                {
                    //Save
                }
                else if (DisplayShop == ((MenuOptions.Length - 1) + 1))
                { 
                    //Load
                }
            }
        }
    }
}
