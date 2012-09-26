using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ServicioWebRest.Areas.API.Models;

namespace ServicioWebRest.Areas.API.Controllers
{
    public class ClientsController : Controller
    {
        Models.ClientManager cManager = new Models.ClientManager();

        //
        // GET: /API/Clients/

        //public ActionResult Index()
        //{
        //    return View();
        //}

        [HttpGet]
        public JsonResult Clients()
        {
            return Json(cManager.getClients(),
                        JsonRequestBehavior.AllowGet);
        }

        public JsonResult Client(int? id, Client item)
        {
            switch (Request.HttpMethod)
            {
                case "POST":
                    return Json(cManager.insertClient(item));
                case "PUT":
                    return Json(cManager.updateClient(item));
                case "GET":
                    return Json(cManager.getClient(id.GetValueOrDefault()),
                                JsonRequestBehavior.AllowGet);
                case "DELETE":
                    return Json(cManager.deleteClient(id.GetValueOrDefault()));
            }

            return Json(new { Error = true, Message = "Unknown HTTP Operation" });
        }

    }
}
