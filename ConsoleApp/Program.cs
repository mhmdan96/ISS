using System;
using NEWDEMO;
using DataModel;
using System.Linq;

namespace ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {

            //AddingOperation();
            // get();
            //delete();
            update();
            Console.ReadKey();
        }
        private static void AddingOperation()
        {
            var operation = new operation
            {
                invoiceNB = 3,
                siteNB = 4,
                scanDate = new DateTime(2015, 6, 5),
                vendorName = "abed",
                voucherNB = 5,
                paymentDueDate = 5000,
                bankNB = 22334455
            };
            using (var context = new OperationContext())
            {


                context.Database.Log = Console.WriteLine;

                context.op.Add(operation);
                context.SaveChanges();
            }

        }
       
        
        private static void get()
        {

            using (var context = new OperationContext())
            {

                var operation = context.op.SqlQuery("exec GetOperations");

                foreach (var oper in operation)
                {
                    Console.WriteLine(oper.vendorName);
                }

            }


        }
        private static void delete()
        {


            using (var context = new OperationContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand( "exec DeleteOperation");

            }

        }
        private static void update()
        {
            using (var context=new OperationContext())
            {
                context.Database.Log = Console.WriteLine;
                context.Database.ExecuteSqlCommand("exec UpdateOperation");


            }



        }

    }
}
