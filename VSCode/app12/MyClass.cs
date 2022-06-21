using System;

namespace app12
{
    public enum SortedCriterion
    {
        Name,
        Value
    }
    public class MyClass
    {
        public string Name { get; set; }
        public int Value { get; set; }
        static MyClass()
        {
            Console.WriteLine("Constructor without name");
        }
        static void StaticMethod()
        {
            Console.WriteLine("Static method has been called");
        }
        public MyClass(string Name)
        {
            this.Name = Name;
            this.Value = 0;
            Console.WriteLine("Constructor with name");
        }

        public MyClass(string Name, int Value)
        {
            this.Name = Name;
            this.Value = Value;
            Console.WriteLine("Constructor with Name and Value");
        }

        /// <summary>
        /// This is a summmary for POP method
        /// </summary>
        /// <returns>
        /// It doesn't return anything
        /// </returns>
        public void Pop()
        {
            Console.WriteLine("Calling POP");
            StaticMethod();
        }

        public class SortByValue : IComparer<MyClass>
        {
            public int Compare(MyClass a, MyClass b)
            {
                MyClass _a = (MyClass)a;
                MyClass _b = (MyClass)b;
                if (_a.Value == _b.Value)
                {
                    return 0;
                }
                else if (_a.Value > _b.Value)
                {
                    return 1;
                }
                else
                {
                    return -1;
                }
            }
        }

        public class SortByName : IComparer<MyClass>
        {
            public int Compare(MyClass a, MyClass b)
            {
                MyClass _a = (MyClass)a;
                MyClass _b = (MyClass)b;
                return String.Compare(_a.Name, _b.Name);
            }
        }

        public static IComparer<MyClass> SortBy(SortedCriterion criterion)
        {
            if(criterion == SortedCriterion.Value)
            {
                return new SortByValue();
            }
            else
            {
                return new SortByName();
            }
        }
    }
}