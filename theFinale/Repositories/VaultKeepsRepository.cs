namespace theFinale.Repositories
{
    public class VaultKeepsRepository
    {
        private readonly IDbConnection _db;

        public VaultKeepsRepository(IDbConnection db)
        {
            _db = db;
        }

        internal VaultKeep CreateVaultKeep(VaultKeep vkData)
        {
            string sql = @"
            INSERT INTO vaultKeeps
            (creatorId, vaultId, keepId)
            VALUES
            (@creatorId, @vaultId, @keepId);

            SELECT
            vk.*
            FROM vaultKeeps vk
            WHERE vk.id = LAST_INSERT_ID();
            ;";

            VaultKeep newVk = _db.Query<VaultKeep>(sql, vkData).FirstOrDefault();
            return newVk;
        }

        internal List<VaultKeep> GetVksByVaultId(int vaultId)
        {
            string sql = @"
            SELECT * FROM vaultKeeps vk
            JOIN accounts act ON vk.creatorId = act.id
            WHERE vk.vaultId = @vaultId
            ;";

            List<VaultKeep> vks = _db.Query<VaultKeep, Account, VaultKeep>(sql, (vk, act) => {
                vk.creator = act;
                // this is only here for postman
                vk.vaultKeepId = vk.id;
                return vk;
            }, new {vaultId}).ToList();
            return vks;
        }
    }
}