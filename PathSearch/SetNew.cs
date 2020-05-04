using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace PathSearch
{
    public class SetNew : GetPath//继承测试数据和getpath功能
    {
        public void SetNewFolders(string name, string path)//不用public就无法访问这个函数，注意权限问题
        {
           
            foreach (Node s in FoldersGather)
            {
                if (name == s.folders.GetName())
                {
                    Console.WriteLine("error：题库已经存在请重新确认");
                }                            
            }
            MyFolders newFolders=new MyFolders();//新建类对象，记录name,path
            newFolders.SetName(name);
            newFolders.SetPath(path);
            newFolders.SetType(0);

            Node newNode=new Node();//新建节点记录类型和当前节点的信息
            newNode.folders = newFolders;
            newNode.type = false;
            FoldersGather.Add(newNode);

            string parentName;//父亲节点的name
           for (int i = path.Length-1; i >= 0; i--)
            {
                if (path[i] == '/')
                {             
                    path = path.Substring(i+1, path.Length-i-1); //使用截取有风险，后续需要更改方法                   
                }
            }
            //目前只能处理单层路径 多层路径的截取方法暂时未处理
            parentName = path;//得到自己父亲节点的name 

            foreach (Node s in FoldersGather)
            {
                if (parentName == s.folders.GetName())
                {
                    newNode.parentFolders = s;//指向自己的父亲节点
                    s.sonNode.Add(newNode);//父亲节点的sonNode结构体加入newNode,表示自己的直接儿子
                    //这里是不是可以更改存疑？？？？？？？？？？？
                }                             
            }
            //怎么取得最后一个List？？？？？？迭代器？？？
            Console.Write("新建题库 ");//这里只是展示，并不能表示赋值成功
            Console.Write(newFolders.GetName());
            Console.Write(" 查找新建路径：");
            GetFoldersPath(newFolders.GetName());
        }//end of setNewFolders


        public void SetNewFiles(string name, string path)//不用public就无法访问这个函数，注意权限问题
        {
            foreach (Node s in FilesGather)
            {
                if (name == s.files.GetName())
                {
                    Console.WriteLine("error：题目已经存在请重新确认");
                }
            }
            MyFiles newFiles = new MyFiles();//新建类对象，记录name,path
            newFiles.SetName(name);
            newFiles.SetPath(path);
            newFiles.SetType(1);

            Node newNode = new Node();//新建节点记录类型和当前节点的信息
            newNode.files = newFiles;
            newNode.type = true;
            FilesGather.Add(newNode);

            string parentName;//父亲节点的name
            for (int i = path.Length - 1; i >= 0; i--)
            {
                if (path[i] == '/')
                {
                    path = path.Substring(i + 1, path.Length - i - 1); //使用截取有风险，后续需要更改方法                   
                }
            }
            parentName = path;//得到自己父亲节点的name 

            foreach (Node s in FoldersGather)//查找题库中的父亲题库
            {
                if (parentName == s.folders.GetName())
                {
                    newNode.parentFolders = s;//指向自己的父亲节点
                    s.sonNode.Add(newNode);//父亲节点的sonNode结构体加入newNode,表示自己的直接儿子
                    //因为是引用，这里是不是可以更改存疑？？？？？？？？？？？
                }
            }
            //怎么取得最后一个List？？？？？？迭代器？？？
            Console.Write("新建题目 ");//这里只是展示，并不能表示赋值成功
            Console.Write(newFiles.GetName());
            Console.Write(" 查找新建路径：");
            GetFilesPath(newFiles.GetName());
        }//end of setNewFiles


     
    }//end of class
    
}
