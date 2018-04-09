using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using RigoAccounts.DLL;

namespace RigoAccounts.BLL.Manager
{
    public class CustomerManager
    {
        public static bool insertCustomer(Customer cust, bool isInsert)
        {

            bool status = false;

            if (cust != null)
            {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

                if (isInsert)
                {
                    cust.CreatedOn = DateTime.Now;
                    dc.Customers.InsertOnSubmit(cust);

                }

                else
                {

                    Customer dbCust = dc.Customers.Where(x => x.CustomerID == cust.CustomerID).SingleOrDefault();

                    if (dbCust != null)
                    {

                        dbCust.Name = cust.Name;
                        dbCust.Address = cust.Address;
                        dbCust.ModifiedOn = DateTime.Now;
                    }
                }

                dc.SubmitChanges();
                status = true;
            }


            return status;
        }

        public static List<Customer> getAllCustomers()
        {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
            return dc.Customers.ToList();
        }

        public static Customer getCustomerById(int id)
        {

            SampleDatabaseDataContext dc = new SampleDatabaseDataContext();

            return dc.Customers.Where(x => x.CustomerID == id).SingleOrDefault();
        }

        public static bool deleteCustomer(Customer cust)
        {

            bool status = false;

            if (cust != null)
            {

                SampleDatabaseDataContext dc = new SampleDatabaseDataContext();
                Customer dbcust = dc.Customers.Where(x => x.CustomerID == cust.CustomerID).SingleOrDefault();

                if (dbcust != null)
                {

                    dc.Customers.DeleteOnSubmit(dbcust);
                    dc.SubmitChanges();
                    status = true;
                }
            }
            return status;
        }
    }
}