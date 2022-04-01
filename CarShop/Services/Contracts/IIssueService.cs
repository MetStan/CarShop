using CarShop.ViewModels.Issues;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.Services.Contracts
{
    public interface IIssueService
    {
        ICollection<string> CreateIssue(IssueFormViewModel model, string carId);

        CarIssueViewModel GetCarIssues(string carId);

        string DeleteIssue(string carId, string issueId, string userId);

        string FixIssue(string carId, string issueId, string userId);
    }
}
