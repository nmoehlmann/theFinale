namespace theFinale.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vkData, string vaultCreatorId)
        {
            if(vkData.creatorId != vaultCreatorId) throw new Exception("Unauthorized");
            VaultKeep newVk = _repo.CreateVaultKeep(vkData);
            return newVk;
        }

        internal VaultKeep GetVkById(int vkId)
        {
            VaultKeep vk = _repo.GetVkById(vkId);
            if(vk == null) throw new Exception("Invalid Id");
            return vk;
        }

        internal VaultKeep DeleteVaultKeep(int vaultKeepId, string userId)
        {
            VaultKeep foundVk = GetVkById(vaultKeepId);
            if(foundVk.creatorId != userId) throw new Exception("Unauthorized to delete this VaultKeep");

            int rows = _repo.DeleteVaultKeep(vaultKeepId);
            return foundVk;
        }

        internal List<vk> GetVksByVaultId(int vaultId, Vault vault)
        {
            if(vault.isPrivate == true) throw new Exception("This vault is private");
            List<vk> vks = _repo.GetVksByVaultId(vaultId);
            return vks;
        }
    }
}