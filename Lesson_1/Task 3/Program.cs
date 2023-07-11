var listNumbers = new List<decimal>();

for (var i = 0; i < 10; i++)
{
    Console.Write($"Enter {i + 1} number of array: ");
    listNumbers.Add(Convert.ToDecimal(Console.ReadLine()));
}

Console.Write("Enter a number, which you want to dublicate: ");
var number = Convert.ToDecimal(Console.ReadLine());

for (var i = 0; i < 10; i++)
{
    if (listNumbers[i] == number)
    {
        listNumbers.Add(number);
    }
    
}

Console.WriteLine($"Your array after dublicating: {string.Join(", ", listNumbers)}");