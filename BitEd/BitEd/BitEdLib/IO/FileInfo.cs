using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BitEdLib.IO
{
    public class FileInfo
    {
        public Nullable<DateTime> CreationTime { get; set; }
        public string Extension { get; set; }
        public Nullable<long> Size { get; set ; }
        public FileInfo()
        {
            CreationTime = null;
            Extension = null;
            Size = null;
        }
        public FileInfo(DateTime creationTime, string extension, long size)
        {
            CreationTime = creationTime;
            Extension = extension;
            Size = size;
        }
    }
}
