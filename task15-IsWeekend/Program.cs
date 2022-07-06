// Задача 15. Напишите программу, которая принимает на вход цифру,
// обозначающую день недели, и проверяет, является ли этот день выходным.
// 6 -> да
// 7 -> да
// 1 -> нет

// Т.е. всего лишь надо узнать равно ли введенное число 6 или 7??

Console.Clear();

Console.Write("Введите номер дня недели: ");
string str = Console.ReadLine();

bool result = int.TryParse(str, out int num);

if (result)
{
    switch (num)
    {
        case < 1:
            Console.WriteLine("Нумерация дней недели начинается с 1.");
            break;
        case > 7:
            Console.WriteLine("В земной неделе семь дней.");
            break;
        case 6:
            Console.WriteLine("Отлично, это суббота! Завтра еще отдыхаем!");
            break;
        case 7:
            Console.WriteLine("Воскресенье, тоже неплохо, но аккуратнее - завтра на работу.");
            break;
        default:
            Console.WriteLine("Будний день, работаем.");
            break;
    }
}
else
    Console.WriteLine("Номер дня недели должен быть целой цифрой. Повторим.");