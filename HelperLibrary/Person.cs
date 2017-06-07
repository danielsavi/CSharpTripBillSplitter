using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HelperLibrary
{
    public class Person
    {
        public int NumberOfReceipts { get; set; }
        public decimal TotalAmount { get; private set; }
        public ICollection<decimal> Receipts { get; private set; }

        public bool IsReceiptsCompleted
        {
            get
            {
                if (Receipts == null)
                {
                    return false;
                }

                return Receipts.Count == NumberOfReceipts;
            }
        }

        public Person(int numberOfReceipts)
        {
            if (numberOfReceipts <= 0)
            {
                throw new ArgumentException("numberOfReceipts must bt greater than zero");
            }

            if (Receipts == null)
            {
                Receipts = new List<decimal>();
            }

            NumberOfReceipts = numberOfReceipts;
        }

        public void AddReceipt(decimal value)
        {
            if (value <= 0)
            {
                throw new ArgumentException("numberOfReceipts must bt greater than zero");
            }

            if (IsReceiptsCompleted)
            {
                throw new Exception("numberOfReceipts is already reached");
            }

            Receipts.Add(value);
            TotalAmount += value;
        }
    }
}
