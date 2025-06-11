namespace RPGDecorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Hero warrior = new Warrior("Геральд з Рiвiї");
            Hero mage = new Mage("Єннефер з Венгерберга");
            Hero paladin = new Paladin("Урiк");

            warrior = new ArmorDecorator(warrior);
            warrior = new WeaponDecorator(warrior);
            mage = new ArtifactDecorator(mage);
            paladin = new ArmorDecorator(new WeaponDecorator(paladin));

            Console.WriteLine("Статистика героїв:");
            warrior.DisplayStats();
            mage.DisplayStats();
            paladin.DisplayStats();
        }
    }
}