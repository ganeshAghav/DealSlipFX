using System;
using System.Collections.Generic;
using System.Text;
using FP.Common.Cache.Interfaces;
using System.Web;
using System.Windows;
using FP.Common.Configuration;
using System.Configuration;

namespace FP.Common.Cache
{
    public class CachingHelper
    {
        /// <summary>
        /// Returns FileCacheProvider or  MemoryCacheProvider object as per settings from config file.
        /// </summary>
        /// <returns></returns>
        ///
        public static ICacheProvider GetCacheProvoder()//System.Web.HttpContext oContext
        {
            FPCommon _oGspCommon = new FPCommon();
            //_oGspCommon = (CommonSettings)System.Configuration.ConfigurationManager.GetSection("GSPCommon");
            //string cacheProviderName = _oGspCommon.CommonSettings.TypeOfCaching.ToString();

            ICacheProvider cacheProvider = null;

            //try
            //{
            //    if (cacheProviderName == "FileCacheProvider")
            //    {
            //        cacheProvider = FileCacheProvider.GetCacheProvider();
            //    }
            //    else if (cacheProviderName == "MemoryCacheProvider")
            //    {
            //        cacheProvider = MemoryCacheProvider.GetCacheProvider();//oContext
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw ex;
            //}

            return cacheProvider;
        }
    }
}
