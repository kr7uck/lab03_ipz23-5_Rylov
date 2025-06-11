
using System;

namespace LightHTMLComposer
{
    public interface INodeState
    {
        void Apply(LightNode node);
        string Name { get; }
    }

    public class VisibleState : INodeState
    {
        public string Name => "Visible";
        public void Apply(LightNode node)
        {
            Console.WriteLine($"[State: Visible] {node.OuterHTML}");
        }
    }

    public class HiddenState : INodeState
    {
        public string Name => "Hidden";
        public void Apply(LightNode node)
        {
            Console.WriteLine($"[State: Hidden] {node.OuterHTML}");
        }
    }

    public class CollapsedState : INodeState
    {
        public string Name => "Collapsed";
        public void Apply(LightNode node)
        {
            Console.WriteLine($"[State: Collapsed] {node.OuterHTML}");
        }
    }

    public static class StateExtensions
    {
        public static void SetState(this LightNode node, INodeState state)
        {
            node.State = state;
            state.Apply(node);
        }

        public static INodeState State(this LightNode node) => node.State;
    }
}
