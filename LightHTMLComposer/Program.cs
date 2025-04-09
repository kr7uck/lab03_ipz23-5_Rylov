using System.Text;

namespace LightHTMLComposer
{
    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;

            var ul = new LightElementNode("ul", DisplayType.Block, TagType.Paired);
            ul.AddClass("my-list");

            var li1 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li1.AddChild(new LightTextNode("Перший елемент"));

            var li2 = new LightElementNode("li", DisplayType.Block, TagType.Paired);
            li2.AddChild(new LightTextNode("Другий елемент"));

            ul.AddChild(li1);
            ul.AddChild(li2);

            Console.WriteLine("=== OuterHTML ===");
            Console.WriteLine(ul.OuterHTML);

            Console.WriteLine("\n=== InnerHTML ===");
            Console.WriteLine(ul.InnerHTML);
        }
    }
}