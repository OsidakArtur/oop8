using System;

class Man
{
    public string Name { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public string Gender { get; set; }

    public Man() { }

    public Man(string name, int age, double weight, string gender)
    {
        Name = name;
        Age = age;
        Weight = weight;
        Gender = gender;
    }

    public Man(Man other)
    {
        Name = other.Name;
        Age = other.Age;
        Weight = other.Weight;
        Gender = other.Gender;
    }

    public virtual void ShowInfo()
    {
        Console.WriteLine($"Ім'я: {Name}, Вік: {Age}, Вага: {Weight}, Стать: {Gender}");
    }

    public void ChangeAge(int newAge)
    {
        Age = newAge;
    }

    public void ChangeWeight(double newWeight)
    {
        Weight = newWeight;
    }
}

class Student : Man
{
    public int Course { get; set; }

    public Student() { }

    public Student(string name, int age, double weight, string gender, int course)
        : base(name, age, weight, gender)
    {
        Course = course;
    }

    public Student(Student other) : base(other)
    {
        Course = other.Course;
    }

    public void ChangeCourse(int newCourse)
    {
        Course = newCourse;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Курс: {Course}");
    }
}

class Worker : Man
{
    public string Position { get; set; }

    public Worker() { }

    public Worker(string name, int age, double weight, string gender, string position)
        : base(name, age, weight, gender)
    {
        Position = position;
    }

    public Worker(Worker other) : base(other)
    {
        Position = other.Position;
    }

    public void ChangePosition(string newPosition)
    {
        Position = newPosition;
    }

    public override void ShowInfo()
    {
        base.ShowInfo();
        Console.WriteLine($"Посада: {Position}");
    }
}

class Fraction
{
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    public Fraction(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
        Simplify();
    }

    public static Fraction operator +(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator + b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static Fraction operator -(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator - b.Numerator * a.Denominator, a.Denominator * b.Denominator);
    }

    public static Fraction operator *(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator);
    }

    public static Fraction operator /(Fraction a, Fraction b)
    {
        return new Fraction(a.Numerator * b.Denominator, a.Denominator * b.Numerator);
    }

    public static bool operator >(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator > b.Numerator * a.Denominator;
    }

    public static bool operator <(Fraction a, Fraction b)
    {
        return a.Numerator * b.Denominator < b.Numerator * a.Denominator;
    }

    public override string ToString()
    {
        return $"{Numerator}/{Denominator}";
    }

    public void Simplify()
    {
        int gcd = GCD(Numerator, Denominator);
        Numerator /= gcd;
        Denominator /= gcd;
    }

    private int GCD(int a, int b)
    {
        while (b != 0)
        {
            int temp = b;
            b = a % b;
            a = temp;
        }
        return a;
    }
}

class Program
{
    static void Main()
    {
        while (true)
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1. Працювати з людьми");
            Console.WriteLine("2. Працювати з дробами");
            Console.WriteLine("3. Вийти");
            Console.Write("Оберіть опцію: ");

            string choice = Console.ReadLine();

            if (choice == "1")
            {
                Man man = new Man("Ivan", 18, 70.5, "Чоловік");
                Student student = new Student("Маруся", 20, 55.2, "Жінка", 2);
                Worker worker = new Worker("Роберт Полсон", 40, 120, "Чоловік", "Sigma");

                man.ShowInfo();
                student.ShowInfo();
                worker.ShowInfo();
            }
            else if (choice == "2")
            {
                Fraction f1 = new Fraction(3, 4);
                Fraction f2 = new Fraction(5, 6);

                Console.WriteLine($"Дріб 1: {f1}");
                Console.WriteLine($"Дріб 2: {f2}");
                Console.WriteLine($"Сума: {f1 + f2}");
                Console.WriteLine($"Різниця: {f1 - f2}");
                Console.WriteLine($"Добуток: {f1 * f2}");
                Console.WriteLine($"Частка: {f1 / f2}");
            }
            else if (choice == "3")
            {
                break;
            }
            else
            {
                Console.WriteLine("Невірний вибір. Спробуйте ще раз.");
            }

            Console.WriteLine();
        }
    }
}
