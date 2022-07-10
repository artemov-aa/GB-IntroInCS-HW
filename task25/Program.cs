// Задача 25.
// Напишите цикл, который принимает на вход два числа (A и B)
// и возводит число A в натуральную степень B.
// 3, 5 -> 243 (3⁵)
// 2, 4 -> 16

Console.Clear();

int[] array = new int[2];
int pow = 0;

for (int i = 0; i < 2; i++)
{
    Console.Write($"Введите {i+1}-е число: ");
    int.TryParse(Console.ReadLine(), out array[i]);
}

pow = (int)Math.Pow(array[0], array[1]);
Console.WriteLine($"Число {array[0]} в степени {array[1]} равно {pow}");