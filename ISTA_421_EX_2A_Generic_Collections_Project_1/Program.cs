using System;
using System.Collections.Generic;
using System.Linq;

namespace ISTA_421_EX_2A_Generic_Collections_Project_1
{
    //******** Copied From HW Assinment ***********
    public class Program
    {
        static void Main()
        {
            var d = new MyDictionary();
            try
            {
                Console.WriteLine(d["Cats"]);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            d["Cats"] = 42;
            d["Dogs"] = 17;
            Console.WriteLine($"{(int)d["Cats"]}, {(int)d["Dogs"]}");
        }

    }
    //******** End of Copy From HW Assinment ***********

    //Keyvalue does not use the Object Type anymore
    struct KeyValue<T>
    {
        public readonly string key;
        public readonly T value;

        public KeyValue(string key, T value)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class MyDictionary
    {
        //My dictionary uses a keyvalue of type integer
        private KeyValue<int>[] _keyValues = new KeyValue<int>[10];
        private int numKeyValues = 0;

        public int this[string key]
        {
            get
            {
                foreach (var keyValue in this._keyValues)
                {
                    if (keyValue.key == key)
                    {
                        return keyValue.value;
                    }
                }
                throw new Exception("KeyNotFoundException");
            }
            set
            {
                //Creates new Keyvalue to update existing key or add to the array
                KeyValue<int> newKeyValue = new KeyValue<int>(key, value);

                bool keyExists = false;
                for (int i = 0; i < _keyValues.Length; i++)
                {
                    if (_keyValues[i].key == key)
                    {
                        _keyValues[i] = newKeyValue;
                        keyExists = true;
                    }
                }
                //Adds the newly created keyValue to the Array at the next index
                if (keyExists == false)
                {
                    this._keyValues[numKeyValues] = newKeyValue;
                    //Increases the index value to store the next created keyValue when called
                    numKeyValues++;
                }
            }
        }
    }
}
