public abstract class Machine
{
    private string id;

    protected Machine(string id)
    {
        this.Id = id;
    }

    public string Id
    {
        get { return this.id; }
        protected set { this.id = value; }
    }
}