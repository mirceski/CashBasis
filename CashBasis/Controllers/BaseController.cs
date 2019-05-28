using CashBasis.DAL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CashBasis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
        private IUnitOfWork _unitOfWork { get; set; }
        
        protected IUnitOfWork UnitOfWork => _unitOfWork ?? (_unitOfWork = HttpContext.RequestServices.GetService<IUnitOfWork>());
        
    }
}
