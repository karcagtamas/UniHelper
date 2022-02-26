using System.Collections.Generic;
using KarcagS.Common.Tools.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UniHelper.Backend.Entities;
using UniHelper.Backend.Services.Interfaces;
using UniHelper.Shared.DTOs;
using UniHelper.Shared.Models;

namespace UniHelper.Backend.Controllers;

/// <summary>
/// Period Controller
/// </summary>
[Route("api/periods")]
[ApiController]
[Authorize]
public class PeriodController : MapperController<Period, int, PeriodModel, PeriodDto>
{
    private readonly IPeriodService _service;

    /// <summary>
    /// Period Controller
    /// </summary>
    public PeriodController(IPeriodService service) : base(service)
    {
        _service = service;
    }

    /// <summary>
    /// Get current Period
    /// </summary>
    /// <returns></returns>
    [HttpGet("current")]
    public int GetCurrent()
    {
        return _service.GetCurrent();
    }

    /// <summary>
    /// Set current Period by Id
    /// </summary>
    /// <param name="id">Period Id</param>
    [HttpPut("current")]
    public void SetCurrent([FromBody] int id)
    {
        _service.SetCurrent(id);
    }

    /// <summary>
    /// Get user's period list
    /// </summary>
    /// <returns>List of periods</returns>
    [HttpGet("my")]
    public List<PeriodDto> GetUserPeriodList()
    {
        return _service.GetUserPeriodList();
    }
}
