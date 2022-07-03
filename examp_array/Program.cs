int[] array; //объявляем целочисленный массив
int size = 0; //это будет размер нашего массива

Console.Write("Введите размер массива: ");
size = Convert.ToInt32(Console.ReadLine());
array = new int[size]; // выделяем память для нашего массива

// далее вводим массив поэлементно
for (int i = 0; i < size; i++)
{
    Console.Write("Введите элемент № ");
    Console.WriteLine(Convert.ToString(i));
    array[i] = Convert.ToInt32(Console.ReadLine());
}