namespace theFinale.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VaultKeepsController : ControllerBase
    {
        private readonly VaultsService _vs;
        private readonly KeepsService _ks;
        private readonly Auth0Provider _auth;

        private readonly VaultKeepsService _vks;

        public VaultKeepsController(VaultsService vs, KeepsService ks, Auth0Provider auth, VaultKeepsService vks)
        {
            _vs = vs;
            _ks = ks;
            _auth = auth;
            _vks = vks;
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<VaultKeep>> CreateVaultKeep([FromBody] VaultKeep vkData)
        {
            try
            {
                Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
                vkData.creatorId = userInfo.Id;

                VaultKeep newVk = _vks.CreateVaultKeep(vkData);
                return new ActionResult<VaultKeep>(Ok(newVk));
            }
                catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}