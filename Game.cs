using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
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
                Console.WriteLine("Welcome Player 1! Please select your desired equipment.");
                Console.Write(">");
                GetInput(out input, "Sword", "Axe", "Musket");

                if (input == '1')
                {
                  player1.health = 100;
                  player1.damage += 25;
                  player1.defense = 10;
                  Console.WriteLine("*You pick up the sword*");
                  Console.WriteLine("*You feel a new found sense of honor flow through you*");
                }

                if (input == '2')
                {
                  player1.health = 100;
                  player1.damage = 40;
                  player1.defense = 5;
                  Console.WriteLine("*You pick up the axe*");
                  Console.WriteLine("*You feel a strong rush of adrenaline");
                }

                if (input == '3')
                {
                  player1.health = 100;
                  player1.damage = 100;
                  player1.defense = 0;
                  Console.WriteLine("*You pick up the musket*");
                  Console.WriteLine("*You feel like commiting acts of violence*");
                }
                Console.WriteLine("\nOk, Player 2 choose your weapon I guess...");
                Console.Write(">");
                GetInput(out input, "Sword", "Axe", "Musket");

                if (input == '1')
                {
                    player2.health = 100;
                    player2.damage += 25;
                    player2.defense = 10;
                    Console.WriteLine("*You pick up the sword*");
                    Console.WriteLine("*You feel a new found sense of dumbness flow through you*");
                }

                if (input == '2')
                {
                    player2.health = 100;
                    player2.damage = 40;
                    player2.defense = 5;
                    Console.WriteLine("*You pick up the axe*");
                    Console.WriteLine("*You feel a strong rush of dumb");
                }

                if (input == '3')
                {
                    player2.health = 100;
                    player2.damage = 100;
                    player2.defense = 0;
                    Console.WriteLine("*You pick up the musket*");
                    Console.WriteLine("*You feel like commiting acts of violence except you're dumb so you can't*");
                }
             }
            Console.WriteLine("Press any key to continue");
            Console.ReadKey();
            Console.Clear();
        }
        void playerStats(Player player1, Player player2)
        {//displays player1 stats
            Console.WriteLine("\nPlayer 1");
            Console.WriteLine("Health: " + player1.health);
            Console.WriteLine("Damage: " + player1.damage);
            Console.WriteLine("Defense: " + player1.defense);
            //displays player2 stats
            Console.WriteLine("\nPlayer 2");
            Console.WriteLine("Health: " + player2.health);
            Console.WriteLine("Damage: " + player2.damage);
            Console.WriteLine("Defense: " + player2.defense);
        }
        void Combat()
        {//multiplayer combat that loops until either is dead
            while(player1.health > 0 && player2.health > 0)
            {
                //prints player stats to the screen
                playerStats(player1, player2);
                char input;
                Console.WriteLine("\nPlayer1");
                GetInput(out input, "Attack", "Defend", "Item");
                if (input == '1')
                {//if option 1 is selected the player will attack
                    Console.Clear();
                    Console.WriteLine("\nYou attack for " + player1.damage + "damage");
                    player2.health -= player1.damage;
                    Console.Write(">");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (input == '2')
                {//if option 2 is selected the player only takes half the original damage
                    Console.WriteLine("You took half the damage! " + player2.damage / 2 + " damage");
                    player2.health -= player1.damage / 2;
                    Console.Write(">");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (input == '3')
                {//if option 3 is selected the player will use the potion item
                    Console.WriteLine("You use a potion");
                    if(player1.health <= 90)
                    {
                        Console.WriteLine("You drink it succesfully");
                        player1.health += 10;
                    }
                    else if(player1.health >= 91)
                    {
                        Console.WriteLine("But nothing happened...");
                    }
                }
                if (player2.health <= 0)
                {
                    break;
                }

                Console.WriteLine("Player2");
                GetInput(out input, "Attack", "Defend", "Item");
                if (input == '1')
                {//if option 1 is selected the player will attack
                    Console.Clear();
                    Console.WriteLine("\nYou attack for " + player2.damage + "damage");
                    player1.health -= player2.damage;
                    Console.Write(">");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (input == '2')
                {//if option 2 is selected the player only takes half the original damage
                    Console.WriteLine("You took half the damage! " + player1.damage / 2 + " damage");
                    player2.health -= player1.damage / 2;
                    Console.Write(">");
                    Console.ReadKey();
                    Console.Clear();
                }

                if (input == '3')
                {//if option 3 is selected the player will use the potion item
                    Console.WriteLine("You use a potion");
                    if (player2.health <= 90)
                    {
                        Console.WriteLine("You drink it succesfully");
                        player2.health += 10;
                    }
                    else if (player2.health >= 91)
                    {
                        Console.WriteLine("But nothing happened...");
                    }
                }

            }
            _gameOver = true;
        }

        public void Start()
        {
            ChooseEquipment();
        }

        public void Update()
        {
            Combat();
        }

        public void End()
        {
            if (player1.health <= 0)
            {
                Console.WriteLine("Gameover...");
                return;
            }
            Console.WriteLine("Finally, someone vanquished player2!!!");
           
        }
    }
}
