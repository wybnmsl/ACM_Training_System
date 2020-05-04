using System;
using System.Collections.Generic;
using System.Text;

namespace PathSearch
{
    class GetSon : SetNew//继承List
    {
        private Node outNode;
        public Node GiveNode()
        {
            return outNode;
        }

        public void GetFoldersSon(string name)//不用public就无法访问这个函数，注意权限问题
        {
            bool flag = false;
            Node tempNode = new Node();
            List<string> proList = new List<string>();//题目List
            List<string> gatList = new List<string>();//题库List
            proList.Clear();
            gatList.Clear();
            foreach (Node s in FoldersGather)
            {
                if (name == s.folders.GetName())
                {                   
                    flag = true;
                    tempNode = s;
                    outNode = s;//把找到的s通过GiveNode返回出去
                    break;
                }
            }
            if (!flag)
            {
                Console.WriteLine("打开失败，没有对应题库");
                return;
            }
            foreach (Node s in tempNode.sonNode)
            {
                if (s.type == true)//为题目
                {
                    proList.Add(s.files.GetName());
                  
                }
                else//为题库
                {
                    gatList.Add(s.folders.GetName());
                }
            }
            if (proList.Count == 0)
            {
                Console.WriteLine("打开成功，该题库下没有子题目");
            }
            else
            {
                Console.Write("打开成功,子题目如下: ");
                foreach (string s in proList)
                {
                    Console.Write(s);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
            if (gatList.Count == 0)
            {
                Console.WriteLine("打开成功，该题库下没有子题库");
            }
            else
            {
                Console.Write("打开成功,子题库如下: ");
                foreach (string s in gatList)
                {
                    Console.Write(s);
                    Console.Write(" ");
                }
                Console.WriteLine(" ");
            }
            
        }//end of GetFoldersSon
    }//end of class
}
