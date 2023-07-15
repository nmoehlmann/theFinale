namespace theFinale.Services
{
    public class VaultKeepsService
    {
        private readonly VaultKeepsRepository _repo;

        public VaultKeepsService(VaultKeepsRepository repo)
        {
            _repo = repo;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vkData)
        {
            VaultKeep newVk = _repo.CreateVaultKeep(vkData);
            return newVk;
        }
    }
}