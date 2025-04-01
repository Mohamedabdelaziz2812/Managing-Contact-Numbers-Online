using Microsoft.AspNetCore.Mvc;

namespace Contellect_Task.Controllers;

public abstract class BaseController<T> : Controller where T : BaseController<T>
{

    private IWebHostEnvironment _env;
    public IWebHostEnvironment Env => _env ?? (_env = HttpContext?.RequestServices.GetService<IWebHostEnvironment>());

    private IMediator _mediator;
    protected IMediator Mediator => _mediator ?? (_mediator = HttpContext.RequestServices.GetService<IMediator>());

    private Globals _Global;
    protected Globals Global => _Global ?? (_Global = HttpContext.RequestServices.GetService<Globals>());

    private ILogger _logger;
    protected ILogger Logger => _logger ?? (_logger = HttpContext.RequestServices.GetService<ILogger>());




    //private BaseManager _baseManager;
    //protected BaseManager BaseManager => _baseManager ?? (_baseManager = HttpContext?.RequestServices.GetService<BaseManager>());




    protected IActionResult RedirectToError404() =>
        RedirectToAction("Error404", "Home", new { area = "" });
    protected IActionResult RedirectToError400() =>
        RedirectToAction("Error400", "Home", new { area = "" });

    //protected async Task<IActionResult> HandleMVCFailure<TRequest, TValue>(Result<TRequest> result, TValue value = default, string viewName = null)
    //{
    //    try
    //    {
    //        if (result.IsSuccess)
    //            throw new InvalidOperationException();
    //        if (Request.HasFormContentType)
    //            if (Request.Form?.Count > 0)
    //            {
    //                var formContent = await Request.ReadFromJsonAsync(typeof(object));
    //                Agent.Tracer.CaptureErrorLog(new ErrorLog($"{nameof(ControllerContext.ActionDescriptor.ActionName)} Failure, Request Form: {formContent}"));
    //            }
    //    }
    //    catch { }

    //    switch (result.Error)
    //    {
    //        case var error when error == BaseErrors.NotFound:
    //            return RedirectToError404();
    //        case var error when error == BaseErrors.ExceptionHappened:
    //            return RedirectToError400();
    //        default:
    //            MapErrorsToModelStates(result);

    //            if (!string.IsNullOrEmpty(viewName))
    //                return View(viewName, value);
    //            else
    //                return View(value);
    //    }
    //}
    //protected async Task<IActionResult> HandleAPIFailure<TValue>(Result<TValue> result)
    //{
    //    try
    //    {
    //        if (Request.HasFormContentType)
    //            if (Request.Form?.Count > 0)
    //            {
    //                var formContent = await Request.ReadFromJsonAsync(typeof(object));
    //                Agent.Tracer.CaptureErrorLog(new ErrorLog($"{nameof(ControllerContext.ActionDescriptor.ActionName)} Failure, Request Form: {formContent}"));
    //            }
    //    }
    //    catch { }
    //    return result switch
    //    {
    //        { IsSuccess: true } => throw new InvalidOperationException(),

    //        _ when result.Error == BaseErrors.NotFound => NotFound(),
    //        _ when result.Error == BaseErrors.ExceptionHappened => BadRequest(),
    //        _ =>
    //            new ObjectResult(CreateProblemDetails(result))
    //            {
    //                StatusCode = 405
    //            }
    //    };
    //}

    //private void MapErrorsToModelStates<TValue>(Result<TValue> result)
    //{
    //    ModelState.Clear();
    //    if (result.Error == BaseErrors.ValidationError)
    //    {
    //        var validationResult = result as IValidationResult;
    //        foreach (var error in validationResult.Errors)
    //        {
    //            ModelState.AddModelError(error.Code, error.Message);
    //        }
    //    }
    //    else
    //    {
    //        ModelState.AddModelError(result.Error.Code, result.Error.Message);
    //    }
    //}

    //private static IReadOnlyList<Error> CreateProblemDetails<TValue>(Result<TValue> result)
    //{
    //    if (result.Error == BaseErrors.ValidationError)
    //    {
    //        var validationResult = result as IValidationResult;
    //        return validationResult.Errors;
    //    }
    //    else
    //    {
    //        return new List<Error>() { result.Error };
    //    }
    //}

    //public async Task SetSiteSettingsClaim(SiteSettings CurrentSiteSettings)
    //{
    //    ((ClaimsIdentity)User.Identity).RemoveClaim(((ClaimsIdentity)User.Identity).FindFirst("SiteSettings"));//Remove old Claim
    //    ((ClaimsIdentity)User.Identity).AddClaim(new Claim("SiteSettings", JsonConvert.SerializeObject(CurrentSiteSettings))); //Add
    //    var authenticationProperties = new AuthenticationProperties()
    //    {
    //        IssuedUtc = ((ClaimsIdentity)User.Identity).Claims.First(c => c.Type == JwtRegisteredClaimNames.Iat)?.Value.ToInt64().ToUnixEpochDate(),
    //        ExpiresUtc = DateTimeOffset.UtcNow.Add(TimeSpan.FromDays(1)),
    //        IsPersistent = true,
    //        AllowRefresh = true,

    //    };
    //    await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, HttpContext.User, authenticationProperties);
    //}

    public string BaseUrl { get { return $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}"; } }
}