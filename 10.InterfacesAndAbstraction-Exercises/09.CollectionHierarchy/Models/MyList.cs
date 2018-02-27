using System;
using System.Collections.Generic;

public class MyList : IMyList
{
    private List<string> data;
    private List<int> indexes;
    private List<string> removedElements;

    public MyList()
    {
        this.data = new List<string>();
        this.indexes = new List<int>();
        this.removedElements = new List<string>();
    }

    public int NumberOfElements { get => this.data.Count; }

    public void Add(string element)
    {
        this.indexes.Add(0);
        this.data.Insert(0, element);
    }

    public void Remove()
    {
        string firstElement = this.data[0];
        this.removedElements.Add(firstElement);
        this.data.RemoveAt(0);
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