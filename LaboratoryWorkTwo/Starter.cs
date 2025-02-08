using LaboratoryWorkTwo;

int[] array = { 111,2,4,325,352,35,435,53,53,53,254,23 };
array = new InsertionSorter(array).Sort();
Console.WriteLine(string.Join(",", array));