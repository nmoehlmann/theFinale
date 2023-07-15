namespace theFinale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProfilesController : ControllerBase
    {
        private readonly ProfilesServices _ps;

        public ProfilesController(ProfilesServices ps)
        {
            _ps = ps;
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
        public ActionResult<List<Vault>> GetUserVaults(string profileId)
        {
            try
            {
                List<Vault> vaults = _ps.GetUserVaults(profileId);
                return Ok(vaults);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
        

    }
}