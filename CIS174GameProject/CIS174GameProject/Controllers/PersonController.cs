﻿using CIS174GameProject.Models;
using CIS174GameProject.Shared.Orchestrators.Interfaces;
using CIS174GameProject.Shared.ViewModels;
using System;
using System.Threading.Tasks;
using System.Web.Mvc;
using CIS174GameProject.ErrorReport;

namespace CIS174GameProject.Controllers
{
    [ExceptionHandler]
    public class PersonController : Controller
    {
        private readonly IPersonOrchestrator _personOrchestrator;

        public PersonController(IPersonOrchestrator personOrchestrator)
        {
            _personOrchestrator = personOrchestrator;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> CreatePerson(CreatePersonModel person)
        {
            string userId = Session["userId"].ToString();

            var updatedCount = await _personOrchestrator.CreatePerson(new PersonViewModel
            {
                PersonId = Guid.Parse(userId),
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                DateCreated = person.DateCreated,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return Json(updatedCount, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Update()
        {
            return View();
        }

        public async Task<JsonResult> UpdatePerson(UpdatePersonModel person)
        {
            if (person.PersonId == Guid.Empty)
            {
                return Json(false, JsonRequestBehavior.AllowGet);
            }

            var result = await _personOrchestrator.UpdatePerson(new PersonViewModel
            {
                PersonId = person.PersonId,
                FirstName = person.FirstName,
                LastName = person.LastName,
                Gender = person.Gender,
                Email = person.Email,
                PhoneNumber = person.PhoneNumber
            });

            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public async Task<JsonResult> Search(string searchGuid)
        {
            if (searchGuid == "userId")
            {
                string userId = Session["userId"].ToString();
                searchGuid = userId;
            }

            Guid parsedGuid = Guid.Parse(searchGuid);

            var viewModel = await _personOrchestrator.SearchPeople(parsedGuid);

            return Json(viewModel, JsonRequestBehavior.AllowGet);
        }
    }
}
