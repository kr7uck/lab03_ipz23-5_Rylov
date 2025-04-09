using LightHTMLComposer;

namespace LightHTMLFlyweight
{
    class ElementFactory
    {
        private readonly Dictionary<string, LightElementNode> cache = new();

        public LightElementNode GetElement(string tagName)
        {
            if (cache.ContainsKey(tagName))
                return cache[tagName];

            var node = new LightElementNode(tagName, DisplayType.Block, TagType.Paired);
            cache[tagName] = node;
            return node;
        }

        public LightElementNode CreateClone(string tagName)
        {
            var shared = GetElement(tagName);
            var clone = new LightElementNode(shared.TagName, shared.Display, shared.TagType);
            return clone;
        }
    }

}
