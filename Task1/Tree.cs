namespace Tree
{
    public class TNode<T>
    {
        public T data;
        public int key;
        public TNode<T> parent = null;
        public TNode<T> left = null;
        public TNode<T> right = null;

        public TNode(T Data, int Key) {
            data = Data;
            key = Key;
        }
    }
    public class Tree<T>
    {
        private TNode<T> root = null;

        public TNode<T> Search(int Key)
        {
            TNode<T> current = root;
            while (current != null)
            {
                if (current.key == Key) 
                    return current;
                else if (current.key > Key) {
                    current = current.left;
                }
                else {
                    current = current.right;
                }
            }
            return null;
        }

        public void Add(T Info, int Key)
        {
            if (root == null)
            {
                root = new TNode<T>(Info, Key);
                return;
            }
            else
            {
                TNode<T> current = root;
                TNode<T> elem = new TNode<T>(Info, Key);
                while (current != null)
                {
                    if (current.key == elem.key)
                        return;
                    else if (current.key > elem.key)
                    {
                        if (current.left == null) {
                            current.left = elem;
                            elem.parent = current;
                            return;
                        }
                        else {
                            current = current.left;
                        }
                    }
                    else
                    {
                        if (current.right == null) {
                            current.right = elem;
                            elem.parent = current;
                            return;
                        }
                        else {
                            current = current.right;
                        }
                    }
                }
            }

        }

        public TNode<T> Min(TNode<T> node)
        {
            if (node.left == null)
            {
                return node;
            }
            return Min(node.left);
        }

        public TNode<T> Max(TNode<T> node)
        {
            if (node.right == null)
            {
                return node;
            }

            return Max(node.right);
        }

        public TNode<T> Next(TNode<T> node)
        {
            if (node.right == null)
                return Min(node.right);

            TNode<T> parent = node.parent;
            while (parent != null && node == parent.right) {
                node = parent;
                parent = parent.parent;
            }
            return parent;
        }

        public TNode<T> Prev(TNode<T> node)
        {
            if (node.left == null)
                return Max(node.right);

            TNode<T> parent = node.parent;
            while (parent != null && node == parent.left) {
                node = parent;
                parent = parent.parent;
            }
            return parent;
        }
    }
}
