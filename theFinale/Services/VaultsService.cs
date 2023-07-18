namespace theFinale.Services
{
  public class VaultsService
  {
    private readonly VaultsRepository _repo;

    public VaultsService(VaultsRepository repo)
    {
      _repo = repo;
    }

    internal Vault CreateVault(Vault vaultData)
    {
      Vault newVault = _repo.CreateVault(vaultData);
      return newVault;
    }

    internal Vault DeleteVault(int vaultId, string userId)
    {
      Vault foundVault = GetVaultById(vaultId, userId);
      if (foundVault.creatorId != userId) throw new Exception("Unauthorized to delete vault");

      int rows = _repo.DeleteVault(vaultId);
      return foundVault;
    }

    internal Vault GetVaultById(int vaultId, string userId)
    {
      Vault vault = _repo.GetVaultById(vaultId);
      if (vault == null) throw new Exception("Invalid Id");

      if (vault.isPrivate == true && userId != vault.creatorId)
      {
        throw new Exception("This vault is private and you are not the owner!");
      }

      return vault;
    }

    internal Vault updateVault(Vault updateData, string userId, int vaultId)
    {
      Vault foundVault = GetVaultById(vaultId, userId);
      updateData.creatorId = foundVault.creatorId;

      if (updateData.creatorId != userId) throw new Exception("Unauthorized to edit this vault");

      Vault original = foundVault;

      original.name = updateData.name != null ? updateData.name : original.name;

      original.description = updateData.description != null ? updateData.description : original.description;

      original.img = updateData.img != null ? updateData.img : original.img;

      original.isPrivate = updateData.isPrivate;

      _repo.UpdateVault(original);
      return original;
    }
  }
}