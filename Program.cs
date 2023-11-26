using System;

class Program
{

    static void Main()
    {
        Console.WriteLine("WELCOME TO SUPERHERO ACADEMY");

        Console.Write("Enter hero name: ");
        string heroName = Console.ReadLine();
        Console.WriteLine("Now it's time to select your class");
        Console.WriteLine("There are 5 classes: 0) Hands 1) Sword 2) Ranged 3) Wizard 4) Summoner");
        int fightClass = int.Parse(Console.ReadLine());
        Hero myHero = new Hero(heroName, fightClass);
    }
}

class Hero
{   
    private int PowersNum;
    private string[] Powers;
    private string name;
    private int fightClass;
    
    static Random random = new Random();
    public Hero(string heroName, int heroFightClass)
    {
        PowersNum = random.Next(1, 5); // Mover la inicialización a constructor
        Powers = new string[PowersNum]; // Inicializar array aquí

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

        Console.WriteLine($"Now you have to select your powers, we have selected a random number of powers, think very much your power");
        for (int i = 0; i < Powers.Length; i++)
        {
            Console.WriteLine("Put the name of the power:");
            Powers[i] = Console.ReadLine();

        }
    }
}