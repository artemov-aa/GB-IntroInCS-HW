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

int VerifyIntegerNumber(string input)
{
    int result;

    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите натуральное число -> ");
        input = Console.ReadLine();
    }

    return result;
}

int[,] GetMatrix(int rows = 4, int columns = 4, int min = 0, int max = 10)
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

//---------------------------------------------------------------//

Console.Clear();

Console.Write("Задайте количество строк матрицы: ");
int rows = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте количество столбцов матрицы: ");
int columns = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте минимальное значение элементов: ");
int min = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте максимальное значение элементов: ");
int max = VerifyIntegerNumber(Console.ReadLine());

int[,] array = GetMatrix(rows, columns, min, max);

Console.WriteLine("\nИсходная матрица:\n");
PrintMatrix(array);

// В задаче противоречие между условием и примером, поэтому предусмотрим оба варианта.
Console.Write("Как вы хотите отсортировать элементы строк матрицы? По убыванию (0) или по возрастанию (1): ");
int kindOfSort = VerifyIntegerNumber(Console.ReadLine());

while (kindOfSort != 0 && kindOfSort != 1)
{
    Console.Write("Недопустимый вариант! Введите одно из двух значений (0 или 1): ");
    kindOfSort = VerifyIntegerNumber(Console.ReadLine());
}

if (kindOfSort == 0)
{
    SelectionSortDown(array);
    Console.WriteLine("\nОтсортированная матрица:\n");
    PrintMatrix(array);
}
else
{
    SelectionSortUp(array);
    Console.WriteLine("\nОтсортированная матрица:\n");
    PrintMatrix(array);
}