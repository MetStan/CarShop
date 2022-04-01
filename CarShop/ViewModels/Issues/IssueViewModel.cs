using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarShop.ViewModels.Issues
{
    public class IssueViewModel
    {
        public string IssueId { get; init; }

        public string Description { get; init; }

        public string IsFixed { get; init; }
    }
}
