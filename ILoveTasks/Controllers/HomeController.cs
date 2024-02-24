using ILoveTasks.Models;
using System.Linq;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using static ILoveTasks.Controllers.HomeController;

namespace ILoveTasks.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public class MatrixViewModel
        {
            public int[,] Matrix { get; set; }
        }

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
            int[,] matrix = new int[,] { { 5, 34, 7, 2, 9 }, { 4, 21, 7, 2, 9 }, { 43, 5, 2, 9, 3 }, { 5, 34, 7, 2, 9 }, { 3, 5, 2, 9, 3 } };

            MatrixViewModel model = new MatrixViewModel
            {
                Matrix = matrix
            };

            List<int> flatMatrix = new List<int>();

            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    flatMatrix.Add(matrix[i, j]);
                }
            }

            List<int> minElements = flatMatrix.OrderBy(x => x).Take(5).ToList();

            int sum = minElements.Sum();
            double average = (double)sum / 5;
            ViewBag.average = $"{average}";

            return View(model);
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
        public IActionResult TaskSecond(string sentence)
        {
            string modifiedSentence = sentence.Replace(' ', '_');
            ViewBag.modifiedSentence = $"{modifiedSentence}";
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}