using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _22032017_medium
{
    class Program
    {
        private static string[] lines = File.ReadAllLines("enable1.txt");
        private static string longest = "";

        static void Main(string[] args)
        {
            Console.WriteLine("Podaj frazę");
            string letters = Console.ReadLine();

            Node<string> root = new Node<string>(letters); // korzeń
            buildTree(root);
            findAnswer(root);

            Console.WriteLine("Wynik: " + longest);
            Console.ReadKey();
        }

        private static void buildTree(Node<string> parent)
        {
            string data = parent.getData();
            foreach (var line in lines) // dla każdej znalezionej możliwości, dodawaj nowy węzeł
            {
                if (line.Length == data.Length + 1 && line.Contains(data))
                {
                    try
                    {
                        parent.addChild(new Node<string>(line));
                    }
                    catch(NullReferenceException)
                    {
                        Console.WriteLine("Empty child");
                    }
                }
            }

            if (parent.isLeaf()) return; // jeśli liść to przerwij
            var children = parent.getChildren();
            foreach (var child in children) buildTree(child);
        }

        private static void findAnswer(Node<string> parent)
        {
            if (parent.getData().Length > longest.Length) longest = parent.getData();
            if (parent.isLeaf()) return; // jeśli liść to przerwij
            var children = parent.getChildren();
            foreach (var child in children) findAnswer(child);
        }
    }
}
