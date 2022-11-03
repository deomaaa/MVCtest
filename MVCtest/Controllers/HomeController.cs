using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using MVCtest.Classes;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace MVCtest.Controllers
{
    public class HomeController : Controller
    {
        public List<Test> Qst = new List<Test>//вопрос/ответ/номер вопроса
        {
             new Test("2 5 8 11 _ - Вставьте пропущенную цифру.", "14", 1),
             new Test("дом иглу бунгало офис хижина - Выберите лишнее слово.", "офис", 2),
             new Test("селедка  кит  акула  барракуда треска - Выберите лишнее слово.", "кит", 3),
             new Test("сколько будет 2+2?", "4", 4)
        };
        public static int i = 0;//переменная для управления списком вопросов
        public static int Right = 0;//количество правильных ответов в тесте 
        public IActionResult Start()//начальная страница теста
        {
            Right = 0;
            return View();  
        }
        public IActionResult Tests()//прохождение самого теста
        {
            return View(Qst[i]);
        }
        public IActionResult Processing(string answForm)//подсчёт правильных ответов и переход либо к след вопросу либо к результатам
        {
            if(answForm == Qst[i].Answ)
            {
                Right++;
            }
            if(i!=Qst.Count-1)
            {
                i++;
                return RedirectToAction("Tests", "Home");
            }
            else
            {
                i = 0;
            }
            return RedirectToAction("Result", "Home");
        }
        public IActionResult Result()//результаты теста
        {
            ViewBag.Res = Qst.Count;
            return View(Right);
        }
    }
}
