﻿using Asp.Versioning;
using Microsoft.AspNetCore.Mvc;

namespace Backend.API.Controllers.v1
{
    [Route("api/v{v:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion(1)]
    public class BaseApiController : ControllerBase
    {
    }
}
