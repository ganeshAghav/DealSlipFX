using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;

namespace FP.Common.Configuration
{
    [Serializable, XmlType(AnonymousType = true), DebuggerStepThrough, DesignerCategory("code"), GeneratedCode("xsd", "2.0.50727.42")]
    public class ConfigurationDefinitions
    {
        private string connectionStringField;
        private string connectionStringDailerField;
        private string linkedServerDailer;
        private string linkedServerDM;
        private string dialerPath;
        private string commName;
        private string commPort;
        private string commIdentifier;
        private string menuXmlPath;
        private string classGeneration;
        private string classGenerationExtensions;
        private int panelX;
        private int panelY;
        private int panelwidth;
        private int panelheight;
        private int groupboxx;
        private int groupboxy;
        private int groupboxheight;
        private int groupboxwidth;
        private int controlx;
        private int controly;
        private int labley;
        private int ctrlsizew;
        private int ctrlsizeh;
        private int increasebigctrl;
        private int increasectrl;
        private int increaselablectrl;
        private int listboxh;
        private int increasegrouppos;
        private int datagridwidth;
        private int datagridheight;
        private string imagepath;
        private string encryptionDecryptionAlgorithm;
        private string encryptionDecryptionKey;
        private string txtdriver;
        private string txtextdriver;
        private string xlsdriver;
        private string xlsextdriver;
        private int impsourcecolumnX;
        private int impsourcecolumnY;
        private int impsourcecolwidth;
        private int impsourcecolheight;
        private int destsourcecolX;
        private int destsourcecolY;
        private int destsourcecolwidth;
        private int destsourcecolheight;
        private int impcontrolincrement;
        private int expsourcecolumnX;
        private int expsourcecolumnY;
        private int expsourcecolwidth;
        private int expsourcecolheight;
        private string exportPath;

        private FPCommonSettingsLoggingSettings loggingSettingsField;

        public string ExportPath
        {
            get { return this.exportPath; }
            set { this.exportPath = value; }
        }

        public int ExpSourceColumnX
        {
            get { return this.expsourcecolumnX; }
            set { this.expsourcecolumnX = value; }
        }

        public int ExpSourceColumnY
        {
            get { return this.expsourcecolumnY; }
            set { this.expsourcecolumnY = value; }
        }

        public int ExpSourceColumnWidth
        {
            get { return this.expsourcecolwidth; }
            set { this.expsourcecolwidth = value; }
        }

        public int ExpSourceColumnHeight
        {
            get { return this.expsourcecolheight; }
            set { this.expsourcecolheight = value; }
        }

        public int ImpSourceColumnX
        {
            get { return this.impsourcecolumnX; }
            set { this.impsourcecolumnX = value; }
        }

        public int ImpSourceColumnY
        {
            get { return this.impsourcecolumnY; }
            set { this.impsourcecolumnY = value; }
        }

        public int ImpSourceColumnWidth
        {
            get { return this.impsourcecolwidth; }
            set { this.impsourcecolwidth = value; }
        }

        public int ImpSourceColumnHeight
        {
            get { return this.impsourcecolheight; }
            set { this.impsourcecolheight = value; }
        }

        public int ImpDestColumnX
        {
            get { return this.destsourcecolX; }
            set { this.destsourcecolX = value; }
        }

        public int ImpDestColumnY
        {
            get { return this.destsourcecolY; }
            set { this.destsourcecolY = value; }
        }

        public int ImpDestColumnWidth
        {
            get { return this.destsourcecolwidth; }
            set { this.destsourcecolwidth = value; }
        }

        public int ImpDestColumnHeight
        {
            get { return this.destsourcecolheight; }
            set { this.destsourcecolheight = value; }
        }

        public int ImportMapIncrement
        {
            get { return this.impcontrolincrement; }
            set { this.impcontrolincrement = value; }
        }
        
        public string TextDriver
        {
            get { return this.txtdriver; }
            set { this.txtdriver = value; }
        }

        public string TextDriverExtensions
        {
            get { return this.txtextdriver; }
            set { this.txtextdriver = value; }
        }

        public string ExcelDriver
        {
            get { return this.xlsdriver; }
            set { this.xlsdriver = value; }
        }

        public string ExcelDriverExtensions
        {
            get { return this.xlsextdriver;}
            set { this.xlsextdriver = value; }
        }

        public int DataGridControlWidth 
        {
            get
            {
                return this.datagridwidth;
            }
            set
            {
                this.datagridwidth = value;
            }
        }

        public string ButtonImagePath
        {
            get
            {
                return this.imagepath;
            }
            set
            {
                this.imagepath = value;
            }
        }

        public int DataGridControlHeight
        {
            get
            {
                return this.datagridheight;
            }
            set
            {
                this.datagridheight = value;
            }

        }
        
        public int IncreaseGroupBoxX
        {
            get
            {
                return this.increasegrouppos;
            }
            set
            {
                this.increasegrouppos = value;
            }
        }

        public string ConnectionStringDailer
        {
            get
            {
                return this.connectionStringDailerField;
            }
            set
            {
                this.connectionStringDailerField = value;
            }
        }

        public string ConnectionString
        {
            get
            {
                return this.connectionStringField;
            }
            set
            {
                this.connectionStringField = value;
            }
        }

        public string LinkedServerDailer
        {
            get
            {
                return this.linkedServerDailer;
            }
            set
            {
                this.linkedServerDailer = value;
            }
        }

        public string LinkedServerDM
        {
            get
            {
                return this.linkedServerDM;
            }
            set
            {
                this.linkedServerDM = value;
            }
        }

        public string DialerPath
        {
            get
            {
                return this.dialerPath;
            }
            set
            {
                this.dialerPath = value;
            }
        }

        public string CommName
        {
            get
            {
                return this.commName;
            }
            set
            {
                this.commName = value;
            }
        }

        public string CommPort
        {
            get
            {
                return this.commPort;
            }
            set
            {
                this.commPort = value;
            }
        }

        public string CommIdentifier
        {
            get
            {
                return this.commIdentifier;
            }
            set
            {
                this.commIdentifier = value;
            }
        }

        public string MenuXmlPath
        {
            get
            {
                return this.menuXmlPath;
            }
            set
            {
                this.menuXmlPath = value;
            }
        }

        public string ClassGeneration
        {
            get
            {
                return this.classGeneration;
            }
            set
            {
                this.classGeneration = value;
            }
        }

        public string ClassGenerationExtensions
        {
            get
            {
                return this.classGenerationExtensions;
            }
            set
            {
                this.classGenerationExtensions = value;
            }
        }

        public int PanelX
        {
            get
            {
                return this.panelX;
            }
            set
            {
                this.panelX = value;
            }
        }

        public int PanelY
        {
            get
            {
                return this.panelY;
            }
            set
            {
                this.panelY = value;
            }
        }
        public int PanelWidth
        {
            get
            {
                return this.panelwidth;
            }
            set
            {
                this.panelwidth = value;
            }
        }
        public int PanelHeight
        {
            get
            {
                return this.panelheight;
            }
            set
            {
                this.panelheight = value;
            }
        }
        public int GroupBoxX
        {
            get
            {
                return this.groupboxx;
            }
            set
            {
                this.groupboxx = value;
            }
        }
        public int GroupBoxY
        {
            get
            {
                return this.groupboxy;
            }
            set
            {
                this.groupboxy = value;
            }
        }
        public int GroupBoxWidth
        {
            get
            {
                return this.groupboxwidth;
            }
            set
            {
                this.groupboxwidth = value;
            }
        }
        public int GroupBoxHeight
        {
            get
            {
                return this.groupboxheight;
            }
            set
            {
                this.groupboxheight = value;
            }
        }
        public int ControlLocX
        {
            get
            {
                return this.controlx;
            }
            set
            {
                this.controlx = value;
            }
        }
        public int ControlLocY
        {
            get
            {
                return this.controly;
            }
            set
            {
                this.controly = value;
            }
        }
        public int LableY
        {
            get
            {
                return this.labley;
            }
            set
            {
                this.labley = value;
            }
        }
        public int ControlSizeHeight
        {
            get
            {
                return this.ctrlsizeh;
            }
            set
            {
                this.ctrlsizeh = value;
            }
        }
        public int ControlSizeWidth
        {
            get
            {
                return this.ctrlsizew;
            }
            set
            {
                this.ctrlsizew = value;
            }
        }
        public int LisboxHeight
        {
            get
            {
                return this.listboxh;
            }
            set
            {
                this.listboxh = value;
            }
        }
        public int IncreaseCtrlSize
        {
            get
            {
                return this.increasectrl;
            }
            set
            {
                this.increasectrl = value;
            }
        }
        public int IncBigCtrlSize
        {
            get
            {
                return this.increasebigctrl;
            }
            set
            {
                this.increasebigctrl = value;
            }
        }
        public int IncreaseLableY
        {
            get
            {
                return this.increaselablectrl;
            }
            set
            {
                this.increaselablectrl = value;
            }
        }
        public string EncryptionDecryptionAlgorithm
        {
            get
            {
                return this.encryptionDecryptionAlgorithm;
            }
            set
            {
                this.encryptionDecryptionAlgorithm = value;
            }
        }

        public string EncryptionDecryptionKey
        {
            get
            {
                return this.encryptionDecryptionKey;
            }
            set
            {
                this.encryptionDecryptionKey = value;
            }
        }
     

        public FPCommonSettingsLoggingSettings LoggingSettings
        {
            get
            {
                return this.loggingSettingsField;
            }
            set
            {
                this.loggingSettingsField = value;
            }
        }
    }
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FPCommonSettingsLoggingSettings
    {

        private FPCommonSettingsLoggingSettingsLogDestination[] logDestinationField;

        private bool isSeperateField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LogDestination")]
        
        public FPCommonSettingsLoggingSettingsLogDestination[] LogDestination
        {
            get
            {
                return this.logDestinationField;
            }
            set
            {
                this.logDestinationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IsSeperate
        {
            get
            {
                return this.isSeperateField;
            }
            set
            {
                this.isSeperateField = value;
            }
        }
    }

    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("xsd", "2.0.50727.42")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class FPCommonSettingsLoggingSettingsLogDestination
    {

        private bool activeField;

        private string valueField;

        private string fileNameField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Active
        {
            get
            {
                return this.activeField;
            }
            set
            {
                this.activeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FileName
        {
            get
            {
                return this.fileNameField;
            }
            set
            {
                this.fileNameField = value;
            }
        }
    }

}
