using System;

namespace BinaryTree
{
    enum Color
    {
        Red,
        Black
    }


    public class BinaryTree<T>
    {
        public class Node
        {
            T   value;
            Node[] children = new Node[2];
            Node parent;
            Color color = Color.Red;
        }

        public Node getRoot() { return _root; }

        private Node _root;
    }
}
