using System;
using System.Collections.Generic;
using UnityEngine;


[System.Serializable]
public class Stack<T>
{
    [SerializeField]
    private List<T> _elements;

    public Stack()
    {
        _elements = new List<T>();
    }

    // Adds an element to the top of the stack
    public void Push(T item)
    {
        _elements.Add(item);
    }

    // Removes and returns the element at the top of the stack
    public T Pop()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        // Get the last element
        T item = _elements[_elements.Count - 1];
        _elements.RemoveAt(_elements.Count - 1);
        return item;
    }

    // Checks if an item exists in the stack
    public bool Contains(T item)
    {
        return _elements.Contains(item);
    }

    // Returns the element at the top of the stack without removing it
    public T Peek()
    {
        if (_elements.Count == 0)
        {
            throw new InvalidOperationException("Stack is empty.");
        }
        
        return _elements[_elements.Count - 1];
    }

    // Returns the number of elements in the stack
    public int Count()
    {
        return _elements.Count;
    }

    // Checks if the stack is empty
    public bool IsEmpty()
    {
        return _elements.Count == 0;
    }
}

