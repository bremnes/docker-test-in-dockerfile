using CalculatorLogic;
using Microsoft.AspNetCore.Mvc;

namespace CalculatorWeb.Controllers
{
    [Produces("application/json")]
    [Route("api/Calculator")]
    public class CalculatorController : Controller
    {
        private readonly Addition _addition;

        public CalculatorController(Addition addition)
        {
            _addition = addition;
        }

        [HttpGet("add/{number1}/{number2}")]
        public int Add(int number1, int number2)
        {
            return _addition.AddNumbers(number1, number2);
        }
    }
}