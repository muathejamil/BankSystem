using System.Threading.Tasks;
using BankTask_BackEnd.Data;
using BankTask_BackEnd.Models;
using BankTask_BackEnd.Services;
using BankTask_BackEnd.Services.Repositories;
using Microsoft.AspNetCore.Mvc;
namespace BankTask_BackEnd.Controllers
{
    [Route("api/[controller]")]
    public class BankController : Controller
    {


        private readonly IBankService _bankService;
        private static ApplicationDbContext _context;

        public BankController(ApplicationDbContext context,
                              IBankService bankService)
        {

            _context = context;
            StaticDbContext.InitialDBContext(_context);
            _bankService = bankService;
        }

        #region GetAll
        [HttpGet("GetBank")]
        public async Task<IActionResult> GetBank()
        {
            return Ok(await _bankService.GetBank());
        }







        #endregion

        #region GetByID




        #endregion

        #region Add





        #endregion

        #region Update



        #endregion

        #region Delete



        #endregion



    }
}
