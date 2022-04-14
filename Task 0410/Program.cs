// Есть число N. Сколько групп M, можно получить при разбиении всех чисел на группы, 
//так чтобы в одной группе все числа были взаимно просты (все числа в группе друг на друга не делятся)? 
//Найдите M при заданном N и получите одно из разбиений на группы N ≤ 10²⁰



 class Program
{
    public static int CalculateGroupsNumber(int numbersSequenceRightBound)
    {
        int groupsNumber = (int)Math.Ceiling(Math.Log2(numbersSequenceRightBound));
        
        if ((int)Math.Pow(2, groupsNumber) == numbersSequenceRightBound)
            groupsNumber++;
        
        return groupsNumber;
    }
    
    public static int[] GetNextGroup(int groupNumber, int groupsQuantity, int numbersSequenceRightBound)
    {
        if (groupNumber != groupsQuantity)
            return Enumerable.Range((int)Math.Pow(2, groupNumber - 1), (int)Math.Pow(2, groupNumber) - (int)Math.Pow(2, groupNumber - 1)).ToArray();
        else
            return Enumerable.Range((int)Math.Pow(2, groupNumber - 1), numbersSequenceRightBound - (int)Math.Pow(2, groupNumber - 1) + 1).ToArray();
    }
    
    public static void Main()
    {
        int numbersSequenceRightBound = 0;
        
        Console.WriteLine("Введите число: ");
        numbersSequenceRightBound = Int32.Parse(Console.ReadLine());
        while (numbersSequenceRightBound <= 0)
        {
            Console.WriteLine("Ошибка: число должно быть положительным!");
            Console.Write("Повторите ввод: ");
            numbersSequenceRightBound = Int32.Parse(Console.ReadLine());
        }
        
        Console.WriteLine($"Количество групп: {CalculateGroupsNumber(numbersSequenceRightBound)}");
        for (int i = 1; i <= CalculateGroupsNumber(numbersSequenceRightBound); i++)
            Console.WriteLine($"{i}-я группа: [{string.Join(", ",GetNextGroup(i, CalculateGroupsNumber(numbersSequenceRightBound), numbersSequenceRightBound))}]");
            
        Console.ReadKey(true);
    }
}