using System;
using System.Collections.Generic;
using System.Text;

namespace FP.Common.Cache.Interfaces
{
    public interface ICacheProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Duration"></param>
        void WriteCacheData(object Data, string ObjectName, int Duration);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Duration"></param>
        /// <param name="Expiration"></param>
        void WriteCacheData(object Data, string ObjectName, int Duration, Enum Expiration);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        bool Contains(string key);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        object ReadCacheData(string ObjectName);
        /// <summary>
        /// 
        /// </summary>
        void DeleteCacheData();
        /// <summary>
        /// 
        /// </summary>
        /// <param name="ObjectName"></param>
        void DeleteCacheData(string ObjectName);
    }
}
