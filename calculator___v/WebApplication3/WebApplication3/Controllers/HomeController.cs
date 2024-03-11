using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        private static string ConnectionString()
        {
            string result = System.Web.Configuration.WebConfigurationManager.ConnectionStrings["connDB"].ConnectionString;
            return result;
        }

        public ActionResult Index()
        {
            string password = "uark@1234";
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);


            var test = BCrypt.Net.BCrypt.Verify(password+"1", hashedPassword);

            string pwd = "uark@1234";
            string SLATT = "letmetest";

            byte[] passwordAndSaltBytes = Encoding.UTF8.GetBytes(pwd + SLATT);
            byte[] hashBytes = new System.Security.Cryptography.SHA256Managed().ComputeHash(passwordAndSaltBytes);
            string hashString = Convert.ToBase64String(hashBytes);

            string[] tesetes = { } ;

            Main(tesetes);

            return View();
        }

        [HttpPost]
        public ActionResult ToCount(string Mark,int former, int latter,string? last_btn)
        {
            int answer = Count(Mark, former, latter, last_btn);

            return Json(new { success = true, answer = answer });
        }


        private int Count(string Mark, int former, int latter, string? last_btn)
        {
            int answer = 0;

            if(last_btn == "")
            {
                last_btn = Mark;
            }

            switch (last_btn)
            {
                case "+":
                    answer = former + latter;
                    break;
                case "-":
                    answer = former - latter;
                    break;
                case "*":
                    answer = former * latter;
                    break;
                case "/":
                    answer = former / latter;
                    break;
                case "AC":
                    answer = 0;
                    break;
                case "=":
                    if (!String.IsNullOrEmpty(last_btn))
                    {
                        answer = Count(last_btn, former, latter, null);
                    }

                    break;
            }


            return answer;
        }



        static async Task Main(string[] args)
        {
            Debug.WriteLine("Start of Main");

            // 呼叫非同步方法，它允許 Main 方法繼續執行
            await Task.Run(async () => await DownloadDataAsync());

            // 非同步方法完成後才會執行這裡的代碼
            Debug.WriteLine("End of Main");
        }

        static async Task DownloadDataAsync()
        {
            Debug.WriteLine("Start of DownloadDataAsync");

            // 模擬一個非同步操作，例如等待 10 秒
            await Task.Delay(10000).ConfigureAwait(false);

            Debug.WriteLine("Data downloaded successfully");

            // 你可以在這裡進行後續的非同步操作
        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}