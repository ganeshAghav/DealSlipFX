using System;
using System.Collections.Generic;
using System.Text;

namespace FP.Common.Menu
{
    class MenuData
    {
        private int _iSubMenuId;
        private string _sSubMenuName;
        private int _iMenuId;
        private string _sMenuName;
        private string _sMenuLocalizedName;
        private string _sSubMenuLocalizedName;
        private int _iMenuDisplayOrder;
        private int _iSubMenuDisplayOrder;
        private string _sUrl;
        private string _sPrivilageName;
        private int _iMenuWidth;

        /// <summary>
        /// 
        /// </summary>
        public int SubMenuId
        {
            get
            {
                return _iSubMenuId;
            }
            set
            {
                _iSubMenuId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubMenuName
        {
            get
            {
                return _sSubMenuName;
            }
            set
            {
                _sSubMenuName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MenuId
        {
            get
            {
                return _iMenuId;
            }
            set
            {
                _iMenuId = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MenuName
        {
            get
            {
                return _sMenuName;
            }
            set
            {
                _sMenuName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string MenuLocalizedName
        {
            get
            {
                return _sMenuLocalizedName;
            }
            set
            {
                _sMenuLocalizedName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string SubMenuLocalizedName
        {
            get
            {
                return _sSubMenuLocalizedName;
            }
            set
            {
                _sSubMenuLocalizedName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MenuDisplayOrder
        {
            get
            {
                return _iMenuDisplayOrder;
            }
            set
            {
                _iMenuDisplayOrder = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int SubMenuDisplayOrder
        {
            get
            {
                return _iSubMenuDisplayOrder;
            }
            set
            {
                _iSubMenuDisplayOrder = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string Url
        {
            get
            {
                return _sUrl;
            }
            set
            {
                _sUrl = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public string PrivilageName
        {
            get
            {
                return _sPrivilageName;
            }
            set
            {
                _sPrivilageName = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public int MenuWidth
        {
            get
            {
                return _iMenuWidth;
            }
            set
            {
                _iMenuWidth = value;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="iSubMenuId"></param>
        /// <param name="sSubMenuName"></param>
        /// <param name="iMenuId"></param>
        /// <param name="sMenuName"></param>
        /// <param name="sPrivilageName"></param>
        /// <param name="sMenuLocalizedName"></param>
        /// <param name="sSubMenuLocalizedName"></param>
        /// <param name="iMenuDisplayOrder"></param>
        /// <param name="iSubMenuDisplayOrder"></param>
        /// <param name="sUrl"></param>
        /// <param name="iMenuWidth"></param>
        public MenuData(int iSubMenuId, string sSubMenuName, int iMenuId, string sMenuName, string sPrivilageName, string sMenuLocalizedName, string sSubMenuLocalizedName, int iMenuDisplayOrder, int iSubMenuDisplayOrder, string sUrl,int iMenuWidth)
        {
            _iSubMenuId= iSubMenuId;
            _sSubMenuName= sSubMenuName;
            _iMenuId= iMenuId;
            _sMenuName= sMenuName;
            _sPrivilageName = sPrivilageName;
            _sMenuLocalizedName= sMenuLocalizedName;
            _sSubMenuLocalizedName= sSubMenuLocalizedName;
            _iMenuDisplayOrder= iMenuDisplayOrder;
            _iSubMenuDisplayOrder= iSubMenuDisplayOrder;
            _sUrl = sUrl;
            _iMenuWidth = iMenuWidth;
        }
    }
}
