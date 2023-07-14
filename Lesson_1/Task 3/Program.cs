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

// int[] myArray;
// int indexToInsert = 2;
// int elementToInsert = 10;
//
// Array.Resize(ref myArray, myArray.Length + 1); // increase array length by 1
// Array.Copy(myArray, indexToInsert, myArray, indexToInsert + 1, myArray.Length - indexToInsert - 1); // shift elements right from the index
// myArray[indexToInsert] = elementToInsert; // insert element at the index
//
// foreach(int num in myArray) {
//     Console.WriteLine(num);
// }