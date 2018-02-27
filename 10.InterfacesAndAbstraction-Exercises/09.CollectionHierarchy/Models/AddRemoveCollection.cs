using System;
using System.Collections.Generic;

public class AddRemoveCollection : IRemovable
{
    private List<string> data;
    private List<int> indexes;
    private List<string> removedElements;

    public AddRemoveCollection()
    {
        this.data = new List<string>();
        this.indexes = new List<int>();
        this.removedElements = new List<string>();
    }

    public void Add(string element)
    {
        this.indexes.Add(0);
        this.data.Insert(0, element);
    }

    public void Remove()
    {
        string lastElement = this.data[this.data.Count - 1];
        this.removedElements.Add(lastElement);
        this.data.RemoveAt(this.data.Count - 1);
    }

    public void GetRemovedElements()
    {
        Console.WriteLine($"{string.Join(" ", this.removedElements)}");
    }

    public override string ToString()
    {
        return $"{string.Join(" ", this.indexes)}";
    }
}