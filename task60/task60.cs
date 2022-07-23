// Задача 60
// Сформируйте трёхмерный массив из неповторяющихся двузначных чисел.
// Напишите программу, которая будет построчно выводить массив, добавляя индексы каждого элемента.
// массив размером 2 x 2 x 2
// 12(0,0,0) 22(0,0,1)
// 45(1,0,0) 53(1,0,1)

void Fill3DMatrix(int[,,] matrix, int min = 10, int max = 99)
{
    int n1 = matrix.GetLength(0);
    int n2 = matrix.GetLength(1);
    int n3 = matrix.GetLength(2);
    // TODO: Если количество элементов трехмерного массива больше диапазона max-min,
    // то его заполнение неповторяющимися значениями невозможно.

    // Для фиксирования "использованных" чисел применяется булевый массив,
    // размер которого равен диапазону возможных значений элементов трехмерного массива.
    bool[] elements = new bool[max - min + 1];

    var rnd = new Random();

    for (int i = 0; i < n3; i++)
    {
        for (int j = 0; j < n1; j++)
        {
            for (int k = 0; k < n2; k++)
            {
                matrix[j, k, i] = rnd.Next(min, max + 1);

                // Помечаем элемент булевого массива с индексом, равным сгенерированному числу со смещением -min.
                if (!elements[matrix[j, k, i] - 10]) elements[matrix[j, k, i] - 10] = true;

                // Если значение уже использовалось, то откатываем счетчик цикла назад,
                // до следующего уникального значения.
                else k -= 1;
            }
        }
    }
}

void Print3DMatrix(int[,,] matrix)
{
    int n1 = matrix.GetLength(0);
    int n2 = matrix.GetLength(1);
    int n3 = matrix.GetLength(2);

    for (int i = 0; i < n2; i++)
    {
        for (int j = 0; j < n1; j++)
        {
            for (int k = 0; k < n3; k++)
            {
                Console.Write($"{matrix[j, i, k]} "); Thread.Sleep(50);
                Console.Write("[{0}, {1}, {2}]\t", j, i, k); Thread.Sleep(50);
            }
            Console.WriteLine(); Thread.Sleep(200);
        }
        Console.WriteLine(); Thread.Sleep(300);
    }
}

//------------------------------------------------------------------------------------------------------------------//

Console.Clear();

int m = 0;
int initVal = 0;
bool errorOcured = false;

Console.WriteLine("==== Построчный вывод трехмерного массива из неповторяющихся элементов ====\n");

try
{
    Console.Write("Введите размер стороны квадратной матрицы >> ");
    m = Convert.ToInt32(Console.ReadLine());

    Console.Write("Введите начальное целое число для заполнения матрицы >> ");
    initVal = Convert.ToInt32(Console.ReadLine());

    if (m < 0 ) throw new FormatException();
}
catch (FormatException e)
{
    Console.WriteLine("Неверный ввод! [Подробности: {0}]", e.Message);
    Console.WriteLine("Программа завершит работу...");
    errorOcured = true;
}

int[,,] matrix = new int[2, 2, 2];

Fill3DMatrix(matrix);

Console.WriteLine("Сформированный трехмерный массив из неповторяющихся элементов:\n");
Print3DMatrix(matrix);