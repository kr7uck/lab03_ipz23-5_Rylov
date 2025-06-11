
using System;
using System.Collections.Generic;

namespace LightHTMLComposer
{
    public abstract class LightNode
    {
        public LightNode Parent { get; set; }
        public List<LightNode> Children { get; } = new List<LightNode>();

        public void AddChild(LightNode child)
        {
            child.Parent = this;
            Children.Add(child);
            child.OnInserted();
        }

        public void RemoveChild(LightNode child)
        {
            if (Children.Remove(child))
            {
                child.OnRemoved();
            }
        }

        public LightNode()
        {
            OnCreated();
        }

        // Шаблонний метод рендерингу
        public void Render()
        {
            OnStylesApplied();
            OnClassListApplied();
            OnTextRendered();
        }

        // Життєві хуки
        protected virtual void OnCreated() { }
        protected virtual void OnInserted() { }
        protected virtual void OnRemoved() { }
        protected virtual void OnStylesApplied() { }
        protected virtual void OnClassListApplied() { }
        protected virtual void OnTextRendered() { }

        public abstract string InnerHTML { get; }
        public abstract string OuterHTML { get; }

        public INodeState State { get; set; }
    }
}
