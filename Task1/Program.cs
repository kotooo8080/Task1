using System;
using Tree;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = {11, 22, 33, 44, 55, 66, 77, 88};
            MyList<string> dogs = new MyList<string>(); //creating list of dogs

            dogs.Add("Akita"); //addition to list
            dogs.Add("Chin");
            dogs.Add("Husky");
            dogs.Add("Ovcharka");
            dogs.Add("Setter");
            dogs.Add("Beagle");
            dogs.Add("Mustiff");
            dogs.Reverse(); //reverse of list

            Console.WriteLine();
            foreach (var dog in dogs) {
                Console.WriteLine(dog);
            }

            Tree<int> num = new Tree<int>(); //creating tree
            num.Add(122, 1); //addintion nodes to tree with keys
            num.Add(884, 4);
            num.Add(733, 6);
            num.Add(964, 7);
            TNode<int> found = num.Search(4); //searching with key
            num.Remove(7); //removing

            foreach (var element in numbers) {
                Console.Write($"{element} ");
            }
            Console.WriteLine();
            SortByInserts<int>.inReverseOrder(numbers);
            foreach (var element in numbers) {
                Console.Write($"{element} ");
            }
        }

    }
}
