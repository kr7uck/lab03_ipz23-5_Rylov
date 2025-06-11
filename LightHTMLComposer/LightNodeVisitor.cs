
using System;

namespace LightHTMLComposer
{
    public interface ILightNodeVisitor
    {
        void VisitElement(LightElementNode element);
        void VisitText(LightTextNode text);
    }

    public static class LightNodeVisitorExtensions
    {
        public static void Accept(this LightNode node, ILightNodeVisitor visitor)
        {
            switch (node)
            {
                case LightElementNode element:
                    visitor.VisitElement(element);
                    break;
                case LightTextNode text:
                    visitor.VisitText(text);
                    break;
                default:
                    throw new NotSupportedException("Unknown node type");
            }

            foreach (var child in node.Children)
            {
                child.Accept(visitor);
            }
        }
    }

    public class StatsVisitor : ILightNodeVisitor
    {
        public int ElementCount { get; private set; }
        public int TextCount { get; private set; }

        public void VisitElement(LightElementNode element)
        {
            ElementCount++;
        }

        public void VisitText(LightTextNode text)
        {
            TextCount++;
        }
    }
}
