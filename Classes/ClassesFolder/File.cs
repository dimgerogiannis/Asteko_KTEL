using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesFolder
{
    public class File
    {
        private string _fileName;
        private byte[] _fileContent;

        public string FileName => _fileName;
        public byte[] FileContent => _fileContent;

        public File (string fileName, byte[] fileContent)
        {
            _fileName = fileName;
            _fileContent = fileContent;
        }
    }
}
