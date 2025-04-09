namespace RPGDecorator
{
    public class Paladin : Hero
    {
        public Paladin(string name)
        {
            Name = name;
            Health = 120;
            Attack = 20;
            Defense = 20;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Paladin: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}");
        }
    }
}