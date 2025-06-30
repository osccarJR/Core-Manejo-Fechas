using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using DateCoreApp.Data;
using DateCoreApp.Models;
using DateCoreApp.Services.Interfaces;
using DateCoreApp.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DateCoreApp.Controllers
{
    public class DateLogsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IDateService _dateService;

        public DateLogsController(ApplicationDbContext context, IDateService dateService)
        {
            _context = context;
            _dateService = dateService;
        }

        public async Task<IActionResult> Index()
        {
            var logs = await _context.DateLogs.ToListAsync();

            var viewModel = logs.Select(log => new DateLogViewModel
            {
                Action = log.Action,
                RegisteredAtFormatted = _dateService.FormatDate(log.RegisteredAt, "readable")
            }).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        // 🔹 3.2 Valida y envía mensaje desde Create en el controlador
        [HttpPost]
        public async Task<IActionResult> Create(string action)
        {
            if (string.IsNullOrWhiteSpace(action))
            {
                TempData["Success"] = "El campo acción no puede estar vacío.";
                return View();
            }

            var log = new DateLog
            {
                Action = action,
                RegisteredAt = _dateService.GetCurrentDate()
            };

            _context.DateLogs.Add(log);
            await _context.SaveChangesAsync();

            TempData["Success"] = "¡Acción registrada exitosamente!";
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Diff()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Diff(DateTime fromDate, DateTime toDate)
        {
            var days = _dateService.GetDaysBetween(fromDate, toDate);
            ViewBag.DaysBetween = days;
            return View();
        }

        [HttpGet]
        public IActionResult ConvertTime()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ConvertTime(string timeZoneId)
        {
            var currentDate = _dateService.GetCurrentDate();
            var converted = _dateService.ConvertToTimeZone(currentDate, timeZoneId);
            ViewBag.ConvertedDate = _dateService.FormatDate(converted, "readable");
            return View();
        }
    }
}
