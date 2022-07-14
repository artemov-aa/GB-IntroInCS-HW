// Задача 43
// Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.
// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

// Для вычисления координаты точки пересечения неоюходимо решить систему из двух уравнений:
// | y = k1 * x + b1     | x = (b2 - b1) / (k1 - k2)
// |                  =  |
// | y = k2 * x + b2     | y = k2 * x + b2 

float[] FindCrossPoint(float k1, float b1, float k2, float b2, ref bool isParallel, ref bool isMatch)
{
    float[] crossPoint = new float[2];

    if (k1 == k2)
    {
        isParallel = true;
        if (b1 == b2) isMatch = true;
        return crossPoint;
    }

    // Находим координату Х.
    crossPoint[0] = (b2 - b1) / (k1 - k2);

    // Находим координату У.
    crossPoint[1] = k2 * crossPoint[0] + b2;
    return crossPoint;
}

float ValidateNumber(string input)
{
    float result;

    while (!float.TryParse(input, out result))
    {
        Console.Write("Неверный ввод! \nВведите число -> ");
        input = Console.ReadLine();
    }

    return result;
}

Console.Clear();

Console.Write($"Введите коэффициент k1 -> ");
float k1 = ValidateNumber(Console.ReadLine());

Console.Write($"Введите коэфиициент b1 -> ");
float b1 = ValidateNumber(Console.ReadLine());

Console.Write($"Введите коэффициент k2 -> ");
float k2 = ValidateNumber(Console.ReadLine());

Console.Write($"Введите коэффициент b2 -> ");
float b2 = ValidateNumber(Console.ReadLine());

bool isParallel = false;
bool isMatch = false;

float[] crossPoint = FindCrossPoint(k1, b1, k2, b2, ref isParallel, ref isMatch);

if (!isParallel)
    Console.WriteLine($"Координаты точки пересечения прямых [{crossPoint[0]}; {crossPoint[1]}].");
else if(isMatch)
    Console.WriteLine("Прямые совпадают.");
    else Console.WriteLine("Прямые параллельны.");