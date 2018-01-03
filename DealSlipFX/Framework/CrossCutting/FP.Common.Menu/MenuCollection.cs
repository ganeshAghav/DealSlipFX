using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using System.Xml;
using FP.DAL.SQL;
using System.Data;

namespace FP.Common.Menu
{
    public class MenuCollection:CollectionBase
    {
        ArrayList _oMenuData;

        /// <summary>
        /// sUserID & sLangname are UserId & LanguageName of the LoggedInUser 
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="sLangName"></param>
        public MenuCollection(string sUserID, string sLangName)
        {
            Load(sUserID, sLangName); 
        }

        /// <summary>
        /// Load method is used to get data of the logged in user, according to the privilages for
        /// displaying the Menu
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="sLangName"></param>
        public void Load(string sUserID, string sLangName)
        {

            DataSet odsGsp = new DataSet();
            DBUtility oDbUtil = new DBUtility();
            oDbUtil.AddParameters("@UserId", DBUtilDBType.Varchar, DBUtilDirection.In, 50, sUserID);
            oDbUtil.AddParameters("@LanguageName", DBUtilDBType.Varchar, DBUtilDirection.In, 50, sLangName);
            odsGsp = oDbUtil.Execute_StoreProc_DataSet("PRC_COM_GETMENUDATA");
            for (int i = 0; i < odsGsp.Tables[0].Rows.Count; i++)
            {
                Add(Convert.ToInt32(odsGsp.Tables[0].Rows[i][0]), odsGsp.Tables[0].Rows[i][1].ToString(), Convert.ToInt32(odsGsp.Tables[0].Rows[i][2]), odsGsp.Tables[0].Rows[i][3].ToString(), odsGsp.Tables[0].Rows[i][4].ToString(), odsGsp.Tables[0].Rows[i][5].ToString(), odsGsp.Tables[0].Rows[i][6].ToString(), Convert.ToInt32(odsGsp.Tables[0].Rows[i][7]), Convert.ToInt32(odsGsp.Tables[0].Rows[i][8]), odsGsp.Tables[0].Rows[i][9].ToString(), Convert.ToInt32(odsGsp.Tables[0].Rows[i][10]));
            }
        }

        /// <summary>
        /// BuildXmlDocument is used to build the XMLDocument according to the privileges of the logged in user.
        /// </summary>
        /// <returns></returns>
        public XmlDocument BuildXmlDocument()
        {
            string sPrevMenuItem=string.Empty;
            XmlDocument _oMenuXmlDoc = new XmlDocument();
            XmlNode oXnNode;
            XmlElement oXeMenu;
            XmlElement oXeMenuItemMain = null, oXeTextMain = null, oXeSubMenu = null, oXeMenuItemSub = null, oXeTextSub = null, oXeurl = null, oXeMouseOverMain = null, oXeWidth = null, oXeVertAlign = null, oXeLeftImageAlign = null, oXeMouseOverSub = null;

            oXnNode = _oMenuXmlDoc.CreateNode(XmlNodeType.XmlDeclaration, "", "");
            _oMenuXmlDoc.AppendChild(oXnNode);
            oXeMenu = _oMenuXmlDoc.CreateElement("", "menu", "");

            foreach (MenuData oMenuData in this)
            {
                if (sPrevMenuItem != oMenuData.MenuLocalizedName)
                {
                    oXeMenuItemMain = _oMenuXmlDoc.CreateElement("", "menuItem", "");
                    oXeTextMain = _oMenuXmlDoc.CreateElement("", "text", "");
                    oXeSubMenu = _oMenuXmlDoc.CreateElement("", "subMenu", "");
                    oXeMouseOverMain = _oMenuXmlDoc.CreateElement("", "mouseovercssclass", "");
                    oXeWidth = _oMenuXmlDoc.CreateElement("", "width", "");
                    oXeVertAlign = _oMenuXmlDoc.CreateElement("", "verticalalign", "");
                    oXeLeftImageAlign = _oMenuXmlDoc.CreateElement("", "leftimagealign", "");
                    oXeTextMain.InnerText = "<img src='images/ArrowWhiteRight.gif'>" + oMenuData.MenuLocalizedName;
                    oXeMouseOverMain.InnerText = "TopItemOver";
                    oXeWidth.InnerText = oMenuData.MenuWidth.ToString();
                    oXeVertAlign.InnerText = "middle";
                    oXeLeftImageAlign.InnerText = "middle";
                }
                oXeMenuItemSub = _oMenuXmlDoc.CreateElement("", "menuItem", "");
                oXeTextSub = _oMenuXmlDoc.CreateElement("", "text", "");
                oXeurl = _oMenuXmlDoc.CreateElement("", "url", "");
                oXeMouseOverSub = _oMenuXmlDoc.CreateElement("", "mouseovercssclass", "");
                oXeTextSub.InnerText = "&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;" + oMenuData.SubMenuLocalizedName;
                oXeurl.InnerText = oMenuData.Url;
                oXeMouseOverSub.InnerText = "TopItemSubOver";
                oXeMenuItemSub.AppendChild(oXeTextSub);
                oXeMenuItemSub.AppendChild(oXeurl);
                oXeMenuItemSub.AppendChild(oXeMouseOverSub);
                oXeMenuItemMain.AppendChild(oXeTextMain);
                oXeMenuItemMain.AppendChild(oXeSubMenu);
                oXeSubMenu.AppendChild(oXeMenuItemSub);
                oXeMenuItemMain.AppendChild(oXeMouseOverMain);
                oXeMenuItemMain.AppendChild(oXeWidth);
                oXeMenuItemMain.AppendChild(oXeVertAlign);
                oXeMenuItemMain.AppendChild(oXeLeftImageAlign);
                oXeMenu.AppendChild(oXeMenuItemMain);
                _oMenuXmlDoc.AppendChild(oXeMenu);
                sPrevMenuItem = oMenuData.MenuLocalizedName;
            }
            return _oMenuXmlDoc;
        }

        /// <summary>
        /// Add method is used to Add the data to Collection List
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
        public void Add(int iSubMenuId, string sSubMenuName, int iMenuId, string sMenuName,string sPrivilageName, string sMenuLocalizedName, string sSubMenuLocalizedName, int iMenuDisplayOrder, int iSubMenuDisplayOrder, string sUrl,int iMenuWidth)
        {
            base.List.Add(new MenuData(iSubMenuId, sSubMenuName, iMenuId, sMenuName, sPrivilageName, sSubMenuLocalizedName,sMenuLocalizedName, iMenuDisplayOrder, iSubMenuDisplayOrder, sUrl,iMenuWidth));
        }
    }
}
