using Liberator.DynamicPageEngine.Entities;
using System.Collections.Generic;
using System.Xml;
using System.Xml.XPath;

namespace Liberator.DynamicPageEngine.Output
{
    public class XMLWriter : IWriter
    {

        /// <summary>
        /// The HTML document
        /// </summary>
        public IXPathNavigable PageDocument { get; set; }
        
        public XMLWriter(List<PageObjectEntry> pageObjectEntries)
        {
            InitialiseXmlDocument();
        }


        XmlDocument InitialiseXmlDocument()
        {
            XmlDocument xmlDocument = new XmlDocument();
            XmlDeclaration xmlDeclaration = xmlDocument.CreateXmlDeclaration("1.0", "UTF-8", null);
            XmlElement root = xmlDocument.DocumentElement;
            xmlDocument.InsertBefore(xmlDeclaration, root);
            PageDocument = xmlDocument;
            return xmlDocument;
        }
    }
}
/* 
        XmlElement element1 = doc.CreateElement( string.Empty, "body", string.Empty );
        doc.AppendChild( element1 );
        doc.Save( "D:\\document.xml" );

     */
