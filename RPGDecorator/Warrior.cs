namespace RPGDecorator
{
    public class Warrior : Hero
    {
        public Warrior(string name)
        {
            Name = name;
            Health = 150;
            Attack = 25;
            Defense = 15;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Warrior: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}");
        }
    }
}