using System.Collections.Generic;
using System.Linq;
using intern_track_back.Data;

namespace intern_track_back.ViewModels.Api.Companies
{
    public class CompaniesResponseModel
    {
        public List<CompanyResponseModel>? Companies { get; set; }

        public CompaniesResponseModel Init(UnitOfWork unitOfWork)
        {
            Companies = unitOfWork.CompanyRepository
                .Select(c => new CompanyResponseModel
                {
                    CompanyId = c.Id,
                    Name = c.CompanyName,
                    About = c.About,
                    Address = c.Address
                })
                .OrderBy(v => v.Name)
                .ToList();

            return this;
        }
    }
}
