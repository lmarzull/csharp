using NUnit.Framework;
using RBTree;

namespace RBTreeTest
{
    public class RBTreeTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void TestInstanciateRBTree()
        {
            RBTree<int> tree = new RBTree<int>();
        }
    }
}