namespace RPGDecorator
{
    public class ArmorDecorator : InventoryDecorator
    {
        public ArmorDecorator(Hero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Added Armor (+5 Defense)");
            _hero.Defense += 5;
        }
    }
}