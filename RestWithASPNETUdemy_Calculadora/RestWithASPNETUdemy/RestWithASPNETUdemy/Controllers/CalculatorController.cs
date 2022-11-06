using Microsoft.AspNetCore.Mvc;

namespace RestWithASPNETUdemy.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CalculatorController : ControllerBase
    {

        private readonly ILogger<CalculatorController> _logger;

        public CalculatorController(ILogger<CalculatorController> logger)
        {
            _logger = logger;
        }

        [HttpGet("{operador}/{firstNumber}/{secondNumber}")]
        public IActionResult Get(string operador, string firstNumber, string secondNumber)
        {

            if (IsNumeric(secondNumber) && IsNumeric(firstNumber))
            {

                if (operador == "sum")
                {
                    var res = ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber);

                    return Ok(res.ToString());
                }
                else if(operador == "sub")
                {
                    var res = ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber);

                    return Ok(res.ToString());
                }
                else if (operador == "div")
                {
                    var res = ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber);

                    return Ok(res.ToString());
                }
                else if (operador == "mul")
                {
                    var res = ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber);

                    return Ok(res.ToString());
                }

            }
            
            return BadRequest("Invalid input");

        }




        private bool IsNumeric(string strNumber)
        {

            double number;

            bool isNumber = double.TryParse(
                strNumber, 
                System.Globalization.NumberStyles.Any, 
                System.Globalization.NumberFormatInfo.InvariantInfo, out number);

            return isNumber;

        }

        private decimal ConvertToDecimal(string strNumber)
        {

            decimal decimalValue;

            if(decimal.TryParse(strNumber, out decimalValue))
            {
                return decimalValue;    
            }

            return 0;
        }

        
    }
}