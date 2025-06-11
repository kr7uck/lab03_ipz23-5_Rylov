
using System;
using System.Collections.Generic;

namespace LightHTMLComposer
{
    public static class LightNodeIterator
    {
        public static IEnumerable<LightNode> TraverseDepthFirst(LightNode root)
        {
            var stack = new Stack<LightNode>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var node = stack.Pop();
                yield return node;

                for (int i = node.Children.Count - 1; i >= 0; i--)
                {
                    stack.Push(node.Children[i]);
                }
            }
        }

        public static IEnumerable<LightNode> TraverseBreadthFirst(LightNode root)
        {
            var queue = new Queue<LightNode>();
            queue.Enqueue(root);

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                yield return node;

                foreach (var child in node.Children)
                {
                    queue.Enqueue(child);
                }
            }
        }
    }
}
