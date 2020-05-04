using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Text;

namespace PathSearch
{
    public class InitTestData
    {
		private static List<Node> FoldersGather = new List<Node>();
		private static List<Node> FilesGather = new List<Node>();
		private Node root = new Node();
		public void CreateTestData()
		{
			MyFolders a = new MyFolders();
			string s = "Gather1";//单独新建题库Gather1
			a.SetName(s);
			a.SetType(0);
			a.SetPath(s);
			//Node b = new Node();//测试原因暂时把Node b移出去方便调用，后面控制权限时需要重新构思
			root.folders = a;
			root.SetMyType(false);
			root.parentFolders = root;//令parentFolder等于自己方便后续查找时候的退出条件
			FoldersGather.Add(root);
			for (int i = 2; i <= 5; i++)//测试数据中的其他所有题库都是题库1的子题库
			{
				MyFolders aa = new MyFolders();
				string ss = "Gather";
				char ii = (char)(i + '0');//字符处理方便批量命名
				ss += ii;
				aa.SetName(ss);
				aa.SetType(0);
				aa.SetPath("Gather1/" + ss);//路径为自己的加Gather1
				Node bb = new Node();
				bb.folders = aa;
				bb.SetMyType(false);
				bb.sonNode.Clear();//把sonNode初始化全部清空
				root.sonNode.Add(bb);//把所有其他题库都加进Gather1的sonNode表示子题库
				/*
				 这里引用的就是临时类bb地址，这里如果Gather1能够存取临时类指向的地址就说明指向正确
				 */
				bb.parentFolders = root;//令parentFolder都指向Gather1
				FoldersGather.Add(bb);
			}

			for (int i = 1; i <= 8; i++)//所有题目都是Gather1下的
			{
				MyFiles aa = new MyFiles();
				string ss = "Problem";
				char ii = (char)(i + '0');
				ss += ii;
				aa.SetName(ss);
				aa.SetType(1);
				aa.SetPath("Gather1/"+ss);
				Node bb = new Node();
				bb.files = aa;
				bb.SetMyType(true);
				root.sonNode.Add(bb);
				bb.parentFolders = root;//parentFolder都指向Gather1
				FilesGather.Add(bb);
			}

		}//end of CreateTestData

		public void PrintfTestData()//输出测试数据
		{
			Console.WriteLine("测试数据如下：");
			foreach (Node s in FoldersGather)
			{
				Console.Write("题库名: ");
				Console.Write(s.folders.GetName());
				Console.Write("   题库路径: ");
				Console.Write(s.folders.GetPath());
				Console.WriteLine(" ");
			}

			foreach (Node s in FilesGather)
			{
				Console.Write("题目名: ");
				Console.Write(s.files.GetName());
				Console.Write("   题目路径: ");
				Console.Write(s.files.GetPath());
				Console.WriteLine(" ");
			}
		}//end of PrintfTestData()

		public Node GetRootNode()
		{
			return root;
		}

		public List<Node> ReturnFoldersGather() 
		{
			return FoldersGather;
		}
		public List<Node> ReturnFilesGather()
		{
			return FilesGather;
		}




	}// end of Class_InitTestData


}
