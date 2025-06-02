/*������������ ������ 17
 26.05.2025

���
�� ���������
���������� ��������� ��������� ������������ �������� (��������) ������, �������������� ����� ������ ����������������� ��������,
������� ��������������� ����������������� ������� � ������������ 
�������� ����� ������������ ������
������ ������
������ � ����������� (���� ������ ������ ������� - ������ �����, ���� ������ - ����� ����� )
���� ���������� ������ ���������� ������ � �������� ����� ������ � ��������� 
 
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
            tree.Add(5, "��������");
            tree.Add(3, "�������");
            tree.Add(7, "�����");
            tree.Add(2, "���������");
            tree.Add(4, "������");
            tree.Add(6, "������");
            tree.Add(8, "�����");

            Console.WriteLine("����� �� �������:");
            tree.InOrderTraversal();
        }
        finally
        {
            tree.Dispose();
        }
    }
}
*/