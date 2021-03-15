using System.Text;
using NUnit.Framework;
using BinaryTree;


namespace BinaryTreeTest
{
    class TestNode
    {
        public int value { get; set; }
        public BinaryTree<int>.Node parent { get; set; }
        public BinaryTree<int>.Node left { get; set; }
        public BinaryTree<int>.Node right { get; set; }

        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != typeof(BinaryTree<int>.Node))
                return false;

            return Equals(obj as BinaryTree<int>.Node);
        }
        private bool Equals(BinaryTree<int>.Node node)
        {
            return value.CompareTo(node.value) == 0
                && object.ReferenceEquals(parent, node.parent)
                ;
        }
        public override int GetHashCode()
        {
            return value.GetHashCode();
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder($"{{value={value}, parent=");
            sb.Append(parent != null ? $"{parent.value}" : "null" );
            sb.Append("}}");
            return sb.ToString();
        }

        public TestNode(int v, BinaryTree<int>.Node p)
        {
            value = v;
            parent = p;
        }
    }


    [TestFixture]
    public class BinaryTreeTest
    {
        private BinaryTree<int> tree;


        [SetUp]
        public void Setup()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void CreatingEmptyBinaryTree()
        {
            Assert.AreEqual(null, tree.getRoot());
        }


        [Test]
        public void InsertFirstValue()
        {
            tree.insert(1000);

            Assert.AreNotEqual(null, tree.getRoot());
            Assert.AreEqual(1000, tree.getRoot().value);
            Assert.AreEqual(null, tree.getRoot().left());
            Assert.AreEqual(null, tree.getRoot().right());
        }


        private void buildBSTree()
        {
            //
            //          1000
            //          /  \
            //       500   1500
            //       /     /  \
            //     1    1250  2000
            //                  \
            //                  3000
            foreach (var item in new[]{1000, 500, 1500, 2000, 1, 3000, 1250})
            {
                tree.insert(item);
            }
        }


        [Test]
        public void BuildBSTree()
        {
            buildBSTree();

            var _1000 = tree.getRoot();
            Assert.AreEqual(new TestNode(1000, null), _1000);

            var _500 = _1000.left();
            Assert.AreEqual(new TestNode(500, _1000), _500);

            var _1 = _500.left();
            Assert.AreEqual(new TestNode(1, _500), _1);

            var _1500 = _1000.right();
            Assert.AreEqual(new TestNode(1500, _1000), _1500);

            var _1250 = _1500.left();
            Assert.AreEqual(new TestNode(1250, _1500), _1250);

            var _2000 = _1500.right();
            Assert.AreEqual(new TestNode(2000, _1500), _2000);

            var _3000 = _2000.right();
            Assert.AreEqual(new TestNode(3000, _2000), _3000);
        }


        [Test]
        public void TestFindRoot()
        {
            buildBSTree();
            var _1000 = tree.find(1000);
            Assert.AreEqual(new TestNode(1000, null), _1000);
        }

        [Test]
        public void TestFindNotFound()
        {
            buildBSTree();
            var _does_not_exists = tree.find(-1);
            Assert.AreEqual(null, _does_not_exists);
        }

        [Test]
        public void TestFindLeaf()
        {
            buildBSTree();
            var _leaf = tree.find(1250);
            var _1500 = tree.getRoot().right();
            Assert.AreEqual(new TestNode(1250, _1500), _leaf);
        }
    }


    [TestFixture]
    public class BinarySearchTreeRemoveTest
    {
        [SetUp]
        public void SetUp()
        {
            tree = new BinaryTree<int>();
        }

        [Test]
        public void TestRemoveNotFoundNodeInEmptyTree()
        {
            tree.remove(50);
            Assert.AreEqual(null, tree.getRoot());
        }

        [Test]
        public void TestRemoveRootWithNoChild()
        {
            tree.insert(50);
            tree.remove(50);
            Assert.AreEqual(null, tree.getRoot());
        }

        [Test]
        public void TestRemoveRootWithOneLeftChild()
        {
            tree.insert(50);
            tree.insert(25);
            tree.remove(50);
            var _25 = tree.getRoot();
            Assert.AreEqual(new TestNode(25, null), _25);
        }

        [Test]
        public void TestRemoveRootWithOneRightChild()
        {
            tree.insert(50);
            tree.insert(100);
            tree.remove(50);
            var _100 = tree.getRoot();
            Assert.AreEqual(new TestNode(100, null), _100);
        }

        private void buildTree()
        {
            //                500
            //          /            \
            //         /              \
            //         1             1000
            //          \            /   \
            //          400        750   2000
            //          /                 \
            //       200                 4000
            //      /   \               / 
            //    100   300           3000
            //                          \
            //                          3500
            //
            foreach(var item in new[]{500, 1000, 750, 2000, 4000, 3000, 3500, 1, 400, 200, 100, 300})
            {
                tree.insert(item);
            }
        }

        [Test]
        public void TestRemoveNodeWithParentAndNoChild()
        {
            buildTree();
            tree.remove(300);
            var _200 = tree.getRoot()   // 500
                .left()     //  1
                .right()    // 400
                .left()     // 200
                ;
            Assert.AreEqual(null, _200.right());
        }

        [Test]
        public void TestRemoveNodeWithParentAndOneLeftChild()
        {
            buildTree();
            tree.remove(4000);
            var _2000 = tree.getRoot()   // 500
                .right()    // 1000
                .right()    // 2000
                ;
            var _3000 = _2000.right();
            Assert.AreEqual(new TestNode(3000, _2000), _3000);
        }

        [Test]
        public void TestRemoveNodeWithParentAndOneRightChild()
        {
            buildTree();
            tree.remove(1);
            var _500 = tree.getRoot()   // 500
                ;
            var _400 = _500.left();
            Assert.AreEqual(new TestNode(400, _500), _400);
        }

        [Test]
        public void TestRemoveNodeWithParentAndTwoChildren()
        {
            buildTree();
            tree.remove(1);
            var _500 = tree.getRoot()   // 500
                ;
            var _400 = _500.left();
            Assert.AreEqual(new TestNode(400, _500), _400);
        }

        private BinaryTree<int> tree;
    }
}