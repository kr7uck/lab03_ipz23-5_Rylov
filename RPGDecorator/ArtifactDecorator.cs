namespace RPGDecorator
{
    public class ArtifactDecorator : InventoryDecorator
    {
        public ArtifactDecorator(Hero hero) : base(hero) { }

        public override void DisplayStats()
        {
            base.DisplayStats();
            Console.WriteLine("Added Artifact (+10 Health)");
            _hero.Health += 10;
        }
    }
}