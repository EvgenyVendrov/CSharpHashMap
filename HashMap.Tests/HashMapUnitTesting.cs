using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HashMapImplementation;


namespace HashMap.Tests
{
    [TestClass]
    public class MyHashMapTests
    {
        [TestMethod]
        public void putANDget_standartInput_insertIsSuccessful()
        {
            MyHashMap<char, int> test = new MyHashMap<char, int>();
            Assert.IsTrue(test.put('a', 7));
            Assert.AreEqual(test.get('a'), 7);
        }

        [TestMethod]
        public void putANDget_massiveInput_insertIsSuccessful()
        {
            MyHashMap<char, int> test = new MyHashMap<char, int>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.IsTrue(test.put(i, i - '0'));
            }
            var count = 0;
            for (char i = 'a'; i <= 'z'; i++)
            {
                if (test.get(i) == (i - '0'))
                    ++count;
            }
            Assert.AreEqual(26, count);

        }

        [TestMethod]
        public void putANDget_repetitiveKeyOnInput_errorIsShownOnConsole()
        {
            MyHashMap<char, int> test = new MyHashMap<char, int>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.IsTrue(test.put(i, i - '0'));
            }

            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.IsFalse(test.put(i, i - '0'));
            }

        }


        [TestMethod]
        public void foreach_regularUse_shouldReturnAllElements()
        {
            MyHashMap<char, int> test = new MyHashMap<char, int>();
            for (char i = 'a'; i <= 'z'; i++)
            {
                Assert.IsTrue(test.put(i, i - '0'));
            }

            var count = 0;
            foreach(var elemet in test)
            {
                if (elemet != null)
                {
                    count++;
                }
            }
            Assert.IsTrue(count == 26);
        }
    }
}
