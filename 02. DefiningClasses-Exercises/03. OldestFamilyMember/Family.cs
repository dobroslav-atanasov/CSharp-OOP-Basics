using System.Collections.Generic;
using System.Linq;

public class Family
{
    public List<Person> people = new List<Person>();

    public void AddMember(Person person)
    {
        this.people.Add(person);
    }

    public Person GetOldestMember()
    {
        Person person = this.people.OrderByDescending(p => p.Age).FirstOrDefault();
        return person;
    }
}