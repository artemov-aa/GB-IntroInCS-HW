// Задача 58
// Задайте две матрицы. Напишите программу, которая будет находить произведение двух матриц.
// Например, заданы 2 массива:
// 1 4 7 2
// 5 9 2 3
// 8 4 2 4
// 5 2 6 7
// и
// 1 5 8 5
// 4 9 4 2
// 7 2 2 6
// 2 3 4 7
// Их произведение будет равно следующему массиву:
// 1 20 56 10
// 20 81 8 6
// 56 8 4 24
// 10 6 24 49

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

int[,] GetMatrix(int rows = 4, int columns = 4, int min = 0, int max = 9)
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
    int rowsLength = matrix.GetLength(0), columnsLength = matrix.GetLength(1);
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

bool MatrixProduct(int[,] mtrxA, int[,] mtrxB, out int[,] mtrxProduct)
{
    int rowLenMtrxA = mtrxA.GetLength(0), rowLenMtrxB = mtrxB.GetLength(0);
    int colLenMtrxA = mtrxA.GetLength(1), colLenMtrxB = mtrxB.GetLength(1);
    mtrxProduct = new int[rowLenMtrxA, colLenMtrxB];
    int element = 0;

    if (colLenMtrxA != rowLenMtrxB) return false;

    for (int i = 0; i < rowLenMtrxA; i++)
    {
        for (int j = 0; j < colLenMtrxB; j++)
        {
            for (int k = 0; k < colLenMtrxA; k++)
            {
                element += mtrxA[i, k] * mtrxB[k, j];
            }

            mtrxProduct[i, j] = element;
            element = 0;
        }
    }

    return true;
}

//--------------------------------------------------------------------//

Console.Clear();

Console.Write("Задайте количество строк матрицы A: ");
int rowsA = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте количество столбцов матрицы A: ");
int columnsA = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте количество строк матрицы B: ");
int rowsB = VerifyIntegerNumber(Console.ReadLine());
Console.Write("Задайте количество столбцов матрицы B: ");
int columnsB = VerifyIntegerNumber(Console.ReadLine());

int[,] matrixA = GetMatrix(rowsA, columnsA);
int[,] matrixB = GetMatrix(rowsB, columnsB);

Console.WriteLine("\nИсходные матрицы:\n");
PrintMatrix(matrixA);
PrintMatrix(matrixB);

int[,] productOfMatrices;
if (!MatrixProduct(matrixA, matrixB, out productOfMatrices))
    Console.WriteLine("Матрицы А и В не согласованы и не могут быть перемножены.");
else
{
    Console.WriteLine("Произведение матриц А и В:\n");
    PrintMatrix(productOfMatrices);
}