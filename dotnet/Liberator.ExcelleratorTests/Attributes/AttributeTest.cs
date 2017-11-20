using Liberator.Excellerator.Attributes;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Liberator.ExcelleratorTests.Attributes
{
    [TestFixture]
    public class AttributeTest
    {
        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_ClassAnnotation()
        {
            IEnumerable<Attribute> attributes = typeof(AttributeTestFile).GetCustomAttributes();
            Assert.That(attributes.Count() == 1, Is.True);
        }

        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_PropertyAnnotation()
        {
            PropertyInfo[] properties = typeof(AttributeTestFile).GetProperties();
            Assert.That(properties.Count() == 4, Is.True);
        }

        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_PropertyAnnotation_ID()
        {
            PropertyInfo[] properties = typeof(AttributeTestFile).GetProperties();
            ColumnAttribute attA = (ColumnAttribute)properties[0].GetCustomAttribute(typeof(ColumnAttribute));

            Assert.That(properties[0].GetCustomAttributes(typeof(ColumnAttribute)).Count() == 1, Is.True);

            Assert.That(attA.Name.Contains("ID"), Is.True);
            Assert.That(attA.Mandatory, Is.True);
        }

        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_PropertyAnnotation_Name()
        {
            PropertyInfo[] properties = typeof(AttributeTestFile).GetProperties();
            ColumnAttribute attB = (ColumnAttribute)properties[1].GetCustomAttribute(typeof(ColumnAttribute));

            Assert.That(attB.Name.Contains("Name"), Is.True);
            Assert.That(((string)attB.Default).Contains("John Smith"), Is.True);
        }

        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_PropertyAnnotation_Address()
        {
            PropertyInfo[] properties = typeof(AttributeTestFile).GetProperties();
            ColumnAttribute attC = (ColumnAttribute)properties[2].GetCustomAttribute(typeof(ColumnAttribute));

            Assert.That(attC.Name.Contains("Address"), Is.True);
        }

        [Test]
        [Category("CustomAttributes")]
        public void TestAttribute_PropertyAnnotation_Preference()
        {
            PropertyInfo[] properties = typeof(AttributeTestFile).GetProperties();
            ColumnAttribute attD = (ColumnAttribute)properties[3].GetCustomAttribute(typeof(ColumnAttribute));

            Assert.That(attD.Name.Contains("Preference"), Is.True);
            Assert.That(attD.Mandatory, Is.True);
            Assert.That(attD.Default, Is.True);
        }
    }
}
