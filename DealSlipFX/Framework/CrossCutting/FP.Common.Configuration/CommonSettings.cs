//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.42
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.Configuration;

// 
// This source code was auto-generated by xsd, Version=2.0.50727.42.
//

namespace FP.Common.Configuration
{
    
    public class FPCommon
    {
        public  FPCommon()
        {
        }
       
        private ConfigurationDefinitions commonSettingsField;
        private string fileField;

        public ConfigurationDefinitions CommonSettings
        {
            get
            {
                return this.commonSettingsField;
            }
            set
            {
                this.commonSettingsField = value;
            }
        }

        [XmlAttribute]
        public string file
        {
            get
            {
                return this.fileField;
            }
            set
            {
                this.fileField = value;
            }
        }
       
    }
    
}


