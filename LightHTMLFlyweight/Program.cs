using LightHTMLComposer;
using System.Text;

namespace LightHTMLFlyweight
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var lines = File.ReadAllLines("pg1513.txt");
            var factory = new ElementFactory();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoryBefore = GC.GetTotalMemory(true);

            var root = factory.CreateClone("div");

            foreach (var line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                LightElementNode node;

                if (root.Children.Count == 0)
                    node = factory.CreateClone("h1");
                else if (line.Length < 20)
                    node = factory.CreateClone("h2");
                else if (char.IsWhiteSpace(line[0]))
                    node = factory.CreateClone("blockquote");
                else
                    node = factory.CreateClone("p");

                node.AddChild(new LightTextNode(line.Trim()));
                root.AddChild(node);
            }

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            long memoryAfter = GC.GetTotalMemory(true);

            Console.WriteLine("=== OuterHTML ===");
            Console.WriteLine(root.OuterHTML);

            Console.WriteLine($"\nРозмір HTML-дерева в памʼяті: {memoryAfter - memoryBefore} байт");

            Console.ReadLine();
        }
    }

}