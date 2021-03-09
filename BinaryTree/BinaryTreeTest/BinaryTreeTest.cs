using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTest
{
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
        }


        [Test]
        public void BuildBSTree()
        {
            tree.insert(1000);
            tree.insert(500);
            tree.insert(1500);
            tree.insert(2000);
            tree.insert(1);
            tree.insert(3000);
            tree.insert(1250);
            //
            //          1000
            //          /  \
            //       500   1500
            //       /     /  \
            //     1    1250  2000
            //                  \
            //                  3000

            Assert.AreEqual(1000, tree.getRoot().value);

            Assert.AreNotEqual(null, tree.getRoot().left().value);
            Assert.AreEqual(500, tree.getRoot().left().value);
            Assert.AreEqual(null, tree.getRoot().left().right());

            Assert.AreNotEqual(null, tree.getRoot().left().left());
            Assert.AreEqual(1, tree.getRoot().left().left().value);
            Assert.AreEqual(null, tree.getRoot().left().left().left());
            Assert.AreEqual(null, tree.getRoot().left().left().right());

            Assert.AreNotEqual(null, tree.getRoot().right());
            Assert.AreEqual(1500, tree.getRoot().right().value);

            Assert.AreNotEqual(null, tree.getRoot().right().left());
            Assert.AreEqual(1250, tree.getRoot().right().left().value);

            Assert.AreNotEqual(null, tree.getRoot().right().right());
            Assert.AreEqual(2000, tree.getRoot().right().right().value);

            Assert.AreNotEqual(null, tree.getRoot().right().right().right());
            Assert.AreEqual(3000, tree.getRoot().right().right().right().value);
        }
    }
}