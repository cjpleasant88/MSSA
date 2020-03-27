using System;
//using System.Linq; //Only used if using the LinQ command in Line 55

namespace ISTA421_EX_1B_Key_Value_Store
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

    struct KeyValue
    {
        public readonly string key;
        public readonly object value;

        public KeyValue(string key, object value = null)
        {
            this.key = key;
            this.value = value;
        }
    }

    public class MyDictionary
    {
        private KeyValue[] _keyValues = new KeyValue[3];
        private int numKeyValues = 0;

        //Don't need anything but the default constructor that is implicitly implemented
        //public MyDictionary(string keyValue)
        //{
        //}

        public object this[string key]
        {
            get
            {
                //With help from youtube, https://www.youtube.com/watch?v=km1hd9-dVz4
                //this worked with using LinQ commands:
                //return _keyValues.FirstOrDefault(kv => kv.key == key).value;

                //Wanted to find a way to not use LinQ and this seems to work
                foreach ( var keyValue in this._keyValues)
                {
                    if (keyValue.key == key)
                    {
                        return keyValue.value;
                    }
                }
                throw new Exception("KeyNotFoundException");

                //this was a failed first attempt at getting the value within an object, withing and array
                //int i = Array.IndexOf(this._keyValues, key);
                //if (i != -1)
                //{
                //    return this._keyValues[i].value;
                //}
                //throw new Exception($"KeyNotFoundException");
                //else
                //{
                //    return -1;
                //}
            }

            //Because of the readonly fields in KeyValue class, the only way to set them is upon creation
            set
            {
                //Creates new Keyvalue
                KeyValue newKeyValue = new KeyValue(key, value);

                //Adds the newly created keyValue to the Array at the next index
                this._keyValues[numKeyValues] = newKeyValue;

                //Increases the index value to store the next created keyValue when called
                numKeyValues++;
            }
        }
    }
}
