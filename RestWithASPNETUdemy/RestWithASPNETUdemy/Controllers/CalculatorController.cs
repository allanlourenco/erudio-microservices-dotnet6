using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace RestWithASPNETUdemy.Controllers;

[ApiController]
[Route("[controller]")]
public class CalculatorController : ControllerBase
{
    private readonly ILogger<CalculatorController> _logger;

    public CalculatorController(ILogger<CalculatorController> logger)
    {
        _logger = logger;
    }

    [HttpGet("sum/{firstNumber}/{secondNumber}")]
    public IActionResult GetSum(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            return Ok(ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber));

        return BadRequest("Invalid Input");
    }

    [HttpGet("subtraction/{firstNumber}/{secondNumber}")]
    public IActionResult GetSubtraction(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            return Ok(ConvertToDecimal(firstNumber) - ConvertToDecimal(secondNumber));

        return BadRequest("Invalid Input");
    }

    [HttpGet("multiplication/{firstNumber}/{secondNumber}")]
    public IActionResult GetMultiplication(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            return Ok(ConvertToDecimal(firstNumber) * ConvertToDecimal(secondNumber));

        return BadRequest("Invalid Input");
    }

    [HttpGet("division/{firstNumber}/{secondNumber}")]
    public IActionResult GetDivision(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            return Ok(ConvertToDecimal(firstNumber) / ConvertToDecimal(secondNumber));

        return BadRequest("Invalid Input");
    }

    [HttpGet("average/{firstNumber}/{secondNumber}")]
    public IActionResult GetAverage(string firstNumber, string secondNumber)
    {
        if (IsNumeric(firstNumber) && IsNumeric(secondNumber))
            return Ok((ConvertToDecimal(firstNumber) + ConvertToDecimal(secondNumber)) / 2);

        return BadRequest("Invalid Input");
    }

    [HttpGet("squareroot/{firstNumber}")]
    public IActionResult GetSquareRoot(string firstNumber)
    {
        if (IsNumeric(firstNumber))
            return Ok(Math.Sqrt(ConvertToDouble(firstNumber)));

        return BadRequest("Invalid Input");
    }

    private double ConvertToDouble(string number)
    {
        return double.Parse(number.ToString());
    }

    private decimal ConvertToDecimal(string number)
    {
        return decimal.Parse(number.ToString());    
    }

    private bool IsNumeric(string number)
    {
        double numberValidate;
        return double.TryParse(number, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.InvariantInfo, out numberValidate);
    }
}
