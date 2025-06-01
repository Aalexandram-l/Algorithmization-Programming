/*Ћабораторна€ работа 17
 26.05.2025

алг
на указатели
необходимо использу€ указатели сформировать двоичное (бинарное) дерево, представл€ющее собой список взаимодействующих объектов,
которые характеризуютс€ идентификационным номером и наименование 
значение чтобы сформировать дерево
первый корень
второй и последующие (если больше номера первого - права€ часть, если меньше - лева€ часть )
если по€вл€етс€ объект выдел€етс€ пам€ть и кладетс€ адрес пам€ти в указатель 
 
using System;
using System.Runtime.InteropServices;

public unsafe struct TreeNode
{
    public int Id;
    public string Name;
    public TreeNode* Left;
    public TreeNode* Right;
}

public unsafe class BinaryTree
{
    private TreeNode* _root;

    public void Add(int id, string name)
    {
        TreeNode* newNode = (TreeNode*)Marshal.AllocHGlobal(sizeof(TreeNode));
        newNode->Id = id;
        newNode->Name = name;
        newNode->Left = null;
        newNode->Right = null;

        if (_root == null)
        {
            _root = newNode;
            return;
        }

        TreeNode* current = _root;
        while (true)
        {
            if (id < current->Id)
            {
                if (current->Left == null)
                {
                    current->Left = newNode;
                    break;
                }
                current = current->Left;
            }
            else
            {
                if (current->Right == null)
                {
                    current->Right = newNode;
                    break;
                }
                current = current->Right;
            }
        }
    }

    public void InOrderTraversal()
    {
        InOrderTraversal(_root);
    }

    private void InOrderTraversal(TreeNode* node)
    {
        if (node != null)
        {
            InOrderTraversal(node->Left);
            Console.WriteLine($"ID: {node->Id}, Name: {node->Name}");
            InOrderTraversal(node->Right);
        }
    }

    public void Dispose()
    {
        Dispose(_root);
        _root = null;
    }

    private void Dispose(TreeNode* node)
    {
        if (node != null)
        {
            Dispose(node->Left);
            Dispose(node->Right);
            Marshal.FreeHGlobal((IntPtr)node);
        }
    }
}

public class Program
{
    public static unsafe void Main()
    {
        BinaryTree tree = new BinaryTree();

        try
        {
            tree.Add(5, "Root");
            tree.Add(3, "Left Child");
            tree.Add(7, "Right Child");
            tree.Add(2, "Left-Left Child");
            tree.Add(4, "Left-Right Child");
            tree.Add(6, "Right-Left Child");
            tree.Add(8, "Right-Right Child");

            Console.WriteLine("ќбход по пор€дку:");
            tree.InOrderTraversal();
        }
        finally
        {
            tree.Dispose();
        }
    }
}
*/