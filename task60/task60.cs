// Задача 60
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 12(0,0,0) 22(0,0,1)
// 45(1,0,0) 53(1,0,1)

Console.Clear();
PrintTitle("Задача 60. Трехмерный массив из неповторяющихся элементов");

int height   = InputNumber("Введите размер (H) трехмерного массива (H x W x D): ", 0);
int width    = InputNumber("Введите размер (W) трехмерного массива (H x W x D): ", 0);
int depth    = InputNumber("Введите размер (D) трехмерного массива (H x W x D): ", 0);
int minValue = InputNumber("Введите минимальное значение для элементов массива: ", 1);
int maxValue = InputNumber("Введите максимальное значение для элементов массива: ", 1);

int[,,] matrix = new int[height, width, depth];
if (Fill3DMatrix(matrix))
{
    Console.WriteLine("\nСформированный трехмерный массив из неповторяющихся элементов:\n");
    Print3DMatrix(matrix);
}

Console.WriteLine();




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

bool Fill3DMatrix(int[,,] matrix, int min = 10, int max = 99)
{
    int heightOfMatrix  = matrix.GetLength(0);
    int widthOfMatrix   = matrix.GetLength(1);
    int depthOfMatrix   = matrix.GetLength(2); 

    /* Для фиксирования "использованных" чисел применяется булевый массив,
       размер которого равен диапазону возможных значений элементов трехмерного массива.*/
    bool[] elements = new bool[max - min + 1];
    if (matrix.Length > elements.Length)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nОбщий размер массива больше заданного диапазона значений для элементов.");
        Console.WriteLine("Заполнение неповторяющимися элементами невозможно.");
        Console.WriteLine("Программа завершит работу...");
        Console.ResetColor();
        return false;
    }
    var rnd = new Random();
    for (int i = 0; i < depthOfMatrix; i++)
    {
        for (int j = 0; j < heightOfMatrix; j++)
        {
            for (int k = 0; k < widthOfMatrix; k++)
            {
                matrix[j, k, i] = rnd.Next(min, max + 1);

                // Помечаем элемент булевого массива с индексом, равным сгенерированному числу со смещением -min.
                if (!elements[matrix[j, k, i] - 10]) elements[matrix[j, k, i] - 10] = true;

                // Если значение уже использовалось, откатываем счетчик цикла на одну итерацию назад.
                else k -= 1;
            }
        }
    }
    return true;
}

void Print3DMatrix(int[,,] matrix)
{
    int heightOfMatrix  = matrix.GetLength(0);
    int widthOfMatrix   = matrix.GetLength(1);
    int depthOfMatrix   = matrix.GetLength(2);

    for (int i = 0; i < widthOfMatrix; i++)
    {
        for (int j = 0; j < heightOfMatrix; j++)
        {
            for (int k = 0; k < depthOfMatrix; k++)
            {
                Console.Write($"{matrix[j, i, k]} "); Thread.Sleep(30);
                Console.Write("[{0}, {1}, {2}]\t", j, i, k); Thread.Sleep(30);
            }
            Console.WriteLine(); Thread.Sleep(80);
        }
        Console.WriteLine(); Thread.Sleep(150);
    }
}