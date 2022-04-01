using CarShop.Services.Contracts;
using CarShop.ViewModels.Issues;
using MyWebServer.Controllers;
using MyWebServer.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Controllers
{
    public class IssuesController : Controller
    {
        private readonly IIssueService issueService;

        public IssuesController(IIssueService service)
        {
            issueService = service;
        }

        [Authorize]
        public HttpResponse Add(string carId)
        {
            return this.View(new IssueFormViewModel { CarId = carId });
        }

        [Authorize]
        [HttpPost]
        public HttpResponse Add(IssueFormViewModel model, string carId)
        {
            var errors = issueService.CreateIssue(model, carId).ToList();

            if (errors.Any() == false)
            {
                return Redirect($"/Issues/CarIssues?carId={carId}");
            }

            return Error(errors);
        }

        [Authorize]
        public HttpResponse CarIssues(string carId)
        {
            var carIssues = issueService.GetCarIssues(carId);

            if (carIssues == null)
            {
                return NotFound();
            }

            return View(carIssues);
        }

        [Authorize]
        public HttpResponse Delete(string issueId, string carId)
        {
            var error = issueService.DeleteIssue(carId, issueId, User.Id);

            if (string.IsNullOrEmpty(error) == false || string.IsNullOrWhiteSpace(error) == false)
            {
                return Error(error);
            }

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }

        public  HttpResponse Fix(string issueId, string carId)
        {
            var error = issueService.FixIssue(carId, issueId, User.Id);

            if (string.IsNullOrEmpty(error) == false || string.IsNullOrWhiteSpace(error) == false)
            {
                return Error(error);
            }

            return Redirect($"/Issues/CarIssues?carId={carId}");
        }
    }
}
