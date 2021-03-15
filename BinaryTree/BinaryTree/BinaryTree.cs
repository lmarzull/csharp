using System;
using System.Text;

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
            public Node parent { get; set; }

            private Node[] children = new Node[2];

            public Node(T value, Node parent)
            {
                this.value = value;
                this.parent = parent;
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

            public override string ToString()
            {
                StringBuilder sb = new StringBuilder($"{{value={value}, parent=");
                sb.Append(parent != null ? $"{parent.value}" : "null");
                sb.Append(", left=");
                sb.Append(left() != null ? $"{left().value}" : "null");
                sb.Append(", right=");
                sb.Append(right() != null ? $"{right().value}" : "null");
                sb.Append("}}");
                return sb.ToString();
            }
        }



        public Node getRoot() { return _root; }

        public void insert(T value)
        {
            _root = _BSTInsert(_root, value);
        }

        public void remove(T value)
        {
            _root = _BSTRemove(_root, value);
        }

        public Node find(T value)
        {
            return _BSTFind(_root, value);
        }

        private Node _root;


        private static Node _BSTInsert(Node _root, T value)
        {
            if (_root == null)
                return new Node(value, null);

            if (value.CompareTo(_root.value) < 0)
            {
                _root.left(_BSTInsert(_root.left(), value));
                _root.left().parent = _root;
            }
            else if (value.CompareTo(_root.value) > 0)
            {
                _root.right(_BSTInsert(_root.right(), value));
                _root.right().parent = _root;
            }
            return _root;
        }

        private static Node _BSTFind(Node _root, T value)
        {
            if (_root == null)
                return null;

            if (value.CompareTo(_root.value) < 0)
            {
                return _BSTFind(_root.left(), value);
            }
            else if (value.CompareTo(_root.value) > 0)
            {
                return _BSTFind(_root.right(), value);
            }
            return _root;
        }

        private static Node _BSTRemove(Node root, T value)
        {
            if (root == null)
                return null;

            if (value.CompareTo(root.value) < 0)
            {
                root.left(_BSTRemove(root.left(), value));
                if (root.left() != null)
                    root.left().parent = root;
            }
            else if (value.CompareTo(root.value) > 0)
            {
                root.right(_BSTRemove(root.right(), value));
                if (root.right() != null)
                    root.right().parent = root;
            }
            else
            {
                if (root.right() == null)
                {
                    if (root.left() != null)
                        root.left().parent = null;
                    return root.left();
                }
                else if (root.left() == null)
                {
                    if (root.right() != null)
                        root.right().parent = null;
                    return root.right();
                }

                Node in_order_successor = _get_in_order_successor(root.right());
                root.value = in_order_successor.value;
                root.right(_BSTRemove(root.right(), value));
                root.right().parent = root;
            }
            return root;
        }


        private static Node _get_in_order_successor(Node node)
        {
            if (node.left() == null)
                return node;
            return _get_in_order_successor(node.left());
        }
    }
}
