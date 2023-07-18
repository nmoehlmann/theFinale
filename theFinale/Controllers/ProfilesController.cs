namespace theFinale.Controllers
{
  [ApiController]
  [Route("api/[controller]")]
  public class ProfilesController : ControllerBase
  {
    private readonly ProfilesServices _ps;
    private readonly Auth0Provider _auth;

    public ProfilesController(ProfilesServices ps, Auth0Provider auth)
    {
      _ps = ps;
      _auth = auth;
    }

    [HttpGet("{profileId}")]
    public ActionResult<Profile> GetUserProfile(string profileId)
    {
      try
      {
        Profile profile = _ps.GetUserProfile(profileId);
        return Ok(profile);
      }
      catch (Exception e)
      {
        return new ActionResult<Profile>(BadRequest(e.Message));
      }
    }

    [HttpGet("{profileId}/keeps")]
    public ActionResult<List<Keep>> GetUserKeeps(string profileId)
    {
      try
      {
        List<Keep> keeps = _ps.GetUserKeeps(profileId);
        return Ok(keeps);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{profileId}/vaults")]
    public async Task<ActionResult<List<Vault>>> GetUserVaults(string profileId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

        List<Vault> vaults = _ps.GetUserVaults(profileId, userInfo?.Id);
        return Ok(vaults);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }


  }
}