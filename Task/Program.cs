Console.Clear();

const int condition = 3;

Console.WriteLine("Как хотите заполнить массив: ввести вручную на клавиатуре или заполнить случайным образом? h/r");

switch (Console.ReadKey().KeyChar.ToString().ToLower())
{
    case "h":
        Console.WriteLine();
        Console.Write("Введите количество строк, которое хотите ввести: ");
        int length = int.Parse(Console.ReadLine()!);

        Console.WriteLine($"Введите {length} строк(и) без пробелов через Enter: ");

        string[] array = new string[length];

        FillArray(array);
        Console.Write($"Изначальный массив: ");
        PrintArray(array);
        if (FindFinalArrayLength(array, condition) == 0)
        {
            Console.WriteLine($"Нет элементов с количеством символов <= {condition}");
        }
        else
        {
            string[] finArray = MoveElements(array, condition);
            Console.Write($"Новый массив, содержащий элементы с количеством символов <= {condition}: ");
            PrintArray(finArray);
        }
        break;

    case "r":
        Console.WriteLine();
        Console.Write("Введите желаемое количество строк: ");
        int size = int.Parse(Console.ReadLine()!);

        string[] initArray = new string[size];

        FillArrayRandom(initArray, 11);
        Console.Write($"Изначальный массив: ");
        PrintArray(initArray);
        if (FindFinalArrayLength(initArray, condition) == 0)
        {
            Console.WriteLine($"Нет элементов с количеством символов <= {condition}");
        }
        else
        {
            string[] finArray = MoveElements(initArray, condition);
            Console.Write($"Новый массив, садержащий элементы с количеством символов <= {condition}: ");
            PrintArray(finArray);
        }
        break;
    default:
        Console.WriteLine("Нужно ввести одну из букв: h/r");
        break;
}

void FillArray(string[] arr)
{
    for (int i = 0; i < arr.Length; i++)
    {
        arr[i] = Console.ReadLine()!;
    }
}

void FillArrayRandom(string[] arr, int maximumLength)
{
    Random randGenerator = new Random();
    string chars = "0123456789!@#$%^&*()_+=-:;',./?|\abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
    for (int i = 0; i < arr.Length; i++)
    {
        int randElementLength = randGenerator.Next(1, maximumLength);
        for (int j = 0; j < randElementLength; j++)
        {
            arr[i] += chars[randGenerator.Next(0, chars.Length)];
        }
    }
}

void PrintArray(string[] arr)
{
    int arrayLength = arr.Length;
    Console.Write("[");
    for (int i = 0; i < arrayLength; i++)
    {
        Console.Write(arr[i]);
        if (i == arrayLength - 1)
            Console.WriteLine("]");
        else
            Console.Write(", ");
    }
}

int FindFinalArrayLength(string[] arr, int maximumLength)
{
    int finalArrayLength = 0;
    for (int i = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= maximumLength)
        {
            finalArrayLength++;
        }
    }
    return finalArrayLength;
}

string[] MoveElements(string[] arr, int maximumLength)
{
    string[] finalArray = new string[FindFinalArrayLength(arr, maximumLength)];
    for (int i = 0, j = 0; i < arr.Length; i++)
    {
        if (arr[i].Length <= maximumLength)
        {
            finalArray[j] = arr[i];
            j++;
        }
    }
    return finalArray;
}