using System;
using NUnit.Framework;
using HelperLibrary;

namespace HelperLibraryTests_NUnit
{
    [TestFixture]
    public class PersonTest
    {

        [Test]
        public void NewPerson_ZeroReceiptsAsParam_ShouldReturnException()
        {
            Assert.Throws(typeof(ArgumentException),
                               delegate () { Person p = new Person(0); });
        }

        [Test]
        public void NewPerson_AddReceiptZeroValue_ShouldReturnException()
        {
            Person p = new Person(1);
            Assert.Throws(typeof(ArgumentException),
                               delegate () { p.AddReceipt(0); });
        }

        [Test]
        public void NewPerson_ExceedMaximumReceipts_ShouldReturnException()
        {
            Person p = new Person(1);
            p.AddReceipt(1);
            Assert.Throws(typeof(Exception),
                               delegate () { p.AddReceipt(1); });
        }

        [Test]
        public void NewPerson_AddReceiptOneValue_ShouldReturnTotalAmountOne()
        {
            Person p = new Person(1);
            p.AddReceipt(1);
            Assert.AreEqual(1, p.TotalAmount);
        }

        [Test]
        public void NewPerson_AddReceiptTwoValues_ShouldReturnReceiptsCountTwo()
        {
            Person p = new Person(2);
            p.AddReceipt(1);
            p.AddReceipt(1);
            Assert.AreEqual(2, p.Receipts.Count);
        }
    }
}
