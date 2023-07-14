var listNumbers = new decimal[10];

for (var i = 0; i < 10; i++)
{
    Console.Write($"Enter {i + 1} number of array: ");
    listNumbers[i] = Convert.ToDecimal(Console.ReadLine());
    // listNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
}

Console.Write("Enter a number, which you want to dublicate: ");
var number = Convert.ToDecimal(Console.ReadLine());

for (var i = 0; i < listNumbers.Length; i++)
{
    if (listNumbers[i] == number)
    {
        var dublicatedNumberIndex = i + 1;
        Array.Resize(ref listNumbers, listNumbers.Length + 1);
        Array.Copy(listNumbers, i, listNumbers, dublicatedNumberIndex, listNumbers.Length - dublicatedNumberIndex);
        listNumbers[dublicatedNumberIndex] = number;
        i++;
    }
}

Console.WriteLine($"Your array after dublicating: {string.Join(", ", listNumbers)}");
