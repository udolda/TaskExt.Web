﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EleWise.ELMA.Extensions;
using EleWise.ELMA.Web.Mvc.Extensions;
using EleWise.ELMA.Web.Mvc.Attributes;
using EleWise.ELMA.Web.Mvc.Controllers;
using Orchard;
using Orchard.Themes;

namespace SendToProcess.Web.Controllers
{
    [Themed]
    public class HomeController : BaseController
    {
        //
        // GET: /SendToProcess.Web/

        public ActionResult Index()
        {
            return View();
        }

    }
}
