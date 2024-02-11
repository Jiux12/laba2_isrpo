using ILoveTasks.Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;

namespace ILoveTasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult TaskFirst()
        {
            return View();
        }

        public IActionResult TaskSecond()
        {
            return View();
        }

        public IActionResult TaskThird()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TaskFirst(int a, int b, int c)
        {
            int min = Math.Min(Math.Min(a, b), c);
            int max = Math.Max(Math.Max(a, b), c);

            int average = a + b + c - min - max;
            ViewBag.N = $"{average}";
            return View();
        }

        [HttpPost]
        public IActionResult TaskSecond(string StringS)
        {
            char[] StringNotSArr = StringS.ToCharArray();
        n:
            for (int i = 0; i < StringNotSArr.Length; i++)
            {
                if (StringNotSArr[i] == 'с' || StringNotSArr[i] == 'С')
                {
                    StringNotSArr[i] = '_';
                    for (int j = i + 1; j < StringNotSArr.Length; j++)
                    {
                        StringNotSArr[j - 1] = StringNotSArr[j];
                    }
                    StringNotSArr[StringNotSArr.Length - 1] = '_';
                }
            }
            for (int i = 0; i < StringNotSArr.Length; i++)
            {
                if (StringNotSArr[i] == 'с' || StringNotSArr[i] == 'С')
                { 
                    goto n;
                }
                else
                {
                    continue;
                }
            }
            ViewBag.StringNotS = new string(StringNotSArr);
            return View();
        }

        [HttpPost]
        public IActionResult TaskThird(string InputMass)
        {
            string[] mass2n = InputMass.Split(' ');
            int sum1 = 0, sum2 = 0;
            if(mass2n.Length % 2 == 0)
            { 
                for (int i = 0; i < mass2n.Length; i++)
                {
                    if (int.TryParse(mass2n[i], out var number1)) 
                    {
                        if (i % 2 == 0)
                        {
                            sum1 += Convert.ToInt32(mass2n[i]) * Convert.ToInt32(mass2n[i]);
                            sum2 += Convert.ToInt32(mass2n[i]) * Convert.ToInt32(mass2n[i]) * Convert.ToInt32(mass2n[i]);
                        }
                    }
                    else
                    {
                        ViewBag.sum1 = "Введите верный массив";
                        ViewBag.sum2 = "";
                        return View();
                    }
                }
                ViewBag.sum1 = $"Сумма квадратов: {sum1}";
                ViewBag.sum2 = $"Сумма кубов: {sum2}";
            }
            else
            {
                ViewBag.sum1 = "Массив нечетный";
                ViewBag.sum2 = "";
            }
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}