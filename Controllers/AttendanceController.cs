using Attendance_Management_System.DAL;
using Attendance_Management_System.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace Attendance_Management_System.Controllers
{
    public class AttendanceController : Controller
    {
        // GET: Attendance
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public JsonResult Mark(int id)
        {
            DynamicParameters param = new DynamicParameters();
            param.Add("@id", id);

            var attendance_result = DapperContext.ReturnSingle<AttendanceModel>("sp_insertAttendance", param);
            //return View(attendance_result);
            return Json(new
            {
                status = attendance_result.status,
                in_time = attendance_result.in_time.ToString(@"hh\:mm"),
                date = attendance_result.date.ToString("dd MMM yyyy")
            });
        }
    }
}