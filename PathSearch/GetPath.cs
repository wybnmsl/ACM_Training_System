using System;
using System.Collections.Generic;
using System.Text;

namespace PathSearch
{
    public class Node//核心，节点类
    {
        public MyFiles files;//题目对象
        public MyFolders folders;//题库对象
        public List<Node> sonNode = new List<Node>();//记录自己直接子节点的Node,是否要把子题目和子题库分开，待考虑
        public Node parentFolders;//存储自己的父亲对象，路径查找由下到上
        //public Node parentFolders=new Node();会直接爆栈，因为在递归申明
        public void SetMyType(bool type)
        {
            this.type = type;
        }
        public bool type;//节点类型
    }
    public class GetPath 
    {
        public static List<Node> FoldersGather = new List<Node>();
        public static List<Node> FilesGather = new List<Node>();
        public void GetFoldersPath(string name)//不用public就无法访问这个函数，注意权限问题
        {
            bool flag = false;
            List<string> pathName = new List<string>();//用List逆序来维护路径，没有找到栈的使用技巧
            foreach (Node s in FoldersGather)
            {
                if (name == s.folders.GetName())
                {
                    flag = true;
                    Node tempNode = s;

                    while (tempNode != tempNode.parentFolders)//如果父节点等于自己则说明到顶
                    {
                        pathName.Add(tempNode.folders.GetName());
                        tempNode = tempNode.parentFolders;
                    }
                    pathName.Add(tempNode.folders.GetName());//把tempNode==tempNode.parentFolders的节点也要加入，是根节点
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("查找失败，没有对应题库");
                return;
            }
            Console.Write("查找成功,路径为: ");
            foreach (string s in pathName)
            {
                Console.Write(s);
            }
            Console.WriteLine(" ");

        }//end of getFoldersPath


        public void GetFilesPath(string name)//不用public就无法访问这个函数，注意权限问题
        {
            bool flag = false;
            List<string> pathName = new List<string>();//用List逆序来维护路径，没有找到栈的使用技巧
            foreach (Node s in FilesGather)
            {
                if (name == s.files.GetName())
                {
                    flag = true;
                    Node tempNode = s;
                    pathName.Add(tempNode.files.GetName());//第一层是题目自身单独拿出来处理
                    tempNode = tempNode.parentFolders;
                    while (tempNode != tempNode.parentFolders)//如果父节点等于自己则说明到顶
                    {
                        pathName.Add(tempNode.folders.GetName());
                        tempNode = tempNode.parentFolders;
                    }
                    pathName.Add(tempNode.folders.GetName());//把tempNode==tempNode.parentFolders的节点也要加入，是根节点
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("查找失败，没有对应题目");
                return;
            }
            Console.Write("查找成功,路径为: ");
            foreach (string s in pathName)
            {
                Console.Write(s);
            }
            Console.WriteLine(" ");

        }//end of GetFilesPath

        public void SetFoldersGather(List<Node> SendFoldersGather)
        {
            FoldersGather = SendFoldersGather;
        }
        public void SetFilesGather(List<Node> SendFilesGather)
        {
            FilesGather = SendFilesGather;
        }


    }//end of class
}
