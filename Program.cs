using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Work8
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"\tСписок1:");
            CollectionType<string> List1 = new CollectionType<string>();
            List1.Add(List1);
            List1.Add("Привет");

            
            List1.Show(List1);
            Console.WriteLine();

            List1.Delete(List1);
            Console.WriteLine($"\0После удаления нужного элемента:");
            List1.Show(List1);
            Console.WriteLine();

            Console.WriteLine($"\0Список2:");
            CollectionType<string> List2 = new CollectionType<string>();
            List2.Add(List2);
            List2.Add("Пока");

            
            List2.Show(List2);
            Console.WriteLine();

            List2.Delete(List2);
            Console.WriteLine($"\0После удаления нужного элемента:");
            List1.Show(List2);
            Console.WriteLine();


            Console.WriteLine($"\0Равны ли список1 и список2?\0-\0{List1==List2}");
            Console.WriteLine();

            CollectionType<string> List3 = new CollectionType<string>();
            List3 = (List1 + List2);
            Console.WriteLine($"\0Сложение двух списков:");
            List3.Show(List3);
            Console.WriteLine();

            CollectionType<string>.Owner owner = new CollectionType<string>.Owner { ID = 28, name = "Анастасия", Org = "БГТУ" };
            owner.PrintOwner();
            Console.WriteLine();

            CollectionType<string>.Date date = new CollectionType<string>.Date();
            date.InfoDate();
            Console.WriteLine();
        }

    }

    class CollectionType<T> : List<T>, IInterface<T>
    {
        public List<string> Add(List<string> list)
        {
            Console.WriteLine("\0Введите элемент списка:");
            string elem = Console.ReadLine();
            list.Add(elem);
            return list;
        }

        public List<T> Delete(List<T> list)
        {
            Console.WriteLine("\0Укажите номер элемента, который нужно удалить:");
            int num_elem = Convert.ToInt32(Console.ReadLine());
            list.RemoveAt(num_elem);
            return list;
        }

        public void Show(List<T> list)
        {
            foreach (T i in list)
            {
                Console.Write($"\0{i},");
            }
            Console.WriteLine();
        }

        public static CollectionType<string> operator +(CollectionType<T> list1, CollectionType<T> list2)
        {
            CollectionType<string> list3 = new CollectionType<string>();

            foreach (T i in list1) list3.Add(i.ToString());
            foreach (T i in list2) list3.Add(i.ToString());
            return list3;
        }

        public static bool operator ==(CollectionType<T> list1, CollectionType<T> list2)
        {
            return list1.Equals(list2);
        }

        public static bool operator !=(CollectionType<T> list1, CollectionType<T> list2)
        {
            return !list1.Equals(list2);
        }

        public class Owner
        {
            public int ID;
            public string name;
            public string Org;

            public void PrintOwner()
            {
                Console.WriteLine($"\0Owner:\0ID\0-\0{ID};\0имя\0-\0{name};\0учреждение\0-\0{Org}.");
            }
        }

        public class Date
        {
            public void InfoDate()
            {
                Console.WriteLine($"\0Сейчас:\0{DateTime.Now}");
            }
        }
    }

}
