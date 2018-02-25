using System.Collections.Generic;
using System.Linq;

public class StackOfStrings
{
    private List<string> data;

    public StackOfStrings()
    {
        this.data = new List<string>();
    }

    public void Push(string item)
    {
        this.data.Add(item);
    }

    public string Pop()
    {
        string lastElement = this.data.Last();
        this.data.Remove(lastElement);
        return lastElement;
    }

    public string Peek()
    {
        string lastElement = this.data.Last();
        return lastElement;
    }

    public bool IsEmpty()
    {
        return this.data.Count == 0;
    }
}