using System;
using System.Collections.Generic;
using System.Text;

namespace PathSearch
{
    public class MyFolders
    {
        public void SetName(string name)
        {
            this.name = name;
        }
        public void SetPath(string filePath)
        {
            this.filePath = filePath;
        }
        public void SetType(int type)
        {
            this.type = type;
        }
        public string GetName()
        {
            return this.name;
        }
        public string GetPath()
        {
            return this.filePath;
        }
        public int GetTheType()
        {
            return this.type;
        }

        private int type;
        private string name;
        private string filePath;
    }//end of class
}
