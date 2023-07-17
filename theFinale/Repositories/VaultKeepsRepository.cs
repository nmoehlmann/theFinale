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
      int rows = _db.Execute(sql, new { vaultKeepId });
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

      VaultKeep vk = _db.Query<VaultKeep>(sql, new { vkId }).FirstOrDefault();
      return vk;
    }

    internal List<vk> GetVksByVaultId(int vaultId)
    {
      string sql = @"
            SELECT
            vk.*,
            k.*,
            creator.*
            FROM vaultKeeps vk
            JOIN keeps k ON k.id = vk.keepId
            JOIN accounts creator ON creator.id = vk.creatorId
            WHERE vk.vaultId = @vaultId;
            ;";

      List<vk> vks = _db.Query<VaultKeep, vk, Account, vk>(sql, (vaultkeep, vk, creator) =>
      {
        vk.vaultKeepId = vaultkeep.id;
        vk.creator = creator;
        // vk.creatorId = creator.Id;
        return vk;
      }, new { vaultId }).ToList();
      return vks;

    }
  }
}