
using System;
using System.Collections.Generic;
using System.Text;

namespace LightHTMLComposer
{
    public class LightElementNode : LightNode
    {
        public string TagName { get; set; }
        public DisplayType Display { get; set; }
        public TagType TagType { get; set; }
        public List<string> CssClasses { get; } = new();

        public LightElementNode(string tagName, DisplayType display, TagType tagType)
        {
            TagName = tagName;
            Display = display;
            TagType = tagType;
        }

        public void AddClass(string className) => CssClasses.Add(className);

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
                var sb = new StringBuilder();
                sb.Append($"<{TagName}>");
                sb.Append(InnerHTML);
                sb.Append($"</{TagName}>");
                return sb.ToString();
            }
        }

        protected override void OnCreated() => Console.WriteLine($"[Element Created] <{TagName}>");
        protected override void OnInserted() => Console.WriteLine($"[Element Inserted] <{TagName}>");
        protected override void OnRemoved() => Console.WriteLine($"[Element Removed] <{TagName}>");
        protected override void OnStylesApplied() => Console.WriteLine($"[Styles Applied] <{TagName}>");
        protected override void OnClassListApplied() => Console.WriteLine($"[ClassList Applied] <{TagName}>");
        protected override void OnTextRendered() => Console.WriteLine($"[Text Rendered] <{TagName}>");
    }
}
