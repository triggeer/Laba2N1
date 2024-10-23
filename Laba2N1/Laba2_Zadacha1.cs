﻿using System;

// Тестирование классов
class Laba2_Zadacha1
{
    static void Main(string[] args)
    {
        // Ввод данных с клавиатуры для базового класса
        Console.WriteLine("Введите три значения для базового класса:");
        int field1 = Proverka("1-е значение: ");
        int field2 = Proverka("2-е значение: ");
        int field3 = Proverka("3-е значение: ");

        BaseClass baseObj = new BaseClass(field1, field2, field3);
        Console.WriteLine(baseObj.ToString());
        Console.WriteLine($"Максимальное значение: {baseObj.GetMaxValue()}");

        // Ввод данных с клавиатуры для дочернего класса
        Console.WriteLine("\nВведите значения для дочернего класса:");
        field1 = Proverka("1-е значение: ");
        field2 = Proverka("2-е значение: ");
        field3 = Proverka("3-е значение: ");
        int coefficient1 = Proverka("1-й коэффициент: ");
        int coefficient2 = Proverka("2-й коэффициент: ");
        int coefficient3 = Proverka("3-й коэффициент: ");

        Class2 obj2 = new Class2(field1, field2, field3, coefficient1, coefficient2, coefficient3);
        Console.WriteLine(obj2.ToString()); //выводит значения в строку
        Console.WriteLine($"Сумма значений: {obj2.SumFields()}"); //выводит сумму полей
        Console.WriteLine($"Умноженная сумма значений: {obj2.MultiplyFields()}"); //сумма полей, каждое из которы умножено на коэф.
    }

    // Метод для проверки корректности ввода
    static int Proverka(string message)
    {
        int value;
        while (true)
        {
            Console.Write(message); // Запрашиваем ввод в каждой итерации
            string input = Console.ReadLine();

            // Пытаемся преобразовать строку в целое число
            if (int.TryParse(input, out value))
            {
                return value; // Возвращаем значение, если преобразование прошло успешно
            }
            else
            {
                Console.WriteLine("Ошибка: введите корректное целое число.");
            }
        }
    }
}

// Базовый класс
public class BaseClass
{
    int field1;
    int field2;
    int field3;

    //Конструктор с параметрами
    public BaseClass(int field1, int field2, int field3)
    {
        this.field1 = field1;
        this.field2 = field2;
        this.field3 = field3;
    }

    //Констктор копирования
    public BaseClass(BaseClass other)
    {
        field1 = other.field1;
        field2 = other.field2;
        field3 = other.field3;
    }

    // Методы для доступа к полям
    public int GetField1() => field1;
    public int GetField2() => field2;
    public int GetField3() => field3;

    // Метод для получения максимального значения среди полей
    public int GetMaxValue()
    {
        return Math.Max(field1, Math.Max(field2, field3));
    }

    // Переопределение метода ToString
    public override string ToString()
    {
        return $"1-е значение: {field1}, 2-е значение: {field2}, 3-е значение: {field3}";
    }
}

// Дочерний класс
public class Class2 : BaseClass
{
    private int coefficient1;
    private int coefficient2;
    private int coefficient3;

    // Конструктор с параметрами
    public Class2(int field1, int field2, int field3, int coefficient1, int coefficient2, int coefficient3)
        : base(field1, field2, field3)
    {
        this.coefficient1 = coefficient1;
        this.coefficient2 = coefficient2;
        this.coefficient3 = coefficient3;
    }

    // Методы для доступа к полям коэффициентов
    public int GetCoefficient1() => coefficient1;
    public int GetCoefficient2() => coefficient2;
    public int GetCoefficient3() => coefficient3;

    // Метод для суммы всех полей
    public int SumFields()
    {
        return GetField1() + GetField2() + GetField3();
    }

    // Метод для суммы полей с коэффициентами
    public int MultiplyFields()
    {
        return GetField1() * coefficient1 + GetField2() * coefficient2 + GetField3() * coefficient3;
    }

    // Переопределение метода ToString для вывода полей дочернего класса
    public override string ToString()
    {
        return base.ToString() + $", 1-й коэф.: {coefficient1}, 2-й коэф.: {coefficient2}, 3-й коэф.: {coefficient3}";
    }
}