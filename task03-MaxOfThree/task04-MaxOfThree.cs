// Задача 4.
// Напишите программу, которая принимает на вход три числа и выдаёт максимальное из этих чисел.
// 2, 3, 7 -> 7
// 44 5 78 -> 78
// 22 3 9 -> 22

Console.Clear();
 int num = 0;
 int maxNum = 0;

 for (int i = 1; i < 4; i++)
 {
    Console.WriteLine($"Введите число № {i}");
    num = Int32.Parse(Console.ReadLine());
    if (num > maxNum)
        maxNum = num;
 }

 Console.WriteLine($"Максимальное число, введенное вами: {maxNum}");