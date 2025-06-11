namespace RPGDecorator
{
    public class WeaponDecorator : InventoryDecorator
    {
        public WeaponDecorator(Hero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Added Weapon (+10 Attack)");
            _hero.Attack += 10;
        }
    }
}
