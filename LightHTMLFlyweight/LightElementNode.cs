using LightHTMLFlyweight;
using System.Text;

namespace LightHTMLComposer
{
    class LightElementNode : LightNode
    {
        public string TagName { get; }
        public DisplayType Display { get; }
        public TagType TagType { get; }
        public List<string> CssClasses { get; }
        public List<LightNode> Children { get; }

        public LightElementNode(string tagName, DisplayType display, TagType tagType)
        {
            TagName = tagName;
            Display = display;
            TagType = tagType;
            CssClasses = new List<string>();
            Children = new List<LightNode>();
        }

        public void AddChild(LightNode child) => Children.Add(child);

        public override string InnerHTML =>
            string.Join("", Children.ConvertAll(c => c.OuterHTML));

        public override string OuterHTML =>
            TagType == TagType.Single
                ? $"<{TagName}/>"
                : $"<{TagName}>{InnerHTML}</{TagName}>";
    }
}
