
using System;
using System.Collections.Generic;

namespace LightHTMLComposer
{
    public interface ICommand
    {
        void Execute();
        void Undo();
    }

    public class AddChildCommand : ICommand
    {
        private readonly LightNode _parent;
        private readonly LightNode _child;

        public AddChildCommand(LightNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.AddChild(_child);
        }

        public void Undo()
        {
            _parent.RemoveChild(_child);
        }
    }

    public class RemoveChildCommand : ICommand
    {
        private readonly LightNode _parent;
        private readonly LightNode _child;

        public RemoveChildCommand(LightNode parent, LightNode child)
        {
            _parent = parent;
            _child = child;
        }

        public void Execute()
        {
            _parent.RemoveChild(_child);
        }

        public void Undo()
        {
            _parent.AddChild(_child);
        }
    }

    public class CommandManager
    {
        private readonly Stack<ICommand> _history = new Stack<ICommand>();

        public void ExecuteCommand(ICommand command)
        {
            command.Execute();
            _history.Push(command);
        }

        public void Undo()
        {
            if (_history.Count > 0)
            {
                var command = _history.Pop();
                command.Undo();
            }
        }
    }
}
