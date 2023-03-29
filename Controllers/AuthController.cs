using Microsoft.AspNetCore.Mvc;
using Login.Data.DTO.Request;
using Login.Data.DTO.Response;
using Login.Data.Enum;
using Login.Data.Generic;
using Login.Data.Models;
//using Login.Services.AuthServices;
//using Login.Utils.Extensions;
//using Login.Utils.Filters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net;

namespace Login.Controllers;

[ApiController]
[Route("/api/auth")]
[Produces("application/json")]
public class AuthController : ControllerBase
{


}