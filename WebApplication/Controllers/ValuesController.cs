using DataModel;
using NEWDEMO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplication.Controllers
{
    public class ValuesController : ApiController
    {
        public OperationContext context { get; set; }

        public ValuesController()
        {
            context = new OperationContext();

        }


        //[HttpPut]
        ////[Route("api/operation/{Id}")]
        //[ActionName("updateoperation")]
        //public void updateoperation(int Id, operation oper)
        //{
        //    if (context.op.Where(x => x.Id == Id).Any())
        //    {
        //        operation o = context.op.Where(x => x.Id == Id).First();

        //        o.invoiceNB = oper.invoiceNB;
        //        o.vendorName = oper.vendorName;
        //        o.scanDate = oper.scanDate;
        //        o.siteNB = oper.siteNB;
        //        context.SaveChanges();

        //    }
        //}

        //[HttpPost]
        //[ActionName("insertOperation")]
        //public void insertOperation(operation op)
        //{
        //    if (op.vendorName != null && op.invoiceNB != 0 && op.invoiceNB != 0 && op.scanDate != null && op.siteNB != 0 && op.paymentDueDate != 0 && op.voucherNB != 0)
        //    {
        //        op.Id = 0;
        //        context.op.Add(op);
        //        context.SaveChanges();
        //    }

        //}

        //[HttpGet]
        //[ActionName("getoperation")]
        //[Route("api/Values/Get")]
        //public IEnumerable<invoicesviewmodel> getoperation(invoiceinput i)
        //{

        //    List<operation> operationlist = new List<operation>();
        //    List<invoicesviewmodel> model = new List<invoicesviewmodel>();
        //    if (i.fromdate != null && i.todate != null)
        //    {




        //        if (context.op.Where(x => x.scanDate >= i.fromdate && x.scanDate <= i.todate).Any())
        //        {
        //            operationlist = context.op.Where(x => x.scanDate >= i.fromdate && x.scanDate <= i.todate).ToList();
        //            invoicesviewmodel invoice = new invoicesviewmodel();
                  

        //            foreach (operation op in operationlist)
        //            {
        //                invoice.op.vendorName = op.vendorName;
        //                invoice.op.scanDate = op.scanDate;
        //                invoice.op.voucherNB = op.voucherNB;
        //                invoice.op.paymentDueDate = op.paymentDueDate;
        //                invoice.op.invoiceNB = op.invoiceNB;
        //                invoice.op.siteNB = op.siteNB;

        //                model.Add(invoice);
        //            }

        //        }
        //    }
        //    return model;

        //}
        [HttpPost]
        [ActionName("Get")]
        [Route("api/values/Get")]
        // GET api/values
        public IEnumerable<operation> Get(invoiceinput i)
        {
            List<operation> operationlist = new List<operation>();


            if (i.fromdate != null && i.todate != null)
            {



                if (context.op.Where(x => x.scanDate >= i.fromdate && x.scanDate <= i.todate).Any())
                {
                    operationlist = context.op.Where(x => x.scanDate >= i.fromdate && x.scanDate <= i.todate).ToList();






                }
            }
            return operationlist;
        }



        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [ActionName("Post")]
        [Route("api/values/PostOP")]
        // POST api/values
        public void PostOP([FromBody]operation op)
        {
            if (op.vendorName != null && op.invoiceNB != 0 && op.scanDate != null && op.siteNB != 0  )
            {
                
                context.op.Add(entity: op);
                context.SaveChanges();
            }
        }
       

        [HttpPut]
        //[Route("api/operation/{Id}")]
        [ActionName("updateoperation")]
        // PUT api/values/5
        public void Put(int id, [FromBody]operation oper)
        {

            if (context.op.Where(x => x.Id == id).Any())
            {
                operation o = context.op.Where(x => x.Id == id).First();

                o.invoiceNB = oper.invoiceNB;
                o.vendorName = oper.vendorName;
                o.scanDate = oper.scanDate;
                o.siteNB = oper.siteNB;
                context.SaveChanges();
            }
        }
        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
