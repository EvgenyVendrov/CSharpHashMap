using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HashMapImplementation
{
    class KeyValuePair <K,V>
    {
        
        public KeyValuePair(K key, V value)
        {
            Key = key;
            Value = value;
            FlagForForeach = false;
            NextNode = null;
        }

        public bool hasNextNode()
        {
            if (NextNode != null)
            {
                return true;
            }
            return false;
        }

        public KeyValuePair<K, V> NextNode
        {
            get;
            set;
        }

        public K Key
        {
            get;
            set;
        }

        public bool FlagForForeach
        {
            get;
            set;
        }

        public V Value {
            get;
            set;
        }

        public override string ToString()
        {
            return "key: "+Key+", value: "+Value;
        }

        public bool nextNodeFlag()
        {
            return NextNode.FlagForForeach;
        }
    }
}
