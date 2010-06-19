//
// DO NOT REMOVE COPYRIGHT NOTICES OR THIS FILE HEADER.
//
// @Authors:
//       timop
//
// Copyright 2004-2010 by OM International
//
// This file is part of OpenPetra.org.
//
// OpenPetra.org is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
//
// OpenPetra.org is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
//
// You should have received a copy of the GNU General Public License
// along with OpenPetra.org.  If not, see <http://www.gnu.org/licenses/>.
//
using System;
using NUnit.Framework;
using System.Threading;
using System.Collections;
using System.Collections.Specialized;
using System.Globalization;
using System.Xml;
using System.IO;
using Ict.Tools.CodeGeneration;
using Ict.Common;
using Ict.Common.IO;

namespace Ict.Common.IO.Testing
{
    ///  This is a testing program for Ict.Common.IO.dll
    [TestFixture]
    public class TTestCommonIO
    {
        string PathToTestData;

        [SetUp]
        public void Init()
        {
            new TLogging("test.log");
            new TAppSettingsManager("Tests.Common.IO.dll.config");

            PathToTestData = "../../Common/IO/TestData/".Replace("/", System.IO.Path.DirectorySeparatorChar.ToString());
        }

        [Test]
        public void TestYmlXmlCSVImportExport()
        {
            XmlDocument doc = new XmlDocument();

            XmlDeclaration xmlDeclaration = doc.CreateXmlDeclaration("1.0", "utf-8", null);

            doc.InsertBefore(xmlDeclaration, doc.DocumentElement);

            // it is necessary to have this root node without attributes, to comply with the xml documents generated by TYML2XML
            XmlElement rootNode = doc.CreateElement(TYml2Xml.ROOTNODEINTERNAL);
            doc.AppendChild(rootNode);

            XmlElement childNode = doc.CreateElement(TYml2Xml.XMLELEMENT);
            childNode.SetAttribute("name", "testname");
            childNode.SetAttribute("active", true.ToString());
            rootNode.AppendChild(childNode);

            XmlElement anotherChildNode = doc.CreateElement(TYml2Xml.XMLELEMENT);
            anotherChildNode.SetAttribute("name", "testname2");
            anotherChildNode.SetAttribute("active", true.ToString());
            rootNode.AppendChild(anotherChildNode);

            XmlElement grandChildNode = doc.CreateElement(TYml2Xml.XMLELEMENT);
            grandChildNode.SetAttribute("name", "grandchild1");
            grandChildNode.SetAttribute("active", true.ToString());
            childNode.AppendChild(grandChildNode);

            XmlElement grandChild2Node = doc.CreateElement(TYml2Xml.XMLELEMENT);
            grandChild2Node.SetAttribute("name", "grandchild2");
            grandChild2Node.SetAttribute("active", false.ToString());
            childNode.AppendChild(grandChild2Node);

            // first see if the xml file is still the same
            string filename = PathToTestData + "test.xml";
            StreamWriter sw = new StreamWriter(filename + ".new");
            sw.Write(TXMLParser.XmlToString(doc));
            sw.Close();
            Assert.AreEqual(true, TTextFile.SameContent(filename,
                    filename + ".new"), "the files should be the same: " + filename);
            System.IO.File.Delete(filename + ".new");

            // now test the yml file
            filename = PathToTestData + "test.yml";
            TYml2Xml.Xml2Yml(doc, filename + ".new");
            Assert.AreEqual(true, TTextFile.SameContent(filename,
                    filename + ".new"), "the files should be the same: " + filename);
            System.IO.File.Delete(filename + ".new");

            // now test the csv file
            filename = PathToTestData + "test.csv";
            TCsv2Xml.Xml2Csv(doc, filename + ".new");
            Assert.AreEqual(true, TTextFile.SameContent(filename,
                    filename + ".new"), "the files should be the same: " + filename);
            System.IO.File.Delete(filename + ".new");

            // load from csv, is it the same xml code?
            filename = PathToTestData + "test.csv";
            XmlDocument docFromCSV = TCsv2Xml.ParseCSV2Xml(filename);
            filename = PathToTestData + "test.xml";
            sw = new StreamWriter(filename + ".new");
            sw.Write(TXMLParser.XmlToString(docFromCSV, true));
            sw.Close();
            Assert.AreEqual(true, TTextFile.SameContent(filename,
                    filename + ".new"), "after importing from csv: the files should be the same: " + filename);
            System.IO.File.Delete(filename + ".new");

            // load from yml, is it the same xml code?
            filename = PathToTestData + "test.yml";
            TYml2Xml converterYml = new TYml2Xml(filename);
            XmlDocument docFromYML = converterYml.ParseYML2XML();
            filename = PathToTestData + "testWithInheritedAttributes.xml";
            sw = new StreamWriter(filename + ".new");
            sw.Write(TXMLParser.XmlToString(docFromYML, true));
            sw.Close();
            Assert.AreEqual(true, TTextFile.SameContent(filename,
                    filename + ".new"), "after importing from yml: the files should be the same: " + filename);
            System.IO.File.Delete(filename + ".new");
        }

        [Test]
        public void TestCompressingString()
        {
            string testText = "<test>blablablablabla</test>";

            string compressed = PackTools.ZipString(testText);

            Assert.AreEqual(testText, PackTools.UnzipString(compressed), "compressing a string");
        }
    }
}