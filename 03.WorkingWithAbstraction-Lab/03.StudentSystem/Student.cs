namespace StudentSystem
{
    public class Student
    {
        private string name;
        private int age;
        private double grade;
        
        public Student(string name, int age, double grade)
        {
            this.Name = name;
            this.Age = age;
            this.grade = grade;
        }

        public double Grade
        {
            get { return grade; }
            set { grade = value; }
        }

        public int Age
        {
            get { return age; }
            set { age = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public override string ToString()
        {
            if (this.Grade >= 5.00)
            {
                return $"{this.Name} is {this .Age} years old. Excellent student.";
            }
            else if (this.Grade < 5.00 && this.Grade >= 3.50)
            {
                return $"{this.Name} is {this.Age} years old. Average student.";
            }
            else
            {
                return $"{this.Name} is {this.Age} years old. Very nice person.";
            }
        }
    }
}