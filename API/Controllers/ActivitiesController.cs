using System;
using Application.Activities.Commands;
using Application.Activities.Queries;
using Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace API.Controllers;

public class ActivitiesController : BaseApiController
{

    // private readonly AppDbContext _context;
    // private readonly IMediator _mediator;

    // public ActivitiesController(AppDbContext context, IMediator mediator)
    // {
    //     _context = context;
    //     _mediator = mediator;
    // }
    [HttpGet]
    public async Task<ActionResult<List<Activity>>> GetActivities()
    {
        //return await context.Activities.ToListAsync();
        return await Mediator.Send(new GetActivityList.Query());
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Activity>> GetActivitiesDetail(string id)
    {
        // var activity = await _context.Activities.FindAsync(id);
        // if (activity == null) return NotFound();

        // return activity;
        return await Mediator.Send(new GetActivityDetails.Query { Id = id });
    }

    [HttpPost]
    public async Task<ActionResult<string>> CreateActivity(Activity activity)
    {
        return await Mediator.Send(new CreateActivity.Command { Activity = activity });
    }

    [HttpPut]
    public async Task<ActionResult> EditActivity(Activity activity)
    {
        await Mediator.Send(new EditActivity.Command { Activity = activity });
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteActivity(string id)
    {
        await Mediator.Send(new DeleteActivity.Command{ Id = id });

        return Ok();
    }
}
