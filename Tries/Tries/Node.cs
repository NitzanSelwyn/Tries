using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Tries
{
    internal class Node
    {
        public char value { get; private set; }
        public Dictionary<char, Node> children = new Dictionary<char, Node>();
        public bool isEndWord;

        public Node(char value)
        {
            this.value = value;
        }

        public override string ToString()
        {
            return $"value = {this.value}";
        }

        public bool HasChild(char ch)
        {
            return children.ContainsKey(ch);
        }

        public void AddChild(char ch)
        {
            children.Add(ch, new Node(ch));
        }

        public Node GetChild(char ch)
        {
            if (HasChild(ch))
            {
                return children[ch];
            }

            return null;
        }

        public Node[] GetChildren()
        {
            return children.Values.ToArray();
        }

        public bool HasChildren()
        {
            return !(children.Count == 0);
        }

        public void RemoveChild(char ch)
        {
            children.Remove(ch);
        }
    }
}
