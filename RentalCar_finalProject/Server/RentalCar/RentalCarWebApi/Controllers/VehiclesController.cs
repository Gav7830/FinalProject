using DAL;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RentalCarWebApi.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class VehiclesController : ControllerBase
    {
        RentalCarDbContext _RentalCarDbContext;

        public VehiclesController(RentalCarDbContext rentalCarDbContext)
        {
            _RentalCarDbContext = rentalCarDbContext;
        }

    }
}
