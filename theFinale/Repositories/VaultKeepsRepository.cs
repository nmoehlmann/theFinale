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

        internal int DeleteVaultKeep(int vaultKeepId)
        {
            string sql = @"DELETE FROM vaultKeeps WHERE id = @vaultKeepId LIMIT 1;";
            int rows = _db.Execute(sql, new {vaultKeepId});
            return rows;
        }

        internal VaultKeep GetVkById(int vkId)
        {
            string sql = @"
            SELECT
            *
            FROM vaultKeeps
            WHERE id = @vkId
            ;";

            VaultKeep vk = _db.Query<VaultKeep>(sql, new {vkId}).FirstOrDefault();
            return vk;
            }

        internal List<vk> GetVksByVaultId(int vaultId)
        {
            string sql = @"
            SELECT
            vaultkeep.*,
            keep.*,
            creator.*
            FROM vaultKeeps vaultkeep
            JOIN keeps keep ON keep.id = vaultkeep.keepId
            JOIN accounts creator ON creator.id = vaultkeep.creatorId
            WHERE vaultkeep.vaultId = @vaultId
            ;";

            List<vk> vks = _db.Query<VaultKeep, Account, vk, vk>(sql, (vaultkeep, creator, vk) => {
                vk.vaultKeepId = vaultkeep.id;
                vk.creator = creator;
                return vk;
            }, new {vaultId}).ToList();
            return vks;
        }
    }
}