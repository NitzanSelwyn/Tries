using System;

namespace Tries
{
    class Program
    {
        static void Main(string[] args)
        {
            var trie = new Trie();
            trie.Insert("car");
            trie.Insert("card");
            trie.Insert("care");
            trie.Insert("careful");
            trie.Insert("egg");
            var words = trie.FindWords("care");
            Console.WriteLine(words.ToString());

        }
    }
}
