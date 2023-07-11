Console.Write("Enter your first string: ");
var string1 = Console.ReadLine();

Console.Write("Enter your second string: ");
var string2 = Console.ReadLine();

if (string1.Length > string2.Length)
{
    Console.WriteLine(string1 + " " + string2);
}
else if (string1.Length == string2.Length)
{
}
else
{
    Console.WriteLine(string2 + string1[0]);
}