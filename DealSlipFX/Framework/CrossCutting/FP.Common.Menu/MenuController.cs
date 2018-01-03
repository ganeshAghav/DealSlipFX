using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace FP.Common.Menu
{
    public class MenuController
    {
        MenuCollection _oMenuCollection;

        /// <summary>
        /// /// sUserID & sLangname are UserId & LanguageName of the LoggedInUser 
        /// </summary>
        /// <param name="sUserID"></param>
        /// <param name="sLangName"></param>
        public MenuController(string sUserID, string sLangName)
        {
            _oMenuCollection = new MenuCollection(sUserID,sLangName);
        }

        /// <summary>
        /// BuildXmlDocument is used to build the XMLDocument according to the privileges of the logged in user.
        /// </summary>
        /// <returns></returns>
        public XmlDocument BuildXmlDocument()
        {
            return _oMenuCollection.BuildXmlDocument();
        }
    }
}
