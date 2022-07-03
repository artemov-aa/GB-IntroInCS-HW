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