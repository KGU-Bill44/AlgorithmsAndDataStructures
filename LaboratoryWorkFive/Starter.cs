// See https://aka.ms/new-console-template for more information

using LaboratoryWorkFive;

QueueImpl<int> impl = new QueueImpl<int>();

for (int i = 0; i < 10; i++)
{
    impl.Push(i);
}

foreach (var i in impl)
{
    Console.WriteLine(i);
}