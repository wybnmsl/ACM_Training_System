using System;
using System.Net;

namespace PathSearch
{
    public class MainClass
    {
        static void Main(string[] args)
        {
            InitTestData TestData = new InitTestData();
            TestData.CreateTestData();//初始化测试数据
            TestData.PrintfTestData();//输出预置的测试数据
            PathSearch operation = new PathSearch();//得到根目录Gather1的子目录 
            operation.SetFoldersGather(TestData.ReturnFoldersGather());//把初始数据传入operation对象中
            operation.SetFilesGather(TestData.ReturnFilesGather());//把初始数据传入operation对象中
            Node nowNode = new Node();//Node类的临时对象nowNode，表示当前的操作到了哪一层
            nowNode = TestData.GetRootNode();//让当前节点为根节点，方便后续操作      
            Console.WriteLine("-------------------------");
            Console.WriteLine("当前正在根题库Gather1下,请选择相关操作.");                    
            int choose = Convert.ToInt32(Console.ReadLine());//读入操作      
            while (true)
            {
                if (choose == 0)//结束程序
                {
                    Console.WriteLine("程序已结束");
                    Console.WriteLine("-------------------------");
                    break;
                }
                else if (choose == 1)//删除当前目录,慎重使用
                {
                    Console.WriteLine("删除当前目录成功");
                    nowNode.sonNode.Clear();
                    Console.WriteLine("-------------------------");
                }
                else if (choose == 2)//查询子目录
                {
                    Console.WriteLine("正在查询子目录");
                    operation.GetFoldersSon(nowNode.folders.GetName());
                    Console.WriteLine("-------------------------");
                }
                else if (choose == 3)//打开子目录
                {
                    Console.WriteLine("请选择需要打开的子目录:");
                    string name = Console.ReadLine();
                    operation.GetFoldersSon(name);
                    nowNode = operation.GiveNode();//把自己替换为自己的子目录下的文件
                    Console.WriteLine("-------------------------");
                }
                else if (choose == 4)//查询当前路径
                {
                    Console.WriteLine("当前文件所在目录:");                   
                    operation.GetFoldersPath(nowNode.folders.GetName());
                    Console.WriteLine("-------------------------");
                }               
                else if (choose == 5)//返回上一级
                {
                    Console.Write("返回上一级成功,当前所在目录: ");
                    nowNode = nowNode.parentFolders;
                    Console.Write(nowNode.folders.GetName());
                    Console.WriteLine(" ");
                    Console.WriteLine("-------------------------");
                }
                else if (choose == 6)//新增题库
                {
                    Console.WriteLine("输入新增题库名: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("输入新增题库路径: ");
                    string path = Console.ReadLine();
                    operation.SetNewFolders(name,path);
                    Console.WriteLine("-------------------------");
                }
                else if (choose == 7)//新增题目
                {
                    Console.WriteLine("输入新增题目名: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("输入新增题目路径: ");
                    string path = Console.ReadLine();
                    operation.SetNewFolders(name, path);
                    Console.WriteLine("-------------------------");
                }
                choose = Convert.ToInt32(Console.ReadLine());
            }//end of while
           
        }//end of void Main
    }//end of MainClass
}//end of namespace 
