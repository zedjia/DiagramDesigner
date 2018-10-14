using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiagramDesigner.Services
{
    public static class FileDataServices
    {
        private const string DATAFILENAME = "db.txt";

        public static T GetDataModelFromFile<T>() where T : new()
        {
            
            return new T();
        }


    }
}
