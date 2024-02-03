using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MtnraProvidersManager_BAL.Contracts;
using MtnraProvidersManager_BAL.Dtos.Company;
using MtnraProvidersManager_DAL.Contracts;

namespace MtnraProvidersManager_PAL.Controllers
{
    [ApiController]
    [Route("api/companies")]
    [Authorize]
    public class CompaniesController : ControllerBase
    {
        private readonly ICompanyService _service;
        private readonly IChangesHandler _changesHandler;

        public CompaniesController(
            ICompanyService service,
            IChangesHandler changesHandler)
        {
            _service = service;
            _changesHandler = changesHandler;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CompanyReadDto>> GetAll()
        {
            var companies = _service.GetCompanies();
            return companies == null ? (ActionResult<IEnumerable<CompanyReadDto>>)NoContent() : (ActionResult<IEnumerable<CompanyReadDto>>)Ok(companies);
        }

        [HttpGet("{id:guid}")]
        public ActionResult<CompanyReadDto> GetById(Guid id)
        {
            var company = _service.GetOneCompany(id);
            return company == null ? (ActionResult<CompanyReadDto>)NotFound() : (ActionResult<CompanyReadDto>)Ok(company);
        }

        [HttpPost]
        public ActionResult<CompanyReadDto> Create(CompanyWriteDto company)
        {
            var currentUser = User.Identity!.Name;
            if (string.IsNullOrEmpty(currentUser))
                return BadRequest();
            var created = _service.Create(company, by: currentUser);
            return created == null ? (ActionResult<CompanyReadDto>)BadRequest() : (ActionResult<CompanyReadDto>)Ok(created);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var company = _service.GetCompanyById(id);
            if (company == null)
                return NotFound();
            _service.Delete(company);
            _changesHandler.Save();
            var deleted = _service.GetCompanyById(id);
            return deleted != null ? StatusCode(500) : (IActionResult)Ok();
        }

        [HttpPut("{id:guid}")]
        public ActionResult<CompanyReadDto> Update(Guid id, [FromBody] CompanyUpdateDto request)
        {
            try
            {
                var company = _service.GetCompanyById(id);
                if (company == null)
                    return NotFound();

                company.UpdatedOn = DateTime.Now;
                if (request.IsSme != null)
                    company.IsSme = (bool)request.IsSme;
                if (!string.IsNullOrEmpty(request.City))
                    company.City = request.City;
                if (!string.IsNullOrEmpty(request.FieldOfActivity))
                    company.FieldOfActivity = request.FieldOfActivity;
                if (!string.IsNullOrEmpty(request.Name))
                    company.Name = request.Name;

                _service.Update(company);

                var updated = _service.GetOneCompany(id);

                return Ok(updated);

            }
            catch (Exception)
            {
                return BadRequest();
            }
        }
    }
}
