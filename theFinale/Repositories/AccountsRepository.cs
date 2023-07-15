namespace theFinale.Repositories;

public class AccountsRepository
{
  private readonly IDbConnection _db;

  public AccountsRepository(IDbConnection db)
  {
    _db = db;
  }

  internal Account GetByEmail(string userEmail)
  {
    string sql = "SELECT * FROM accounts WHERE email = @userEmail";
    return _db.QueryFirstOrDefault<Account>(sql, new { userEmail });
  }

  internal Account GetById(string id)
  {
    string sql = "SELECT * FROM accounts WHERE id = @id";
    return _db.QueryFirstOrDefault<Account>(sql, new { id });
  }

  internal Account Create(Account newAccount)
  {
    string sql = @"
            INSERT INTO accounts
              (name, picture, email, id)
            VALUES
              (@Name, @Picture, @Email, @Id)";
    _db.Execute(sql, newAccount);
    return newAccount;
  }

  internal Account Edit(Account update)
  {
    string sql = @"
            UPDATE accounts
            SET 
              name = @Name,
              picture = @Picture
            WHERE id = @Id;";
    _db.Execute(sql, update);
    return update;
  }

    internal List<Vault> GetMyVaults(string userId)
    {
        string sql = @"
        SELECT
        v.*,
        act.*
        FROM vaults v
        JOIN accounts act ON act.id = @userId
        WHERE v.creatorId = @userId
        ;";

        List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, creator) => {
          vault.creator = creator;
          return vault;
        }, new {userId}).ToList();
        return vaults;
    }
}

