using StateMamangementV02.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StateMamangementV02.Controllers
{
    ///Session:
    ///Information about client stored in server Memory
    ///.net core=>restrict add any object in session
    
    ///Cookies:
    ///Text file stored in client PC   =>string
    public class HomeController : Controller
    {
        ///State Memegements
        ///1- Session   =>recommendatin  Password,bank account No,Email
        ///2- cookies 
        // GET: Home
        public ActionResult Index()
        {
            Employee emp = new Employee {Id=1,Name="Nehal",Age=22,Salary=1234 };

            Session.Add("e1", emp);

            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }

        public ActionResult About()
        {
            Employee emp = new Employee { Id = 2, Name = "Islam", Age = 22, Salary = 1234 };

            HttpCookie ckobj = new HttpCookie("ckfile");

            ckobj["Id"] = emp.Id.ToString();
            ckobj["Name"] = emp.Name.ToString();
            ckobj["Age"] = emp.Age.ToString();
            ckobj["Salary"] = emp.Salary.ToString();

            ckobj.Expires.AddDays(5);

            //Register Cookie Object as a File
            Response.Cookies.Add(ckobj);

            return View();
        }
    }
}