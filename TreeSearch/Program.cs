using System;
using System.Collections.Generic;

namespace TreeSearch
{
    public class Program
    {
        public static void Main()
        {
            TreeNode tree = new TreeNode(1);
            TreeNode node = new TreeNode(2);
            tree.AddChildren(node, new TreeNode(3), new TreeNode(4));
            node.AddChildren(new TreeNode(5), new TreeNode(6));

            Console.WriteLine("Breadth Search:");
            BreadthSearch(tree);

            Console.WriteLine();
            Console.WriteLine("Depth Search:");
            DepthSearch(tree);
        }

        public static string DepthSearch(TreeNode tree)
        {
            // Build the stack of the tree search
            Stack<Record> stack = new Stack<Record>();

            // Start from the root
            stack.Push(new Record(tree, 0));

            string output = "";
            while (stack.Count > 0)
            {
                Record topRecord = stack.Peek();
                TreeNode current = topRecord.Node;
                int childrenChecked = topRecord.ChildrenChecked;

            // Process the node when the first time discovered
                if (0 == childrenChecked)
                {
                    ProcessNode(current, ref output);
                }

            // Remove the node from stack when no more children to process
                if (childrenChecked == current.Children.Count)
                {
                    stack.Pop();
                    continue;
                }
            
            // Put the next not processed child on the stack
                topRecord.ChildrenChecked += 1;
                stack.Push(new Record( current.Children[childrenChecked], 0 ));
            }

            return output;
        }

        public static string BreadthSearch(TreeNode tree)
        {
            // Build the queue of the tree search
            Queue<TreeNode> queue = new Queue<TreeNode>();
            
            // Start from the root
            queue.Enqueue(tree);

            string output = "";
            while (queue.Count > 0)
            {
                TreeNode current = queue.Dequeue();
                ProcessNode(current, ref output);

            // Add all children of the current node to the queue
                foreach(TreeNode node in current.Children)
                {
                    queue.Enqueue(node);
                }
            }

            return output;
        }

        public static void ProcessNode(TreeNode node, ref string output)
        {
            Console.Write(node.Value + " ");
            output += node.Value + " ";
        }
    }

    public class Record
    {
        public TreeNode Node { get; set; }
        public int ChildrenChecked { get; set; }

        public Record(TreeNode node, int childrenChecked)
        {
            Node = node;
            ChildrenChecked = childrenChecked;
        }
    }

    public class TreeNode
    {
        public int Value { get; set; }

        private List<TreeNode> _children = new List<TreeNode>();
        public List<TreeNode> Children {
            get {
                return _children;
            }
        }

        public TreeNode(int val)
        {
            Value = val;
        }

        public TreeNode(int val, params TreeNode[] children)
        {
            Value = val;
            AddChildren(children);
        }

        public void AddChildren(params TreeNode[] children)
        {
            foreach (TreeNode node in children)
            {
                if (null != node)
                {
                    _children.Add(node);
                }
            }
        }
    }
}
