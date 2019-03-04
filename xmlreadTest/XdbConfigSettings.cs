using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;

namespace xmlreadTest
{
    class XdbPropertyToBimsSettring
    {
        public List<XdbToBimsPropertyNode> xdbToBimsPropertyNodes { get; set; }

        private static readonly string xdbConFigfileName = "XdbPropertyToBimsProperty.xml";
        private static readonly string fatherPath = "Configuration";

        static XdbPropertyToBimsSettring instance = null;

        private XdbPropertyToBimsSettring()
        {
        }

        public static XdbPropertyToBimsSettring GetInstance()
        {
            
            if (instance == null)
            {
                instance = new XdbPropertyToBimsSettring();
                instance.xdbToBimsPropertyNodes = new List<XdbToBimsPropertyNode>();

                var folder = Path.Combine(Environment.CurrentDirectory, fatherPath);
                var files = Directory.EnumerateFiles(folder, xdbConFigfileName, SearchOption.TopDirectoryOnly);
                var fullfile = files.SingleOrDefault();

                XmlDocument xmldoc = new XmlDocument();
                xmldoc.Load(fullfile);
                XmlNodeList topM = xmldoc.SelectNodes("//InfoNode");

                foreach (XmlElement element in topM)
                {
                    XdbToBimsPropertyNode xdbConfig = new XdbToBimsPropertyNode();
                    xdbConfig.xdbType = Convert.ToInt32(element.GetAttribute("xdbType"));
                    xdbConfig.xdbVersion = element.GetAttribute("xdbVersion");
                    xdbConfig.MethodClass = element.GetElementsByTagName("methodeClass")[0].InnerText;
                    xdbConfig.namespaceName = element.GetElementsByTagName("namespace")[0].InnerText;

                    var childs = element.SelectNodes("//methodNode");
                    foreach (XmlElement node in childs)
                    {
                        string table = node.GetAttribute("table");
                        clasMapmethod clasMapmethod = new clasMapmethod();
                        clasMapmethod.className = node.GetElementsByTagName("className")[0].InnerText;
                        clasMapmethod.method = node.GetElementsByTagName("method")[0].InnerText;
                        xdbConfig.clasMapmethods.Add(table, clasMapmethod);
                    }

                    instance.xdbToBimsPropertyNodes.Add(xdbConfig);
                }
            }
            return instance;
        }
    }
    class XdbToBimsPropertyNode
    {
        public string MethodClass { get; set; }
        public int xdbType { get; set; }
        public string xdbVersion { get; set; }

        public string namespaceName { get; set; }

        public IDictionary<string,clasMapmethod> clasMapmethods { get; set; }
        public XdbToBimsPropertyNode()
        {
            clasMapmethods = new Dictionary<string, clasMapmethod>();
        }

    }
    class clasMapmethod
    {
        public string className { get; set; }
        public string method { get; set; }
    }
}
