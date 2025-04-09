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

        public void AddClass(string className) => CssClasses.Add(className);

        public void AddChild(LightNode child) => Children.Add(child);

        public int ChildCount => Children.Count;

        public override string InnerHTML
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var child in Children)
                {
                    sb.Append(child.OuterHTML);
                }
                return sb.ToString();
            }
        }

        public override string OuterHTML
        {
            get
            {
                var classAttr = CssClasses.Count > 0 ? $" class=\"{string.Join(" ", CssClasses)}\"" : "";
                if (TagType == TagType.Single)
                {
                    return $"<{TagName}{classAttr}/>";
                }

                return $"<{TagName}{classAttr}>{InnerHTML}</{TagName}>";
            }
        }
    }
}
