using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("WELCOME TO HERO ACADEMY");

        Console.Write("Enter hero name: ");
        string heroName = Console.ReadLine();
        Console.WriteLine("Now it's time to select your class");
        Console.WriteLine("There are 5 classes: 0) Hands 1) Sword 2) Ranged 3) Wizard 4) Summoner");
        int fightClass = int.Parse(Console.ReadLine());
        Hero myHero = new Hero(heroName, fightClass);
        Menu(myHero);
    }
    static void Menu(Hero obj)
    {
        Console.WriteLine("What do you want to do now?");
        Console.WriteLine("1) Train 2) Stats 3) Left the game");
        int selectedOption = int.Parse(Console.ReadLine());
        switch (selectedOption)
        {
            case 1:
                {
                    Fight(obj);
                    break;
                }
            case 2:
                {
                    Stats(obj);
                    break;
                };
            default:
                {
                    break;
                }


        }
    }
    static void Stats(Hero obj)
    {
    }
        static void Fight(Hero Character)
        {
            var Enemie = new Enemy();
            Console.WriteLine($"CAREFULL, A {Enemie.name} SPAWNED");

            while (Character.Hp > 0 && Enemie.Hp > 0)
            {
                Console.WriteLine("What do you want to do: ");
                Console.WriteLine("1) Attack  2) Skill ");
                int optionSelected = int.Parse(Console.ReadLine());

                // Acciones del jugador
                switch (optionSelected)
                {
                    case 1:
                        Console.WriteLine($"YOU ATTACKED YOUR ENEMY AND DEALED {Character.Str} DAMAGE");
                        Enemie.Hp -= Character.Str;
                        break;

                    case 2:
                        if (Character.energy > 0)
                        {
                            Character.UseSkill();
                            Enemie.Hp -= Character.Str * 1.5;
                        }
                        else
                        {
                            Console.WriteLine("No more skill uses left!");
                        }
                        break;

                    default:
                        break;
                }
                Console.WriteLine($"{Enemie.name} ATTACKS YOU AND DEALS {Enemie.Str} DAMAGE");
                Character.Hp -= Enemie.Str;
            }
            if (Character.Hp <= 0)
            {
                Console.WriteLine("YOU WERE DEFEATED!");
            }
            else
            {
                Console.WriteLine($"CONGRATULATIONS! YOU DEFEATED {Enemie.name}!");
            }
        }
    }



class Entity
{
    public int Str { get; set; }
    public int Spd { get; set; }
    public double Hp { get; set; }
    public string name { get; set; }
}

class Enemy : Entity
{
    static Random random = new Random();
    private int randomN = random.Next(0, 5); 
    public string[] EnemiesList = { "SKELETON", "ZOMBIE", "VAMPIRE", "SPIDER", "GOBLIN" };
    private string randomName;

    public Enemy()
    {
        randomName = EnemiesList[randomN];
        Str = random.Next(1, 7);
        Spd = random.Next(1, 7);
        Hp = random.Next(10, 50);
        name = randomName;
    }
}

class Hero : Entity
{
    private int statPoints = 0;
    private int PowersNum;
    private string[] Powers;
    private int lvl = 1;
    private int fightClass;
    public int energy = 3;

    static Random random = new Random();

    public Hero(string heroName, int heroFightClass)
    {
        PowersNum = random.Next(1, 5);
        Powers = new string[PowersNum];

        name = heroName;
        Console.WriteLine($"The hero's name is: {name}");
        switch (heroFightClass)
        {
            case 0:
                Console.WriteLine("You selected class Hands");
                fightClass = 1;
                break;
            case 1:
                Console.WriteLine("You selected class Sword");
                fightClass = 2;
                break;
            case 2:
                Console.WriteLine("You selected class Ranged");
                fightClass = 3;
                break;
            case 3:
                Console.WriteLine("You selected class Wizard");
                fightClass = 4;
                break;
            case 4:
                Console.WriteLine("You selected class Summoner");
                fightClass = 5;
                break;
            default:
                throw new ArgumentException("Invalid class selection");
        }

        Str = random.Next(2, 5);
        Spd = random.Next(2, 5);
        Hp = random.Next(15, 40);

        Console.WriteLine($"Now you have to select your attack skills, we have selected a random number of powers, think very much about your power");
        for (int i = 0; i < Powers.Length; i++)
        {
            Console.WriteLine("Put the name of the attack skills:");
            Powers[i] = Console.ReadLine();
        }
    }

    public void UseSkill()
    {
        if (energy > 0)
        {
            energy -= 1;
            Console.WriteLine($"You have used {Powers[random.Next(0, Powers.Length)]}, You dealed {Str + (Str * 1.5)} damage");
            Console.WriteLine($"You have {energy} energy left");
        }
    }
}