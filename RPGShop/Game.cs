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
        public void Run()
        {

        }

        void Start()
        { 
        }

        void Update()
        {
            
        }
        void End()
        { 

        }

        void Save()
        {
            
        }

        bool Load()
        {
            
        }

        void InitializeItems()
        { 
        }

        int GetInput(string desc, params string[] options)
        {
            Console.WriteLine(desc);
            for (int i = 0; i < options.Length; i++)
            {
                Console.WriteLine("[" + i + "] " + options[i]);
            }

            while()
        }

        void DisplayCurrentScene()
        { 

        }

        void DisplayOpeningMenu()
        {
            
        }

        string[] GetShopMenuOptions(string[] shopOptions)
        { 

        }

        void DisplayShopMenu()
        {
            
        }
    }
}
