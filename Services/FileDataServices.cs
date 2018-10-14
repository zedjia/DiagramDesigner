using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using DiagramDesigner.Helper;
using Newtonsoft.Json;

namespace DiagramDesigner.Services
{
    public static class FileDataServices
    {
        public const string DATASOURCEFILENAME = "dbconfig.txt";
        public const string INTERFACEFILENAME = "iterfaceconfig.txt";

        public static T GetDataModelFromFile<T>(string type = DATASOURCEFILENAME) where T : new()
        {
            if (!FileHelper.IsExistFile(System.AppDomain.CurrentDomain.BaseDirectory + type))
                return default(T);

            string jsonData =
                FileHelper.ReadAllTxtContent(System.AppDomain.CurrentDomain.BaseDirectory + type, Encoding.UTF8);

            T model = JsonConvert.DeserializeObject<T>(jsonData);
            return model;
        }



        /// <summary>
        /// 根据类型把对象存入不同的文件中.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public static bool SaveDataModelToFile<T>(T model,string type=DATASOURCEFILENAME) where T : new()
        {
            string jsonData = JsonConvert.SerializeObject(model);
            try
            {
                FileHelper.SaveFile(System.AppDomain.CurrentDomain.BaseDirectory + type, jsonData);
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                return false;
            }
        }
    }
}
