namespace theFinale.Controllers
{
  [ApiController]
  [Route("api/keeps")]
  public class KeepsController : ControllerBase
  {
    private readonly KeepsService _keepsService;
    private readonly Auth0Provider _auth;

    public KeepsController(KeepsService keepsService, Auth0Provider auth)
    {
      _keepsService = keepsService;
      _auth = auth;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Keep>> CreateKeep([FromBody] Keep keepData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        keepData.creatorId = userInfo.Id;

        Keep newKeep = _keepsService.CreateKeep(keepData);
        return new ActionResult<Keep>(Ok(newKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet]
    public ActionResult<List<Keep>> GetAllKeeps()
    {
      try
      {
        List<Keep> keeps = _keepsService.GetAllKeeps();
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{keepId}")]
    public ActionResult<Keep> GetKeepById(int keepId)
    {
      try
      {
        Keep keep = _keepsService.GetKeepById(keepId);
        return Ok(keep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpPut("{keepId}")]
    [Authorize]
    public async Task<ActionResult<Keep>> UpdateKeep(int keepId, [FromBody] Keep updateData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

        updateData.id = keepId;
        Keep updatedKeep = _keepsService.UpdateKeep(updateData, userInfo, keepId);
        return new ActionResult<Keep>(Ok(updatedKeep));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{keepId}")]
    [Authorize]

    public async Task<ActionResult<Keep>> DeleteKeep(int keepId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        Keep deletedKeep = _keepsService.DeleteKeep(keepId, userInfo.Id);
        return Ok(deletedKeep);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

  }
}