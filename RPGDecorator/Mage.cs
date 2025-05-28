namespace RPGDecorator
{
    public class Mage : Hero
    {
        public Mage(string name)
        {
            Name = name;
            Health = 100;
            Attack = 30;
            Defense = 10;
        }

        public override void DisplayStats()
        {
            Console.WriteLine($"Mage: {Name}, Health: {Health}, Attack: {Attack}, Defense: {Defense}");
        }
    }
}