using System.Collections.Generic;
using UnityEngine;

public class CommandInvoker
{
    Stack<Command> stack;

    public CommandInvoker()
    {
        stack = new Stack<Command>();
    }

    public void AddCommand(Command c)
    {
        Debug.Log("Adding command " + c);
        stack.Push(c);
    }

    public void Execute()
    {
        if (stack.Count > 0)
        {
            Command top = stack.Pop();
            top.Execute();
        }
    }

    public void Undo()
    {
        if (stack.Count > 0)
        {
            Command top = stack.Pop();
            top.Undo();
        }
    }

    public void ExecuteAll()
    {
        while (stack.Count > 0)
            Execute();
    }

    public void UndoAll()
    {
        while (stack.Count > 0)
            Undo();
    }
}
