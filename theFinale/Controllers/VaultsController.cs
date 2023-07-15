namespace theFinale.Controllers
{
  [ApiController]
  [Route("api/vaults")]
  public class VaultsController : ControllerBase
  {
    private readonly VaultsService _vs;

    private readonly Auth0Provider _auth;
    private readonly VaultKeepsService _vks;

    public VaultsController(VaultsService vs, Auth0Provider auth, VaultKeepsService vks)
    {
      _vs = vs;
      _auth = auth;
      _vks = vks;
    }

    [HttpPost]
    [Authorize]
    public async Task<ActionResult<Vault>> CreateVault([FromBody] Vault vaultData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);
        vaultData.creatorId = userInfo.Id;

        Vault newVault = _vs.CreateVault(vaultData);
        return new ActionResult<Vault>(Ok(newVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}")]
    public ActionResult<Vault> GetVaultById(int vaultId)
    {
      try
      {
        Vault vault = _vs.GetVaultById(vaultId);
        return Ok(vault);
      }
      catch (Exception e)
      {
        return new ActionResult<Vault>(BadRequest(e.Message));
      }
    }

    [HttpPut("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> UpdateVault(int vaultId, [FromBody] Vault updateData)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

        updateData.id = vaultId;
        Vault updatedVault = _vs.updateVault(updateData, userInfo.Id, vaultId);
        return new ActionResult<Vault>(Ok(updatedVault));
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpDelete("{vaultId}")]
    [Authorize]
    public async Task<ActionResult<Vault>> DeleteVault(int vaultId)
    {
      try
      {
        Account userInfo = await _auth.GetUserInfoAsync<Account>(HttpContext);

        Vault deletedVault = _vs.DeleteVault(vaultId, userInfo.Id);
        return Ok(deletedVault);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }

    [HttpGet("{vaultId}/keeps")]
    public ActionResult<List<VaultKeep>> GetVksByVaultId(int vaultId)
    {
      try
      {
        List<VaultKeep> vks = _vks.GetVksByVaultId(vaultId);
        return Ok(vks);
      }
      catch (Exception e)
      {
        return BadRequest(e.Message);
      }
    }
  }
}