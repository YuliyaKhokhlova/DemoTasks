using TreeSearch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace TreeSearch_Tests
{
    [TestClass]
    public class TreeSearchTests
    {
        [TestMethod]
        public void DepthSearch6Nodes()
        {
            string expectedOutput = "1 2 5 6 3 4 ";
            string output = Program.DepthSearch(tree6Nodes);
            Assert.AreEqual(expectedOutput, output, "Unexpected order of tree searh");
        }

        [TestMethod]
        public void DepthSearch12Nodes()
        {
            string expectedOutput = "1 2 3 4 5 6 7 8 9 10 11 12 ";
            string output = Program.DepthSearch(tree12Nodes);
            Assert.AreEqual(expectedOutput, output, "Unexpected order of tree searh");
        }

        [TestMethod]
        public void BreadthSearch6Nodes()
        {
            string expectedOutput = "1 2 3 4 5 6 ";
            string output = Program.BreadthSearch(tree6Nodes);
            Assert.AreEqual(expectedOutput, output, "Unexpected order of tree searh");
        }

        [TestMethod]
        public void BreadthSearch12Nodes()
        {
            string expectedOutput = "1 2 7 10 3 4 8 11 12 5 6 9 ";
            string output = Program.BreadthSearch(tree12Nodes);
            Assert.AreEqual(expectedOutput, output, "Unexpected order of tree searh");
        }

        [TestInitialize]
        public void Initialize()
        {
            // Tree with 6 nodes
            // Nodes are enumerated according to breadth search order
            tree6Nodes = new TreeNode(1);
            tree6Nodes.AddChildren(new TreeNode(2, new TreeNode(5), new TreeNode(6)), new TreeNode(3), new TreeNode(4));

            // Tree with 12 nodes
            // Nodes are enumerated according to depth search order
            tree12Nodes = new TreeNode(1);
            TreeNode auxNode1 = new TreeNode(2, new TreeNode(3), new TreeNode(4, new TreeNode(5), new TreeNode(6)));
            TreeNode auxNode2 = new TreeNode(7, new TreeNode(8, new TreeNode(9)));
            TreeNode auxNode3 = new TreeNode(10, new TreeNode(11), new TreeNode(12));
            tree12Nodes.AddChildren(auxNode1, auxNode2, auxNode3);
        }
        public TreeNode tree6Nodes;
        public TreeNode tree12Nodes;
    }
}
