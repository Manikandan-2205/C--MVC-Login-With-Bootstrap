using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using login.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.IO;

namespace login.Controllers
{
    public class Login_RegistrationController : Controller
    {
        // GET: Login_Registration
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(Registration uc, HttpPostedFileBase file)
        {
            string mainconn = ConfigurationManager.ConnectionStrings["MyConnection"].ConnectionString;
            SqlConnection sqlconn = new SqlConnection(mainconn);
            string sqlquery = "insert into Login_form (UserName,UserEmail,UserPassword,UserGender,Userimage) values(@UserName,@UserEmail,@UserPassword,@UserGender,@Userimage)";
            SqlCommand sqlcomm = new SqlCommand(sqlquery, sqlconn);
            sqlconn.Open();
            sqlcomm.Parameters.AddWithValue("@UserName", uc.UserName);
            sqlcomm.Parameters.AddWithValue("@UserEmail", uc.UserEmail);
            sqlcomm.Parameters.AddWithValue("@UserPassword", uc.UserPassword);
            sqlcomm.Parameters.AddWithValue("@UserGender", uc.UserGender);
            if (file != null && file.ContentLength > 0)
            {
                string filename = Path.GetFileName(file.FileName);
                string imgpath = Path.Combine(Server.MapPath("~/User-Images/"), filename);
                file.SaveAs(imgpath);
            }
            sqlcomm.Parameters.AddWithValue("@Userimage", "~/User-Images/" + file.FileName);
            sqlcomm.ExecuteNonQuery();
            sqlconn.Close();
            ViewData["Message"] = "User Record " + uc.UserName + " Is Save Successfully";
            return View();
        }

    }
}