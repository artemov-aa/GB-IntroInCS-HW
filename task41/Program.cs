// Задача 41
// Пользователь вводит с клавиатуры M чисел.
// Посчитайте, сколько чисел больше 0 ввёл пользователь.
// 0, 7, 8, -2, -2 -> 2
// 1, -7, 567, 89, 223-> 3

int ValidateIntegerNumber(string input)
{
    int result;

    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите натуральное число -> ");
        input = Console.ReadLine();
    }

    return result;
}

int[] FillArrayByUser(int size)
{
    int[] array = new int[size];

    for (int i = 0; i < size; i++)
    {
        Console.Write($"Введите {i +1}-е число -> ");
        array[i] = ValidateIntegerNumber(Console.ReadLine());
    }

    return array;
}

int PositiveNumbers(int[] array)
{
    int count = 0;

    for (int i = 0; i < array.Length; i++)
    {
        if (array[i] > 0) count += 1;
    }

    return count;
}

Console.Clear();

Console.Write("Сколько чисел вы хотите ввести? -> ");

int size = ValidateIntegerNumber(Console.ReadLine());

int[] array = FillArrayByUser(size);

Console.WriteLine($"Количество чисел больше нуля: {PositiveNumbers(array)}");


