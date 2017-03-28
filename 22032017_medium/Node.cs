using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _22032017_medium
{
    class Node<T>
    {
        private T data;
        private List<Node<T>> children;
        private Node<T> parent;

        public Node(T data, int planned_children = 2, Node<T> parent = null)
        {
            this.data = data;
            this.parent = parent;
            children = new List<Node<T>>(planned_children);
        }

        public void setParent(Node<T> parent)
        {
            if (parent == null) throw new NullReferenceException("Null given, node expected");
            this.parent = parent;
        }

        public Node<T> getParent()
        {
            return parent;
        }

        public void addChild(Node<T> child)
        {
            if (child == null) throw new NullReferenceException("Null given, node expected");
            children.Add(child);
        }

        public List<Node<T>> getChildren()
        {
            return children;
        }

        public T getData()
        {
            return data;
        }

        public bool isRoot()
        {
            if (parent == null) return true;
            return false;
        }

        public bool isLeaf()
        {
            if (children.Count() == 0) return true;
            return false;
        }
    }
}
