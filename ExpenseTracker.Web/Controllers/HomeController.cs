﻿using System.Web.Mvc;
using Abp.Web.Mvc.Authorization;

namespace ExpenseTracker.Web.Controllers
{
    [AbpMvcAuthorize]
    public class HomeController : ExpenseTrackerControllerBase
    {
        public ActionResult Index()
        {
            return View("~/App/Main/views/layout/layout.cshtml"); //Layout of the angular application.
        }
	}
}