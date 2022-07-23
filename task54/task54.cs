// Задача 54
// Задайте двумерный массив. Напишите программу, которая упорядочит по убыванию
// элементы каждой строки двумерного массива.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// В итоге получается вот такой массив:
// 1 2 4 7
// 2 3 5 9
// 2 4 4 8

Console.Clear();
PrintTitle("Задача 54. Построчная сортировка элементов массива");
int rows        = InputNaturalNumber("Введите количество строк массива: ");
int columns     = InputNaturalNumber("Введите количество столбцов массива: ");
int minValue    = InputIntegerNumber("Введите минимальное значение для элементов массива: ");
int maxValue    = InputIntegerNumber("Введите максимальное значение для элементов массива: ");

int[,] array = CreateMatrix(rows, columns, minValue, maxValue);
Console.WriteLine("\nИсходная матрица:\n");
PrintMatrix(array);

// В задаче небольшое противоречие между условием и примером, поэтому предусмотрим оба варианта сортировки.
int typeOfSort = InputIntegerNumber("Как вы хотите отсортировать элементы строк массива? По убыванию (0) или по возрастанию (1)?: ");

while (typeOfSort != 0 && typeOfSort != 1)
{
    Console.Write("Недопустимый вариант! Введите одно из двух значений (0 или 1): ");
    typeOfSort = InputIntegerNumber("");
}

if (typeOfSort == 0)
{
    SelectionSortDown(array);
    Console.WriteLine("\nМассив, отсортированный построчно по убыванию:\n");
    PrintMatrix(array);
}
else
{
    SelectionSortUp(array);
    Console.WriteLine("\nМассив, отсортированный построчно по возрастанию:\n");
    PrintMatrix(array);
}




void PrintTitle(string message)
{
    string underline = new string('-', message.Length);
    Console.WriteLine($"{message}\n{underline}\n");
}

int InputNaturalNumber(string message)
{
    Console.Write(message);
    int number = VerifyNaturalNumber(Console.ReadLine());
    return number;
}

int InputIntegerNumber(string message)
{
    Console.Write(message);
    int number = VerifyIntegerNumber(Console.ReadLine());
    return number;
}

int VerifyNaturalNumber(string input)
{
    int result;
    while (!int.TryParse(input, out result) || result < 1)
    {
        Console.Write("Неверный ввод! \nВведите натуральное число: ");
        input = Console.ReadLine();
    }

    return result;
}

int VerifyIntegerNumber(string input)
{
    int result;
    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите целое число: ");
        input = Console.ReadLine();
    }

    return result;
}

int[,] CreateMatrix(int rows = 4, int columns = 4, int min = 0, int max = 10)
{
    int[,] matrix = new int[rows, columns];
    var rnd = new Random();

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            matrix[i, j] = rnd.Next(min, max + 1);
        }
    }

    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    int rowsLength = matrix.GetLength(0);
    int columnsLength = matrix.GetLength(1);
    const int widthOfColumn = 3;

    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < columnsLength; j++)
        {
            if (j == 0) Console.Write(" | ");
            Console.Write($"{matrix[i, j],widthOfColumn} | ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

void Swap(ref int numA, ref int numB)
{
    int numC = numA;
    numA = numB;
    numB = numC;
}

void SelectionSortUp(int[,] matrix)
{
    int rowsLength = matrix.GetLength(0);
    int columnsLength = matrix.GetLength(1);

    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < columnsLength - 1; j++)
        {
            int minPosition = j;

            for (int k = j + 1; k < columnsLength; k++)
            {
                if (matrix[i, k] < matrix[i, minPosition]) minPosition = k;
            }

            Swap(ref matrix[i, j], ref matrix[i, minPosition]);
        }
    }
}

void SelectionSortDown(int[,] matrix)
{
    int rowsLength = matrix.GetLength(0);
    int columnsLength = matrix.GetLength(1);

    for (int i = 0; i < rowsLength; i++)
    {
        for (int j = 0; j < columnsLength - 1; j++)
        {
            int minPosition = j;

            for (int k = j + 1; k < columnsLength; k++)
            {
                if (matrix[i, k] > matrix[i, minPosition]) minPosition = k;
            }

            Swap(ref matrix[i, j], ref matrix[i, minPosition]);
        }
    }
}