Adam Ramdan - 1957065840-62

# Inheritance -> class Player dan Enemy
### Contoh
```
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
```

# Polymorphism -> Attack, OnDeath di class parent dan turunannya
### Contoh
```
public virtual void Attack()
{
    Console.WriteLine($"{Name} attacks!");
}
```

# Encapsulation -> public, protected, private 
### Contoh
```
public string Name { get; protected set; }
protected int Health;
```

# Abstraction  -> TakeDamage, Heal, IsAlive, GainExperience di class parent dan turunannya
### Contoh
```
public void TakeDamage(int damage) // Abstraction (operasi umum karakter)
    {
        Health -= damage;
        Console.WriteLine($"{Name} took {damage} damage. Health: {Health}");
        if (!IsAlive())
        {
            OnDeath();
        }
    }
```
