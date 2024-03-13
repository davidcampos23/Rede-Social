using Microsoft.AspNetCore.Mvc;

namespace backend.Controller;

[ApiController, Route(template:"api/[controller]")]
public class UserController : ControllerBase
{
    [HttpGet]
    public string HelloWorld() => "Hello World";
}