using System;

namespace app12
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass a = new MyClass("ABC", 90);
            MyClass b = new MyClass("DEF", 4);
            MyClass c = new MyClass("DDR", 112);
            MyClass d = new MyClass("SSD", 1);
            MyClass e = new MyClass("AXU", 56);
            MyClass f = new MyClass("ZUL", -100);
            Console.WriteLine(c.Name);
            c.Pop();
            b.Pop();
            b.Pop();
            List<MyClass> myList = new List<MyClass>(){a,b,c,d,e,f};
            printMyList(myList);
            myList.Sort(MyClass.SortBy(SortedCriterion.Name));
            printMyList(myList);
            myList.Sort(MyClass.SortBy(SortedCriterion.Value));
            printMyList(myList);
        }

        static void printMyList(List<MyClass> list)
        {
            foreach (MyClass item in list)
            {
                Console.WriteLine(item.Name + ": " + item.Value);
            }
        }
    }
}