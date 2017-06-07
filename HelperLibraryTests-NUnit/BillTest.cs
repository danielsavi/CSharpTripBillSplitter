using System;
using NUnit.Framework;
using HelperLibrary;

namespace HelperLibraryTests_NUnit
{
    [TestFixture]
    public class BillTest
    {

        [Test]
        public void Bill_CalcNumberOfPeopleZero_ShouldReturnException()
        {
            Assert.Throws(typeof(ArgumentException),
                               delegate () { Bill.Calc(1, 1, 0); });
        }

        [TestCase(20, 10, 2, 0)]
        [TestCase(20, 5, 2, 5)]
        [TestCase(20, 15, 2, -5)]
        [TestCase(20, 0, 1, 20)]
        [TestCase(0, 0, 1, 0)]
        [TestCase(0, 10, 1, -10)]
        public void Bill_Calc_ShouldReturnValidResult(decimal tripAmount, decimal personAmount, int numberOfPeople, decimal expectedTotal)
        {
            decimal billCalc = Bill.Calc(tripAmount, personAmount, numberOfPeople);
            Assert.AreEqual(expectedTotal, billCalc);
        }

        [Test]
        public void FormatDecimalToCustomStringWhenValueLessThanZero()
        {
            string s = Bill.FormatDecimalToCustomString(-0.98m);
            Assert.AreEqual("($0.98)", s);
        }

        [Test]
        public void FormatDecimalToCustomStringWhenValueGreaterThanZero()
        {
            string s = Bill.FormatDecimalToCustomString(0.98m);
            Assert.AreEqual("$0.98", s);
        }

        [Test]
        public void FormatDecimalToCustomStringWhenValueEqualsZero()
        {
            string s = Bill.FormatDecimalToCustomString(0m);
            Assert.AreEqual("$0", s);
        }

    }
}
