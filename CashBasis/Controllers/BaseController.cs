using CashBasis.DAL.Interfaces;
using CashBasis.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace CashBasis.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public abstract class BaseController : Controller
    {
    }
}
