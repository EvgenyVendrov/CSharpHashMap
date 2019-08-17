using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMapImplementation
{
    public class MyHashMap<K, V> : IEnumerable where K : IComparable
    {
        //fields:
        private const int _startSize = 13;

        private const int _stepSize = 7;

        private int _numOfElemInArray = 0;

        private KeyValuePair<K, V>[] _innerArray = new KeyValuePair<K, V>[_startSize];

        //public functions: 

        //put function used to set a key of values into the map
        public bool put(K key, V value)
        {
            var newPair = new KeyValuePair<K, V>(key, value);
            bool flag = findElementsRightSpot(_innerArray, newPair);
            if (flag)
            {
                ++_numOfElemInArray;//keeping track of the amount of elements in the map 
                                    //this is done to make sure we wont have a 'too filled' map which will tend more to O(n) rather O(1)
                if (_numOfElemInArray >= (_innerArray.Length * 0.7))
                {
                    _innerArray = resizeArray();//this function will deep-copy the inner array to expand it - while keeping all the elements well placed 
                }

            }

            return flag;

        }

        //get function used to retrive a value based on the given key 
        public V get(K key)
        {
            int index = calcThisKeyIndex(key, _innerArray.Length);

            if (_innerArray[index] == null)
            {
                //in case there is no such key - will print the error and return def value of the type
                Console.WriteLine("ERROR: there is no such a key '{0}', returning default value", key);
                return default(V);
            }

            //searching for the right value to return
            else
            {
                if (_innerArray[index].Key.CompareTo(key) != 0)
                {

                    var current = _innerArray[index];
                    while (current.hasNextNode())
                    {
                        current = current.NextNode;
                        if (current.Key.CompareTo(key) == 0)
                        {
                            return current.Value;
                        }

                    }
                    Console.WriteLine("ERROR: there is no such a key '{0}', returning default value", key);
                    return default(V);

                }
                else
                {
                    return _innerArray[index].Value;
                }
            }
        }



        //this makes it possible to use the map with the [] operator 
        public V this[K key] => get(key);



        //IEnumerable implementation:

        public HashMapEnum<K, V> GetEnumerator()
        {
            resetTheFlags();
            return new HashMapEnum<K, V>(_innerArray);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }


        //used mainly to print the map for debug purposes
        public void printTheHashMap()
        {
            for (var i = 0; i < _innerArray.Length; i++)
            {
                Console.WriteLine("hashmap[{0}]: " + _innerArray[i], i);
                if (_innerArray[i] != null && _innerArray[i].hasNextNode())
                {
                    var c = _innerArray[i];
                    while (c.hasNextNode())
                    {
                        c = c.NextNode;
                        Console.WriteLine("hashmap[{0}]: " + c, i);
                    }
                }
            }
        }

        //private functions:

        //used to return a deep copy of the map - with new 7 cells, placing every elemnt in its new cell based on the new size of the map 
        private KeyValuePair<K, V>[] resizeArray()
        {
            KeyValuePair<K, V>[] output = new KeyValuePair<K, V>[_innerArray.Length + _stepSize];
            foreach (var elem in _innerArray)
            {
                //found new element
                if (elem != null)
                {
                    //finding it the right spot
                    findElementsRightSpot(output, elem);

                    //if this elment has 'children' 
                    if (elem.hasNextNode())
                    {
                        var c = elem.NextNode;
                        while (c.hasNextNode())
                        {
                            findElementsRightSpot(output, c);
                            c = c.NextNode;
                        }
                    }

                }
            }

            return output;
        }


        private int calcThisKeyIndex(K key, int length)
        {
            return Math.Abs(key.GetHashCode() % (length));
        }

        private void resetTheFlags()
        {
            foreach (var elem in _innerArray)
            {
                if (elem != null)
                {
                    if (elem.FlagForForeach)
                    {
                        elem.FlagForForeach = false;
                    }
                    if (elem.hasNextNode())
                    {
                        var current = elem;
                        while (current != null && current.hasNextNode())
                        {
                            current = current.NextNode;
                            current.FlagForForeach = false;
                        }
                    }
                }
            }
        }

        private bool findElementsRightSpot(KeyValuePair<K, V>[] innerArray, KeyValuePair<K, V> element)
        {
            int index = calcThisKeyIndex(element.Key, innerArray.Length);
            //checking if this new index is taken
            if (innerArray[index] != null)
            {
                var current = innerArray[index];
                if (current.Key.CompareTo(element.Key) == 0)
                {
                    Console.WriteLine("ERROR: there is already such a key '{0}' in this HashMap", element.Key);
                    return false;
                }
                while (current != null && current.hasNextNode())
                {
                    current = current.NextNode;
                    if (current.Key.CompareTo(element.Key) == 0)
                    {
                        Console.WriteLine("ERROR: there is already such a key '{0}' in this HashMap", element.Key);
                        return false;
                    }
                }
                current.NextNode = element;
                return true;

            }
            //if this node isn't taken
            else
            {
                innerArray[index] = element;
                return true;
            }

        }




    }
}
