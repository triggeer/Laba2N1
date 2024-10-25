using System;

class Laba2_Zadacha1
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введите три значения для базового класса:");
        int field1 = Proverka("1-е значение: ");
        int field2 = Proverka("2-е значение: ");
        int field3 = Proverka("3-е значение: ");

        BaseClass baseObj = new BaseClass(field1, field2, field3);
        Console.WriteLine(baseObj.ToString());
        Console.WriteLine($"Максимальное значение: {baseObj.GetMaxValue()}");

        Console.WriteLine("\nВведите значения для дочернего класса:");
        field1 = Proverka("1-е значение: ");
        field2 = Proverka("2-е значение: ");
        field3 = Proverka("3-е значение: ");
        int coefficient1 = Proverka("1-й коэффициент: ");
        int coefficient2 = Proverka("2-й коэффициент: ");
        int coefficient3 = Proverka("3-й коэффициент: ");

        Class2 obj2 = new Class2(field1, field2, field3, coefficient1, coefficient2, coefficient3);
        Console.WriteLine(obj2.ToString());
        Console.WriteLine($"Сумма значений: {obj2.SumFields()}");
        Console.WriteLine($"Умноженная сумма значений: {obj2.MultiplyFields()}");
    }

    static int Proverka(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            if (int.TryParse(input, out value))
            {
                return value;
            }
            else
            {
                Console.WriteLine("введите целое число");
            }
        }
    }
}

class BaseClass
{
    int field1;
    int field2;
    int field3;

    public BaseClass(int field1, int field2, int field3)
    {
        this.field1 = field1;
        this.field2 = field2;
        this.field3 = field3;
    }

    public BaseClass(BaseClass other)
    {
        field1 = other.field1;
        field2 = other.field2;
        field3 = other.field3;
    }

    // Приватные методы для доступа к полям, доступные только внутри этого класса
    private int GetField1() => field1;
    private int GetField2() => field2;
    private int GetField3() => field3;

    public int GetMaxValue()
    {
        return Math.Max(field1, Math.Max(field2, field3));
    }

    public override string ToString()
    {
        return $"1-е значение: {field1}, 2-е значение: {field2}, 3-е значение: {field3}";
    }

    // Метод для доступа к сумме полей
    public int SumFields() => field1 + field2 + field3;

    // Метод для умножения полей на коэффициенты в дочернем классе
    public int MultiplyFields(int coefficient1, int coefficient2, int coefficient3)
    {
        return field1 * coefficient1 + field2 * coefficient2 + field3 * coefficient3;
    }
}

class Class2 : BaseClass
{
    int coefficient1;
    int coefficient2;
    int coefficient3;

    public Class2(int field1, int field2, int field3, int coefficient1, int coefficient2, int coefficient3)
        : base(field1, field2, field3)
    {
        this.coefficient1 = coefficient1;
        this.coefficient2 = coefficient2;
        this.coefficient3 = coefficient3;
    }

    public int SumFields()
    {
        return base.SumFields();
    }

    public int MultiplyFields()
    {
        return base.MultiplyFields(coefficient1, coefficient2, coefficient3);
    }

    public override string ToString()
    {
        return base.ToString() + $", 1-й коэф.: {coefficient1}, 2-й коэф.: {coefficient2}, 3-й коэф.: {coefficient3}";
    }
}
