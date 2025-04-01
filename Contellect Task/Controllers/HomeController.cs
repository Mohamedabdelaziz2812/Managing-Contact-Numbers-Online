using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Contellect_Task.Controllers;
[Authorize]
public class HomeController : BaseController<HomeController>
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }


    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create([FromBody] CreateContactCommand query, CancellationToken token)
    {
        var result = await Mediator.Send(query, token);

        if (result.IsFailure)
            return RedirectToError404();

        return Ok(result.Value);
    }


    [HttpPost]
    public async Task<IActionResult> Update([FromBody] UpdateContactCommand query, CancellationToken token)
    {
        var result = await Mediator.Send(query, token);

        if (result.IsFailure)
            return RedirectToError404();

        return Ok(result.Value);
    }



    [HttpPost]
    public async Task<IActionResult> GetContactDataTable([FromForm] GetAllContactDataTableQuery query, CancellationToken token)
    {
        var result = await Mediator.Send(query, token);

        if (result.IsFailure)
            return RedirectToError404();

        return Ok(result.Value);
    }


    [HttpDelete]
    public async Task<IActionResult> Delete(int Id, CancellationToken token)
    {
        var result = await Mediator.Send(new DeleteContactCommand { Id = Id }, token);

        if (result.IsFailure)
            return RedirectToError404();

        return Ok(result.Value);
    }
}
