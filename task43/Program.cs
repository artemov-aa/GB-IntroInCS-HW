// Задача 43
// Напишите программу, которая найдёт точку пересечения двух прямых,
// заданных уравнениями y = k1 * x + b1, y = k2 * x + b2; значения b1, k1, b2 и k2 задаются пользователем.

// b1 = 2, k1 = 5, b2 = 4, k2 = 9 -> (-0,5; -0,5)

// Для вычисления координаты точки пересечения неоюходимо решить систему из двух уравнений:
// | y1 = k1 * x2 + b1     | x = (b2 - b1) / (k1 - k2)
// |                    =  |
// | y2 = k2 * x2 + b2     | y = (k1 * b2 - k2 * b1) / (k1 - k2)


// Метод вычисляет координаты точки пересечения двух прямых в случае, если они не параллельны и не совпадают.
void FindCrossPoint(float[,] attrOfLines, bool[] isParallelOrMatch, float[] crossPoint)
{
    // Условие параллельности прямых: k1 = k2.
    if (attrOfLines[0,0] == attrOfLines[1,0])
    {
        isParallelOrMatch[0] = true;

        // Условие совпадения прямых: (k1 = k2) & (b1 = b2)
        if (attrOfLines[0,1] == attrOfLines[1,1])
            isParallelOrMatch[1] = true;
        return;
    }

    // Находим координату Х.
    crossPoint[0] = (attrOfLines[1,1] - attrOfLines[0,1])
                    / (attrOfLines[0,0] - attrOfLines[1,0]);

    // Находим координату У.
    crossPoint[1] = (attrOfLines[0,0] * attrOfLines[1,1] - attrOfLines[1,0] * attrOfLines[0,1])
                    / (attrOfLines[0,0] - attrOfLines[1,0]);
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

float[,] attrOfLines = new float[2,2];
float[] crossPoint = new float[2];
bool[] isParallelOrMatch = new bool[2];

for (int i = 0; i < attrOfLines.GetLength(1); i++)
    for (int j = 0; j < attrOfLines.GetLength(0); j++)
    {
        if (i == 0)
            Console.Write($"Введите коэфиициент уравнения k{j+1} -> ");
        else
            Console.Write($"Введите свободный член уравнения b{j+1} -> ");
        attrOfLines[j,i] = ValidateNumber(Console.ReadLine());
    }

FindCrossPoint(attrOfLines, isParallelOrMatch, crossPoint);

if (isParallelOrMatch[0] && isParallelOrMatch[1])
    Console.WriteLine("Прямые совпадают.");
else if (isParallelOrMatch[0])
        Console.WriteLine("Прямые параллельны.");
    else    
        Console.WriteLine($"Координаты точки пересечения прямых [{crossPoint[0]}; {crossPoint[1]}].");