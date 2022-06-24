Console.Clear();

int dist = 0;
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

while (dist > 10)
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
    count++;
}

Console.WriteLine($"Пёсик пробежит туда-сюда: {count} раз(а)");