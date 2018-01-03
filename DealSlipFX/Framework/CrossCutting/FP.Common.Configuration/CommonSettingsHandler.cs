using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Xml;
using System.Xml.Serialization;
//using FP.Common.BizTalk.XmlHelper;

namespace FP.Common.Configuration
{
    public class CommonSettingsHandler : IConfigurationSectionHandler
    {
        Object IConfigurationSectionHandler.Create(Object parent, Object configContext, System.Xml.XmlNode section)
        {
            FPCommon common = new FPCommon();
            common = (FPCommon)Serialization.ObjectFromDocument(section.OwnerDocument, typeof(FPCommon));
            if (common.file.ToString() != string.Empty)
            {
                XmlDocument document = new XmlDocument();
                document.Load(common.file.ToString());
                //FPCommon common2 = new FPCommon();
                return (FPCommon)Serialization.ObjectFromDocument(document, typeof(FPCommon));
            }
            return common;
        }
    }
}
