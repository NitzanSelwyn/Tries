using System;
using System.Collections.Generic;
using System.Text;

namespace Tries
{
    public class Trie
    {
        private Node root = new Node(' ');

        public void Insert(string word)
        {
            var current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.HasChild(word[i]))
                    current.AddChild(word[i]);

                current = current.GetChild(word[i]);
            }
            current.isEndWord = true;
        }

        public bool Contains(string word)
        {
            if (word == null)
                return false;

            var current = root;
            for (int i = 0; i < word.Length; i++)
            {
                if (!current.HasChild(word[i]))
                    return false;

                current = current.GetChild(word[i]);
            }

            return current.isEndWord;
        }

        public void Traverse()
        {
            Traverse(root);
        }

        private void Traverse(Node root)
        {
            //pre-order : visit the root first
            Console.WriteLine(root.value);
            var children = root.GetChildren();
            for (int i = 0; i < children.Length; i++)
                Traverse(children[i]);

            //Post Order
            //var children = root.GetChildren();
            //for (int i = 0; i < children.Length; i++)
            //    Traverse(children[i]);

            //Console.WriteLine(root.value);
        }

        public void Remove(string word)
        {
            if (word == null)
                return;
            Remove(root, word, 0);
        }

        private void Remove(Node root, string word, int index)
        {
            if (index == word.Length)
            {
                root.isEndWord = false;
                return;
            }


            var ch = word[index];
            var child = root.GetChild(ch);

            if (child == null)
                return;

            Remove(child, word, index + 1);

            if (!child.HasChildren() && child.isEndWord)
                root.RemoveChild(ch);
        }

        public List<string> FindWords(string prefix)
        {
            if (prefix == null)
                return null;

            var words = new List<string>();
            var lastNode = FindLastNodeOf(prefix);
            FindWords(lastNode, prefix, words);

            return words;
        }

        private void FindWords(Node root, string prefix, List<string> words)
        {
            if (root == null)
                return;

            if (root.isEndWord)
                words.Add(prefix);

            for (int i = 0; i < root.GetChildren().Length; i++)
            {
                var childrens = root.GetChildren();
                FindWords(childrens[i], prefix + childrens[i].value, words);
            }
        }

        private Node FindLastNodeOf(string prefix)
        {
            var current = root;
            for (int i = 0; i < prefix.Length; i++)
            {
                var child = current.GetChild(prefix[i]);
                if (child == null)
                    return null;

                current = child;
            }

            return current;
        }
    }
}
