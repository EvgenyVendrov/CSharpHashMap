using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMapImplementation
{
    class ExampleMain
    {
        static void Main(string[] args)
        {
            //building 
            MyHashMap<char, int> test = new MyHashMap<char, int>();

            for (char i = 'a'; i <= 'z'; i++)
            {
                test.put(i, i - '0');
            }


            //now printing all elements using foreach
            foreach (var elem in test)
            {
                Console.WriteLine(elem);
            }

            Console.WriteLine("***************************************************");

            //testing the bool thing
            foreach (var elem in test)
            {
                Console.WriteLine(elem);
            }

            //should print an error message as there already such a key
            test.put('f', 56);

            //searching elements by their key:
            Console.WriteLine(test.get('a'));//should return 49
            Console.WriteLine(test.get('b'));//should return 50
            Console.WriteLine(test.get('z'));//shoud return 74
            Console.WriteLine(test.get('@'));//should print error message and return def value of char (0)

            //searching a key with '[]' operator
            Console.WriteLine(test['f']);//should print 54


        }
    }
}
