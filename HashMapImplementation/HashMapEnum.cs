using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMapImplementation
{
    //the Enum class which provides the ability to use 'foreach' and 'linq' on the hashmap DS
    class HashMapEnum<K,V> : IEnumerator where K:IComparable
    {
        public KeyValuePair<K,V>[] _hashMapElems;
        int position = -1;
        
        //ctor
        public HashMapEnum(KeyValuePair<K,V>[] innerArray)
        {
            _hashMapElems = innerArray;
        }

        //method to return 'Current'
        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        
        public KeyValuePair<K, V> Current
        {
            get
            {
                try
                {
                    //skip all the empty - null cells as they dont belong 
                    while (position < _hashMapElems.Length - 1 && _hashMapElems[position] == null)
                    {
                        position++;
                    }
                    //this made to iterate the node's connected in certain cell
                    if (_hashMapElems[position]!=null && _hashMapElems[position].hasNextNode()&&_hashMapElems[position].nextNodeFlag()==false)
                    {
                      var c = _hashMapElems[position];
                      while (c.NextNode.hasNextNode()&&_hashMapElems[position].NextNode.nextNodeFlag()==false)
                    {
                            c = c.NextNode;
                    }
                        c.NextNode.FlagForForeach = true;
                        position--;
                        return c.NextNode;
                    }
                    return _hashMapElems[position];
                }
                catch (IndexOutOfRangeException)
                {
                    throw new InvalidOperationException();
                }
            }
        }

        //both functions standart implementation
        public bool MoveNext()
        {
                position++;
            
            return (position < _hashMapElems.Length);
        }

        public void Reset()
        {
            position = -1;
        }
    }
}
