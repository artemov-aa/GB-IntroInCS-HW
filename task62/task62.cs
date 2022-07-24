// Задача 62.
// Заполните спирально массив 4 на 4.
// Например, на выходе получается вот такой массив:
// 1 2 3 4
// 12 13 14 5
// 11 16 15 6
// 10 9 8 7

Console.Clear();
PrintTitle("Задача 62. Спиральное заполнение матрицы");

int sizeOfMtrx  = InputNumber("Введите размер (M) квадратной матрицы (M x M): ", 0);
int initVal     = InputNumber("Введите начальное целое число для заполнения матрицы: ", 1);

int[,] matrix = new int[sizeOfMtrx, sizeOfMtrx];
FillALoopOfMatrix(matrix, 0, matrix.GetLength(0) - 1, 0, matrix.GetLength(0) - 1, initVal);

Console.WriteLine("\nСпирально заполненная матрица:\n");
PrintMatrix(matrix);




void PrintTitle(string message)
{
    string underline = new string('-', message.Length);
    Console.WriteLine($"{message}\n{underline}\n");
}

int InputNumber(string message, int typeOfNumber)
{
    Console.Write(message);
    string input = Console.ReadLine();
    int number = 0;
    switch (typeOfNumber)
    {
        case 0:
            while (!int.TryParse(input, out number) || number < 1)
            {
                Console.Write("Неверный ввод!\nВведите натуральное число: ");
                input = Console.ReadLine();
            }
            break;
        case 1:
            while (!int.TryParse(input, out number))
            {
                Console.Write("Неверный ввод!\nВведите целое число: ");
                input = Console.ReadLine();
            }
            break;
    }
    return number;
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

// Метод корректно заполняет ТОЛЬКО квадратные матрицы.
void FillALoopOfMatrix(int[,] matrix,
                       int initRow,
                       int endRow,
                       int initCol,
                       int endCol,
                       int initVal)
{
    // С помощь четырех циклов пробегаем по периметру заданной матрица (по часовой стрелке) и заполняем один "виток".
    for (int i = initCol; i < endCol; i++)
    {
        matrix[initRow, i] = initVal;
        initVal++;
    }
    for (int i = initRow; i < endRow; i++)
    {
        matrix[i, endCol] = initVal;
        initVal++;
    }
    for (int i = endCol; i > initCol; i--)
    {
        matrix[endRow, i] = initVal;
        initVal++;
    }
    for (int i = endRow; i > initRow; i--)
    {
        matrix[i, initCol] = initVal;
        initVal++;
    }

    // TODO: подумать над условием заполнения и выхода в том случае, если у нас прямоугольная матрица.    
    // Условие для матрицы нечетного размера.
    if (initRow == endRow)
    {
        matrix[endRow, endCol] = initVal;
        return;
    }

    // Условие для матрицы четного размера.
    if (initRow > endRow) return;

    // Рекурсивно вызываем метод, передаем ему границы следующей (вложенной) матрицы
    // и начальное значение для продолжения заполнения.
    FillALoopOfMatrix(matrix,
                      initRow + 1,
                      endRow - 1,
                      initCol + 1,
                      endCol - 1,
                      initVal);
}