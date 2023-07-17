using Microsoft.AspNetCore.Mvc;
using System;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Finance.Web.Controllers
{
    public class InterestCalculator : Controller
    {
        static public double deposit = 1;
        static public double interestRate = 0;
        static public double numberOfYears = 0;

        public IActionResult Index()
        {

          
            ViewBag.Deposit = deposit;
            ViewBag.InterestRate = interestRate;
            ViewBag.NumberOfYears = numberOfYears;

            return View();
        }


        public IActionResult Calcs()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Calcs(int addeposit, int years, int rate)
        {
            deposit = addeposit;
            interestRate = rate;
            numberOfYears = years;

            ViewBag.Deposit = deposit;
            ViewBag.InterestRate = interestRate;
            ViewBag.NumberOfYears = numberOfYears;
            return RedirectToAction("interestDisplay");
        }

        public IActionResult interestDisplay()
        {


            ViewBag.Deposit = deposit;
            ViewBag.InterestRate = interestRate;
            ViewBag.NumberOfYears = numberOfYears;

            double totalAmount = 0;

            totalAmount = deposit * Math.Pow((1 + (interestRate/100) / 12), (12 * numberOfYears));
            ViewBag.TotalAmount = totalAmount;
            return View();
        }

        
    }
}
