namespace theFinale.Repositories
{
  public class KeepsRepository
  {
    private readonly IDbConnection _db;

    public KeepsRepository(IDbConnection db)
    {
      _db = db;
    }

    internal Keep CreateKeep(Keep keepData)
    {
      string sql = @"
      INSERT INTO keeps
      (Name, Description, Img, creatorId)
      VALUES
      (@Name, @Description, @Img, @creatorId);

      SELECT
      k.*,
      creator.*
      FROM keeps k
      JOIN accounts creator ON k.creatorId = creator.id
      WHERE k.id = LAST_INSERT_ID();
      ;";

      Keep newKeep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
      {
        keep.creator = creator;
        return keep;
      }, keepData).FirstOrDefault();
      return newKeep;
    }


    internal List<Keep> GetAllKeeps()
    {
      string sql = @"
      SELECT
      k.*,
      creator.*
      FROM keeps k
      JOIN accounts creator ON k.creatorId = creator.id
      ;";

      List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
      {
        keep.creator = creator;
        return keep;
      }).ToList();
      return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
      string sql = @"
      SELECT
      k.*,
      creator.*
      FROM keeps k
      JOIN accounts creator ON k.creatorId = creator.id
      WHERE k.id = @keepId
      ;";

      Keep keep = _db.Query<Keep, Account, Keep>(sql, (keep, creator) =>
      {
        keep.creator = creator;
        return keep;
      }, new { keepId }).FirstOrDefault();
      return keep;
    }

    internal void UpdateKeep(Keep updateData)
    {
      string sql = @"
      UPDATE keeps SET
      name = @name,
      description = @description,
      img = @img
      ;";
      _db.Execute(sql, updateData);
    }
    internal int DeleteKeep(int keepId)
    {
      string sql = @"DELETE FROM keeps WHERE id = @keepId LIMIT 1 ;";
      int rows = _db.Execute(sql, new { keepId });
      return rows;
    }
  }
}