using NUnit.Framework;
using BinaryTree;

namespace BinaryTreeTest
{
    [TestFixture]
    public class BinaryTreeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CreatingEmptyBinaryTree()
        {
            var tree = new BinaryTree<string>();
            Assert.AreEqual(tree.getRoot(), null);
        }
    }
}