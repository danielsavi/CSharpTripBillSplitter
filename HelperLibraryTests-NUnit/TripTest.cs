using System;
using NUnit.Framework;
using HelperLibrary;

namespace HelperLibraryTests_NUnit
{
    [TestFixture]
    public class TripTest
    {

        [Test]
        public void NewTrip_ZeroPeopleAsParam_ShouldReturnException()
        {
            Assert.Throws(typeof(ArgumentException),
                               delegate () { Trip t = new Trip(0); });
        }

        //[Test]
        //public void NewTrip_AddPersonNullValue_ShouldReturnException()
        //{
        //    Trip t = new Trip(1);
        //    Assert.Throws(typeof(ArgumentNullException),
        //                       delegate () { t.AddPerson(null); });
        //}

        //[Test]
        //public void NewTrip_ExceedMaximumPeople_ShouldReturnException()
        //{
        //    Trip t = new Trip(1);
        //    t.AddPerson(new Person(1) );
        //    Assert.Throws(typeof(Exception),
        //                       delegate () { t.AddPerson(new Person(1)); });
        //}

    }
}
