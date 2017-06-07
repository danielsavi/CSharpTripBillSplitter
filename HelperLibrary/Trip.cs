using System;
using System.Collections.Generic;
using System.Linq;

namespace HelperLibrary
{
    public class Trip
    {
        public int NumberOfPeople { get; set; }
        public IList<Person> People { get; private set; }

        public bool IsPeopleCompleted
        {
            get
            {
                if (People == null)
                {
                    return false;
                }

                return People.Count == NumberOfPeople;
            }
        }

        public Trip(int numberOfPeople)
        {
            if (numberOfPeople <= 0)
            {
                throw new ArgumentException("numberOfPeople must bt greater than zero");
            }

            if (People == null)
            {
                People = new List<Person>();
            }

            NumberOfPeople = numberOfPeople;
        }

        public void AddPerson(int numberOfReceipts)
        {
            if (IsPeopleCompleted)
            {
                throw new Exception("numberOfPeople is already reached");
            }

            if (People.LastOrDefault().IsReceiptsCompleted == false)
            {
                throw new Exception("cannot add new person, missing receipts on previous one");
            }

            var person = new Person(numberOfReceipts);
            People.Add(person);
        }

        public void AddReceiptToLastPerson(decimal value)
        {
            if (People == null)
            {
                throw new Exception("cannot add receipt to a empty person list");
            }

            if (People.LastOrDefault().Receipts == null)
            {
                throw new Exception("cannot add receipt to a null receipts list");
            }


            People.LastOrDefault().AddReceipt(value);
        }

    }
}
