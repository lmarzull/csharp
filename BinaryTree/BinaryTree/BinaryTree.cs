using System;

namespace BinaryTree
{
    public class BinaryTree<T> where T: IComparable
    {
        public class Node
        {
            private enum ChildDirection
            {
                Left = 0,
                Right
            }

            public T value { get; set; }

            Node[] children = new Node[2];

            public Node(T value)
            {
                this.value = value;
            }

            public Node left() { return children[(int)ChildDirection.Left];}
            public void left(Node left_child)
            {
                children[(int)ChildDirection.Left] = left_child;
            }
            public Node right() { return children[(int)ChildDirection.Right];}
            public void right(Node right_child)
            {
                children[(int)ChildDirection.Right] = right_child;
            }
        }



        public Node getRoot() { return _root; }

        public void insert(T value)
        {
            var new_node = new Node(value);
            _root = BSTInsert(_root, new_node);
        }

        private Node _root;


        private Node BSTInsert(Node _root, Node new_node)
        {
            if (_root == null)
                return new_node;

            if (new_node.value.CompareTo(_root.value) < 0)
            {
                _root.left(BSTInsert(_root.left(), new_node));
            }
            else if (new_node.value.CompareTo(_root.value) > 0)
            {
                _root.right(BSTInsert(_root.right(), new_node));
            }
            return _root;
        }
    }
}
