Console.Clear();

int num1, num2;
Console.Write("Введите первое число: ");
num1 = Int32.Parse(Console.ReadLine());
Console.Write("Введите второе число: ");
num2 = Int32.Parse(Console.ReadLine());

if (num1 > num2)
    Console.WriteLine($"Число {num1} больше, чем {num2}");
else
    if (num2 > num1)
        Console.WriteLine($"Число {num2} больше, чем {num1}");
    else
        Console.WriteLine($"Числа {num1} и {num2} равны");