namespace AA_Tree
{
    using System;

    internal class AATree<TKey, TValue> where TKey : IComparable<TKey>
    {
        private readonly Node emptyNode;
        private Node root;
        private Node deletedNode;

        public AATree()
        {
            this.emptyNode = new Node();
            this.Root = this.emptyNode;
        }

        public Node Root
        {
            get { return this.root; }
            private set { this.root = value; }
        }

        public TValue this[TKey key]
        {
            get
            {
                Node node = this.Search(this.root, key);
                return node == null ? default(TValue) : node.value;
            }

            set
            {
                Node node = this.Search(this.root, key);
                if (node == null)
                {
                    this.Add(key, value);
                }
                else
                {
                    node.value = value;
                }
            }
        }

        public bool Add(TKey key, TValue value)
        {
            return this.Insert(ref this.root, key, value);
        }

        public bool Remove(TKey key)
        {
            return this.Delete(ref this.root, key);
        }

        private void Skew(ref Node node)
        {
            if (node.level == node.left.level)
            {
                Node left = node.left;
                node.left = left.right;
                left.right = node;
                node = left;
            }
        }

        private void Split(ref Node node)
        {
            if (node.right.right.level == node.level)
            {
                Node right = node.right;
                node.right = right.left;
                right.left = node;
                node = right;
                node.level++;
            }
        }

        private bool Insert(ref Node node, TKey key, TValue value)
        {
            if (node == this.emptyNode)
            {
                node = new Node(key, value, this.emptyNode);
                return true;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (this.Insert(ref node.left, key, value) == false)
                {
                    return false;
                }
            }
            else if (compare > 0)
            {
                if (this.Insert(ref node.right, key, value) == false)
                {
                    return false;
                }
            }
            else
            {
                return false;
            }

            this.Skew(ref node);
            this.Split(ref node);

            return true;
        }

        private bool Delete(ref Node node, TKey key)
        {
            if (node == this.emptyNode)
            {
                return this.deletedNode != null;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                if (this.Delete(ref node.left, key) == false)
                {
                    return false;
                }
            }
            else
            {
                if (compare == 0)
                {
                    this.deletedNode = node;
                }

                if (this.Delete(ref node.right, key) == false)
                {
                    return false;
                }
            }

            if (this.deletedNode != null)
            {
                this.deletedNode.key = node.key;
                this.deletedNode.value = node.value;
                this.deletedNode = null;
                node = node.right;
            }
            else if (node.left.level < node.level - 1 ||
                     node.right.level < node.level - 1)
            {
                node.level--;
                if (node.right.level > node.level)
                {
                    node.right.level = node.level;
                }

                this.Skew(ref node);
                this.Skew(ref node.right);
                this.Skew(ref node.right.right);
                this.Split(ref node);
                this.Split(ref node.right);
            }

            return true;
        }

        private Node Search(Node node, TKey key)
        {
            if (node == this.emptyNode)
            {
                return null;
            }

            int compare = key.CompareTo(node.key);
            if (compare < 0)
            {
                return this.Search(node.left, key);
            }
            else if (compare > 0)
            {
                return this.Search(node.right, key);
            }
            else
            {
                return node;
            }
        }

        public class Node
        {
            internal int level;
            internal Node left;
            internal Node right;

            internal TKey key;
            internal TValue value;

            internal Node()
            {
                this.level = 0;
                this.left = this;
                this.right = this;
            }

            internal Node(TKey key, TValue value, Node emptyNode)
            {
                this.level = 1;
                this.left = emptyNode;
                this.right = emptyNode;
                this.key = key;
                this.value = value;
            }
        }
    }
}
