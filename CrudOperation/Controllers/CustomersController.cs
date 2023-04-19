using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CrudOperation.Controllers
{
    public class CustomersController : ApiController
    {
        CustomerEntities db = new CustomerEntities();
        public IEnumerable<Customer> Get()
        {
            return db.Customers.ToList();
        }
        //This method will return a single Customer against id  
        public Customer Get(int id)
        {
            Customer customer = db.Customers.Find(id);
            return customer;
            

        }
        //This method will add a new Customer  
        public void POST(Customer customer)
        {
            db.Customers.Add(customer);
            db.SaveChanges();
        }
       //This method to Update a Customers
      public void PUT(int id, Customer customer)
        {
            var customer1 = db.Customers.Find(id);
            customer1.mmid = customer.mmid;
            customer1.firstname = customer.firstname;
            customer1.lastname = customer.lastname;
            customer1.email = customer.email;
            customer1.phone_number = customer.phone_number;
            customer1.city = customer1.city;
            db.Entry(customer1).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
        }
        //This method will delete a customer
       public string Delete(int id)
        {
            Customer customer = db.Customers.Find(id);
            db.Customers.Remove(customer);
            db.SaveChanges();
            return "Customer Deleted";
        }
    }
}
