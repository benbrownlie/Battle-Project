using System;
using System.Collections.Generic;
using System.Text;

namespace HelloWorld
{
    class Game
    {
        struct Player
        {
            public float health;
            public int damage;
            public int defense;
            public bool alive;
        }
        struct Items
        {
            public string itemName;
            public int damageBoost;
        }
        bool _gameOver = false;
        Player player1;
        Player player2;
        Items sword;
        Items axe;
        Items musket;
        public void Run()
        {
            Start();

            while(_gameOver == false)
            {
                Update();
            }

            End();
        }

        void GetInput(out char input, string option1, string option2, string option3)
        {
            Console.WriteLine("What will you do?");
            input = ' ';
            while (input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("1. " + option1);
                Console.WriteLine("2. " + option2);
                Console.WriteLine("3. " + option3);
                input = Console.ReadKey().KeyChar;
                Console.WriteLine();

            }
        }
        void ChooseEquipment()
        {
            char input = ' ';
            while(input != '1' && input != '2' && input != '3')
            {
                Console.WriteLine("Welcome! Please select your desired equipment.");
                Console.Write(">");
                GetInput(out input, "Sword", "Axe", "Musket");

                if (input == '1')
                {
                  player1.health = 100;
                  player1.damage += sword.damageBoost;
                  player1.defense = 10;
                  Console.WriteLine("*You pick up the sword*");
                  Console.WriteLine("*You feel a new found sense of honor flow through you*");
                }

                if (input == '2')
                {
                  player1.health = 100;
                  player1.damage = axe.damageBoost;
                  player1.defense = 5;
                  Console.WriteLine("*You pick up the axe*");
                  Console.WriteLine("*You feel a strong rush of adrenaline");
                }

                if (input == '3')
                {
                  player1.health = 100;
                  player1.damage = musket.damageBoost;
                  player1.defense = 0;
                  Console.WriteLine("*You pick up the musket*");
                  Console.WriteLine("*You feel like commiting acts of violence*");
                }
             }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        void Combat()
        {
            while(player1.health > 0 && player2.health > 0)
            {
                char input;
                GetInput(out input, "Attack", "Defend", "Item");
                if (input == '1')
                {
                    Console.Clear();
                    Console.WriteLine("You ");
                }

            }
        }

        public void Start()
        {
            ChooseEquipment();
        }

        public void Update()
        {

        }

        public void End()
        {

        }
    }
}
