namespace theFinale.Repositories
{
  public class VaultsRepository
  {
    private readonly IDbConnection _db;

    public VaultsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Vault CreateVault(Vault vaultData)
    {
      string sql = @"
      INSERT INTO vaults
      (Name, Description, Img, isPrivate, creatorId)
      VALUES
      (@Name, @Description, @Img, @isPrivate, @creatorId);

      SELECT
      v.*,
      creator.*
      FROM vaults v
      JOIN accounts creator ON v.creatorId = creator.id
      WHERE v.id = LAST_INSERT_ID();
      ;";

      Vault newVault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
      {
        vault.creator = creator;
        return vault;
      }, vaultData).FirstOrDefault();
      return newVault;
    }

    internal Vault GetVaultById(int vaultId)
    {
      string sql = @"
      SELECT
      v.*,
      creator.*
      FROM vaults v
      JOIN accounts creator ON v.creatorId = creator.id
      WHERE v.id = @vaultId
      ;";

      Vault vault = _db.Query<Vault, Account, Vault>(sql, (vault, creator) =>
      {
        vault.creator = creator;
        return vault;
      }, new { vaultId }).FirstOrDefault();
      return vault;
    }

    internal void UpdateVault(Vault updateData)
    {
      string sql = @"
      UPDATE vaults SET
      name = @name,
      description = @description,
      img = @img,
      isPrivate = @isPrivate
      ;";
      _db.Execute(sql, updateData);
    }
  }
}