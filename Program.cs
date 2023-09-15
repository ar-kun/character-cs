using System;

class Character
{
    public string Name { get; protected set; }
    protected int Health;

    public Character(string name)
    {
        Name = name;
        Health = 100;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage. Health: {Health}");
        if (!IsAlive())
        {
            OnDeath();
        }
    }

    public virtual void Attack()
    {
        Console.WriteLine($"{Name} attacks!");
    }

    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} is healed for {amount} HP. Health: {Health}");
    }

    public bool IsAlive()
    {
        return Health > 0;
    }

    protected virtual void OnDeath()
    {
        Console.WriteLine($"{Name} is defeated. Game Over!");
        Environment.Exit(0);
    }
}

class Player : Character
{
    private int Experience;

    public Player(string name) : base(name)
    {
        Experience = 0;
    }

    public void GainExperience(int points)
    {
        Experience += points;
        Console.WriteLine($"{Name} gained {points} experience points. Total experience: {Experience}");
    }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine($"{Name} uses a sword to attack!");
    }

    protected override void OnDeath()
    {
        Console.WriteLine($"{Name} is defeated. Game Over!");
        Environment.Exit(0);
    }
}

class Enemy : Character
{
    public Enemy(string name) : base(name)
    {
        Health = 70;
    }

    public override void Attack()
    {
        base.Attack();
        Console.WriteLine($"{Name} attacks with claws!");
    }

    protected override void OnDeath()
    {
        Console.WriteLine($"{Name} is defeated. You win!");
        Environment.Exit(0);
    }
}

class Program
{
    static void Main()
    {
        Player player = new Player("Hero");
        Enemy enemy = new Enemy("Goblin");

        while (player.IsAlive() && enemy.IsAlive())
        {
            Console.Clear();

            Console.WriteLine($"Welcome to the game, {player.Name}!");

            Console.WriteLine("Game Menu:");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Take Damage");
            Console.WriteLine("3. Heal");
            Console.WriteLine("4. Exit");
            Console.Write("Enter your choice: ");

            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    player.Attack();
                    player.GainExperience(10);
                    enemy.TakeDamage(20);
                    break;
                case "2":
                    Console.Write("Enter damage amount: ");
                    if (int.TryParse(Console.ReadLine(), out int damageAmount))
                    {
                        player.TakeDamage(damageAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "3":
                    Console.Write("Enter heal amount: ");
                    if (int.TryParse(Console.ReadLine(), out int healAmount))
                    {
                        player.Heal(healAmount);
                    }
                    else
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    break;
                case "4":
                    Environment.Exit(0);
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please select a valid option.");
                    break;
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }
}
