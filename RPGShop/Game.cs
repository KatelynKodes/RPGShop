using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

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
            StreamWriter writer = new StreamWriter("SaveData.txt");
            _player.Save(writer);
            writer.WriteLine(_currentscene);
            writer.Close();
        }

        bool Load()
        {
            StreamReader Reader = new StreamReader("SaveData.txt");
            bool LoadSuccessful = true;

            if (!_player.Load(Reader))
            {
                return LoadSuccessful = false;
            }

            if (!int.TryParse(Reader.ReadLine(), out _currentscene))
            {
                return LoadSuccessful = false;
            }

            Reader.Close();
            return LoadSuccessful;
        }

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

        /// <summary>
        /// Takes the item options and adds the options to save/load
        /// </summary>
        /// <param name="ItemOptions"></param>
        /// <returns></returns>
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
            // Displays shop menu 
            Console.Clear();
            string[] MenuOptions = GetShopMenuOptions(_shop.GetItemNames());
            Console.WriteLine("PLAYER GOLD: " + _player.Gold);
            Console.WriteLine("");
            int DisplayShop = GetInput("What would you like to purchase?", MenuOptions);

            //Checks which option the player choses
            if (DisplayShop == (MenuOptions.Length - 2 + 1) || DisplayShop == (MenuOptions.Length - 1 + 1))
            {
                if (DisplayShop == MenuOptions.Length - 2 + 1)
                {
                    Console.WriteLine("Saving your progress");
                    Save();
                    Console.WriteLine("Progress Saved");
                    Console.ReadKey(true);
                }
                else if (DisplayShop == MenuOptions.Length - 1 + 1)
                {
                    if (Load())
                    {
                        Console.WriteLine("Load Successful");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        Console.WriteLine("Load Unsuccessful");
                        Console.ReadKey(true);
                    }
                }
            }
            else
            {
                //Confirmation
                int BuyItem = GetInput("Would you like to buy " + MenuOptions[DisplayShop - 1] + "?", "Yes", "No");
                if (BuyItem == 1)
                {
                    if (_shop.SellItem(_player, DisplayShop))
                    {
                        //Player can buy the item
                        Console.WriteLine("You bought " + MenuOptions[DisplayShop - 1] + ".");
                        Console.ReadKey(true);
                    }
                    else
                    {
                        //Player Cannot buy
                        Console.WriteLine("You cannot buy " + MenuOptions[DisplayShop - 1] + ".");
                        Console.ReadKey(true);
                    }
                }
                else if (BuyItem == 2)
                {
                    return;
                }
            }
        }
    }
}
