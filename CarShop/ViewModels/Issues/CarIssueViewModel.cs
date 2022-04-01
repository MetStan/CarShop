using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class CarIssueViewModel
    {
        public string CarId { get; init; }

        public string CarModel { get; set; }

        public int Year { get; init; }

        public List<IssueViewModel> Issues { get; init; }
    }
}
