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
            if (root == null) {
                root = new TNode<T>(Info, Key);
                return;
            }
            else {
                TNode<T> current = root;
                TNode<T> treeElem = new TNode<T>(Info, Key);
                while (current != null)
                {
                    if (current.key == treeElem.key)
                        return;
                    else if (current.key > treeElem.key)
                    {
                        if (current.left == null) {
                            current.left = treeElem;
                            treeElem.parent = current;
                            return;
                        }
                        else {
                            current = current.left;
                        }
                    }
                    else {
                        if (current.right == null) {
                            current.right = treeElem;
                            treeElem.parent = current;
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
            if (node.left == null){
                return node;
            }
            return Min(node.left);
        }

        public TNode<T> Max(TNode<T> node)
        {
            if (node.right == null){
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

        public bool Remove(int Key)
        {
            TNode<T> treeElem = Search(Key);
            if (treeElem == null)
                return false;
            else
            {
                TNode<T> parent = treeElem.parent;
                if (treeElem.left == null && treeElem.right == null)
                {
                    if (parent.left == treeElem) {
                        parent.left = null;
                    }
                    if (parent.right == treeElem) {
                        parent.right = null;
                    }
                    return true;
                }
                else if (treeElem.left == null || treeElem.right == null)
                {
                    if (treeElem.left == null)
                    {
                        if (parent.left == treeElem) {
                            parent.left = treeElem.right;
                        }
                        else {
                            parent.right = treeElem.right;
                        }
                        treeElem.right.parent = parent;
                    }
                    else
                    {
                        if (parent.left == treeElem) {
                            parent.left = treeElem.left;
                        }
                        else {
                            parent.right = treeElem.left;
                        }
                        treeElem.left.parent = parent;
                    }
                    return true;
                }
                else
                {
                    TNode<T> min = Min(treeElem.right);
                    treeElem.data = min.data;
                    if (min.parent.right == min) {
                        min.parent.right = min.right;
                    }
                    else {
                        min.parent.left = min.right;
                    }
                    return true;
                }
            }
        }
    }
}
