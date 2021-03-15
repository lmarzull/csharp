using System;

namespace RBTree
{
    public enum Color
    {
        Red = 0,
        Black
    }

    public enum ChildDirection
    {
        Left = 0,
        Right
    }


    public class RBTree<T>  where T: IComparable
    {
        public class Node
        {
            public T value { get; set; }
            public Node parent { get; set; }
            public Color color { get; set; }

            public Node child(ChildDirection direction)
            {
                return children[(int)direction];
            }

            Node left
            {
                get => child(ChildDirection.Left);
                set => children[(int)ChildDirection.Left] = value;
            }

            Node right
            {
                get => child(ChildDirection.Right);
                set => children[(int)ChildDirection.Right] = value;
            }

            private Node[] children = new Node[]{null, null};
        }


        public RBTree()
        {
            _root = null;
        }


        public Node getRoot()
        {
            return _root;
        }

        public Node _root;
    }
}