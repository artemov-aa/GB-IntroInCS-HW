// Задача 50.
// Напишите программу, которая на вход принимает позиции элемента в двумерном массиве,
// и возвращает значение этого элемента или же указание, что такого элемента нет.
// Например, задан массив:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 1,7 -> такого числа в массиве нет

int ValidateIntegerInput(string input)
{
    int result;

    while (!int.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите натуральное число -> ");
        input = Console.ReadLine();
    }

    return result;
}

int[,] GetMatrix(int rows = 4, int columns = 4, int min = 1, int max = 50)
{
    int[,] matrix = new int[rows, columns];
    var rnd = new Random();
    for (int i = 0; i < matrix.GetLength(0); i++)
    {
        for (int j = 0; j < matrix.GetLength(1); j++)
        {
            matrix[i, j] = rnd.Next(min, max);
        }
    }
    return matrix;
}

void PrintMatrix(int[,] matrix)
{
    Console.Write("Исходная матрица:\n\n");

    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);
    const int widthOfColumn = 4;

    for (int i = 0; i < rows; i++)
    {
        for (int j = 0; j < columns; j++)
        {
            if (j == 0) Console.Write(" | ");
            Console.Write($"{matrix[i, j],widthOfColumn} | ");
        }
        Console.WriteLine();
    }

    Console.WriteLine();
}

bool FindElement(int[,] matrix, int rowOfElement, int columnOfElement, out int element)
{
    int rows = matrix.GetLength(0);
    int columns = matrix.GetLength(1);

    if ((rowOfElement >= 0 && rowOfElement < rows) && (columnOfElement >= 0 && columnOfElement < columns))
    {
        element = matrix[rowOfElement, columnOfElement];
        return true;
    }
    else
    {
        element = 0;
        return false;
    }

}

Console.Clear();

int[,] arr = GetMatrix();

Console.Write("Введите номер строки искомого элемента -> ");
int row = ValidateIntegerInput(Console.ReadLine()) - 1;
Console.Write("Введите номер столбца искомого элемента -> ");
int column = ValidateIntegerInput(Console.ReadLine()) - 1;

int element;
bool elementExists = FindElement(arr, row, column, out element);

PrintMatrix(arr);

if (elementExists)
    Console.WriteLine($"Искомый элемент: {element}");
else
    Console.WriteLine("Указанных позиций в данной матрице не существует.");