// Задача 21.
// Напишите программу, которая принимает на вход координаты двух точек
// и находит расстояние между ними в 3D пространстве.
// A (3,6,8); B (2,1,-7), -> 15.84
// A (7,-5, 0); B (1,-1,9) -> 11.53

// AB = √ (x b — x a) 2 + (y b — y a) 2 + (z b — z a) 2.
// Где: x a; y a; z a — координаты первой точки, x b; y b; z b — координаты второй точки.

float[] dotA = new float[3];
float[] dotB = new float[3];
string coordinatesOfDotA = String.Empty;
string coordinatesOfDotB = String.Empty;

// Метод принимает на вход строку с координатами точки, производит валидацию и конвертацию данных,
// заполняет массив координат.
bool ValidateAndFillCoordinates(float[] array, string coordinates)
{
    string[] arrayOfCoordinates = coordinates.Split(' ');
    if (arrayOfCoordinates.Length != array.Length)
        return false;
    else
    {
        int i = 0;
        foreach (string element in arrayOfCoordinates)
        {
            if (!float.TryParse(arrayOfCoordinates[i], out float result))
                return false;
            else
            {
                array[i] = result;
                i++;
            }
        }
        return true;
    }
}

float DistanceBetweenDots(float[] dotA, float[] dotB)
{
    float distance = (float)Math.Sqrt(Math.Pow(dotB[0] - dotA[0], 2) + Math.Pow(dotB[1] - dotA[1], 2) + Math.Pow(dotB[2] - dotA[2], 2));
    return distance;
}


Console.Clear();
do
{
    Console.Write("Введите коодинаты точки А через пробел (x y z): ");
    coordinatesOfDotA = Console.ReadLine();

    Console.Write("Введите коодинаты точки B через пробел (x y z): ");
    coordinatesOfDotB = Console.ReadLine();
}
while (!ValidateAndFillCoordinates(dotA, coordinatesOfDotA) || !ValidateAndFillCoordinates(dotB, coordinatesOfDotB));

Console.WriteLine($"Расстояние между точками равно: {DistanceBetweenDots(dotA, dotB)}");