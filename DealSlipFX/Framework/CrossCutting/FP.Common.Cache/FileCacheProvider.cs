using System;
using System.Collections.Generic;
using System.Text;
using FP.Common.Cache.Interfaces;
using System.IO;
using System.Xml.Serialization;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using FP.Common.Configuration;
using System.Windows;



namespace FP.Common.Cache
{
    public class FileCacheProvider:ICacheProvider
    {
        //private string rootDir = @"C:\Temp\Cache\"; //Configurable
        private string rootDir;
        private FPCommon _oCommonSettings = new FPCommon();
        /// <summary>
        /// 
        /// </summary>
        private FileCacheProvider()
        {
            //_oCommonSettings = (CommonSettings)System.Configuration.ConfigurationManager.GetSection("GSPCommon");
            //this.rootDir = _oCommonSettings.CommonSettings.PathOfTheFile.ToString();
            //if (!this.rootDir.EndsWith(@"\"))
            //{
            //    this.rootDir += @"\";
            //}
        }

        /// <summary>
        /// Static method to get the singleton instance of the CacheProvider
        /// </summary>
        /// <returns>Object implemeting ICacheProvider</returns>
        public static ICacheProvider GetCacheProvider()
        {
            if (singleton == null)
            {
                singleton = new FileCacheProvider();
                                
            }
            return (ICacheProvider)singleton;
        }

        private static FileCacheProvider singleton = null;


        #region ICacheProvider Members

        /// <summary>
        /// Delete data from file cache
        /// </summary>
        /// <param name="ObjectName"></param>
        /// 
        
        public void DeleteCacheData(string ObjectName)
        {
 
            string path = rootDir + ObjectName;
               if (File.Exists(path))
            {
                File.Delete(path);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public void DeleteCacheData()
        {

        }
        /// <summary>
        /// Read data from file cache.
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
       
        public object ReadCacheData(string ObjectName)
        {
           
            StreamReader reader;
            string type;
            System.Type objectType;
            object returnObject;
            try
            {
                reader = new StreamReader(rootDir + ObjectName);
                type = reader.ReadLine();
                objectType = Type.GetType(type);
                                                  
                XmlSerializer xmlSerializer = new XmlSerializer(objectType);
                returnObject = xmlSerializer.Deserialize(reader);
                reader.Close();
            }
            catch
            {
                returnObject = null;
            }
            return returnObject;
        }

        /// <summary>
        /// Write data into file cache.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Duration"></param>
        public void WriteCacheData(object Data, string ObjectName, int Duration)
        {
            if (Data == null)
            {
                DeleteCacheData(ObjectName);
            }
            else
            {
                                            
                StreamWriter streamWriter = new StreamWriter(rootDir + ObjectName);
                XmlSerializer xmlSerializer = new XmlSerializer(Data.GetType());
                streamWriter.WriteLine(Data.GetType().AssemblyQualifiedName);
                xmlSerializer.Serialize(streamWriter, Data);
                streamWriter.Close();
            }
        }
        
        /// <summary> 
        /// Check if data exist in cache
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        /// 
        public bool Contains(string ObjectName)
        {

            if (File.Exists(rootDir + ObjectName))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Duration"></param>
        /// <param name="Expiration"></param>
        public void WriteCacheData(object Data, string ObjectName, int Duration, Enum Expiration)
        {
            WriteCacheData(Data, ObjectName, Duration);
        }

        #endregion
    }
}
