using System;
using System.Collections.Generic;
using System.Text;

namespace MDSolution
{
    class NodeCanBoNongVu
    {
        private string mCBNVID = "-1";
        private string mCBNVName = "";
        private CBNVType mCBNVType = CBNVType.Root;       
        private bool mHasLoadChildren = false;
        public bool HasLoadChildren
        {
            get { return mHasLoadChildren; }
            set { mHasLoadChildren = value; }
        }
        public NodeCanBoNongVu()
        { }
        public NodeCanBoNongVu(string ID, string Name, CBNVType Type)
        {
           this.mCBNVID  = ID;
           this.mCBNVName = Name;
           this.mCBNVType = Type;
        }
        public string CBNVID
        {
            get { return mCBNVID; }
            set { mCBNVID = value; }
        }
        public string CBNVName
        {
            get { return mCBNVName; }
            set { mCBNVName = value; }
        }
        public CBNVType CBNVType
        {
            get { return mCBNVType; }
            set { mCBNVType = value; }
        }
    }
    [Flags]
    public enum CBNVType : int
    {
        Root = 0,
        CBNV = 1,
        ThonID = 2,
        HongDongID=3
    }
}
