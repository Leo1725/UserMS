using MediatR;
using Microsoft.AspNetCore.Mvc;
using UserMS.Application.Commands;
using UserMS.Application.Querys;
using UserMS.Commons.Dtos.Request;

namespace UserMS.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OperatorController : ControllerBase
    {
        private readonly ILogger<OperatorController> _logger;
        private readonly IMediator _mediator;

        public OperatorController(ILogger<OperatorController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOperator(CreateOperatorDto createOperatorDto)
        {
            try
            {
                var command = new CreateOperatorCommand(createOperatorDto);
                var operatorId = await _mediator.Send(command);
                return Ok(operatorId);
            }
            catch (Exception e)
            {
                _logger.LogError("An error occurred while trying to create an operator {Message}", e.Message);
                return StatusCode(500, "An error occurred while trying to create an operator");
            }
        }

        [HttpPut]

        public async Task<IActionResult> UpdateOperator(UpdateOperatorDto updateOperatorDto)
        {
            try
            {
                var command = new UpdateOperatorCommand(updateOperatorDto);
                var msg = await _mediator.Send(command);
                return Ok(msg);


            }
            catch (Exception e) {

                _logger.LogError("An error occurred while trying to update an operator {Message}", e.Message);
                return StatusCode(500, "An error occurred while trying to update an operator");

            }

        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetOperator(Guid Id)
        {
            try
            {
                var query = new GetOperatorQuery(Id);
                var op = await _mediator.Send(query);
                return Ok(op);
            }
            catch (Exception e)
            {
                _logger.LogError(e, "An error occurred while getting operators {Message}", e.Message);
                return StatusCode(500, "An error occurred while getting operator.");
            }
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> DeleteOperatorById(Guid Id) {
            try
            {
                var command = new DeleteOperatorCommand(Id);
                var operatorId = await _mediator.Send(command);
                return Ok(operatorId);
            }
            catch (Exception e) {
                _logger.LogError("An error occurred while trying to delete an operator {Message}", e.Message);
                return StatusCode(500, "An error occurred while trying to delete an operator");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetAllOperators() {
            try
            {
                var query = new GetAllOperatorsQuery();
                var operators = await _mediator.Send(query);
                return Ok(operators);
            }
            catch (Exception e) {
                _logger.LogError(e, "An error occurred while getting operators {Message}", e.Message);
                return StatusCode(500, "An error occurred while getting operator.");
            }
        }

    }
}
