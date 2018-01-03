using System;
using System.Collections.Generic;
using System.Text;
using FP.Common.Cache.Interfaces;
using System.Web;
using System.Windows;
using System.Windows.Forms;
using System.Collections;


namespace FP.Common.Cache
{
    public class MemoryCacheProvider:ICacheProvider
    {
        private static MemoryCacheProvider singleton = null;
        private System.Web.HttpContext _oContext;
        

        private MemoryCacheProvider()//System.Web.HttpContext oContext
        {
            _oContext = HttpContext.Current;
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ICacheProvider GetCacheProvider()//System.Web.HttpContext oContext
        {
            if (singleton == null)
            {
                singleton = new MemoryCacheProvider();//oContext
            }
            return (ICacheProvider)singleton;
        }
        public bool Contains(string ObjectName)
        {
            if (_oContext.Cache.Get(ObjectName) == null)
            {
                return false;
            }
            return true;
        }

  #region ICacheProvider Members
        /// <summary>
        /// Delete data from memory cache.
        /// </summary>
        /// <param name="ObjectName"></param>
        public void DeleteCacheData(string ObjectName)
        {
            _oContext.Cache.Remove(ObjectName);
        }
        /// <summary>
        /// 
        /// </summary>
        public void DeleteCacheData()
        {

        }
        /// <summary>
        /// Read data from memory cache.
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
        public object ReadCacheData(string ObjectName)
        {
            object oCacheData = _oContext.Cache[ObjectName];
            return oCacheData;
        }
        /// <summary>
        /// Write data into Memory cache.
        /// </summary>
        /// <param name="Data"></param>
        /// <param name="ObjectName"></param>
        /// <param name="Duration"></param>
        public void WriteCacheData(object Data, string ObjectName, int Duration)
        {
            _oContext.Cache.Add(ObjectName, Data, null, System.Web.Caching.Cache.NoAbsoluteExpiration, System.Web.Caching.Cache.NoSlidingExpiration, System.Web.Caching.CacheItemPriority.High, null);
            
        }
        /// <summary>
        /// Check if data exist in cache
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <returns></returns>
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
