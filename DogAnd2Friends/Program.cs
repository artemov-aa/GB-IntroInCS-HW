Console.Clear();

int dist = 0;
int meetDist = 10;
int firstFriendSpeed = 0;
int secondFriendSpeed = 0;
int dogSpeed = 0;
int friend = 1;
int time = 0;
int count = 0;

Console.Write("Введите расстояние между друзьями (в метрах): ");
dist = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите скорость первого друга (в м/с): ");
firstFriendSpeed = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите скорость второго друга (в м/с): ");
secondFriendSpeed = Convert.ToInt32(Console.ReadLine());
Console.Write("Введите скорость пёсика (в м/с): ");
dogSpeed = Convert.ToInt32(Console.ReadLine());

// вычисление масштаба в зависимости от расстояния между друзьями
// int winWidth = Console.WindowWidth;
// Console.WriteLine(Convert.ToString(winWidth));
// int scale = dist / winWidth;

// Console.SetCursorPosition(0, 8);
// Console.Write("F1");
// Console.SetCursorPosition(dist / scale - 2, 8);
// Console.Write("F2");

while (dist > meetDist)
{
    if (friend == 1)
    {
        time = dist / (firstFriendSpeed + dogSpeed);
        friend = 2;
    }
    else
    {
        time = dist / (secondFriendSpeed + dogSpeed);
        friend = 1;
    }
    dist = dist - (firstFriendSpeed + secondFriendSpeed) * time;
    //Console.WriteLine(Convert.ToString(dist));
    count++;
}

//Console.WriteLine("Пёсик пробежит туда-сюда: " + count + " раз(а)"); // эта конструкция тоже работает
Console.WriteLine($"Пёсик пробежит туда-сюда: {count} раз(а)");