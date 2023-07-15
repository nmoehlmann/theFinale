namespace theFinale.Repositories
{
    public class ProfilesRepository
    {
        private readonly IDbConnection _db;

        public ProfilesRepository(IDbConnection db)
        {
            _db = db;
        }

        internal List<Keep> GetUserKeeps(string profileId)
        {
            string sql = @"
            SELECT
            k.*,
            act.*
            FROM keeps k
            JOIN accounts act ON act.id = @profileId
            WHERE k.creatorId = @profileId
            ;";

            List<Keep> keeps = _db.Query<Keep, Account, Keep>(sql, (keep, creator) => {
                keep.creator = creator;
                return keep;
            }, new {profileId}).ToList();
            return keeps;
        }

        internal Profile GetUserProfile(string profileId)
        {
            string sql = @"
            SELECT * FROM accounts WHERE id = @profileId
            ;";

            Profile profile = _db.Query<Profile>(sql, new {profileId}).FirstOrDefault();
            return profile;
        }

        internal List<Vault> GetUserVaults(string profileId)
        {
            string sql = @"
            SELECT
            v.*,
            act.*
            FROM vaults v
            JOIN accounts act ON act.id = @profileId
            WHERE v.creatorId = @profileId
            ;";

            List<Vault> vaults = _db.Query<Vault, Account, Vault>(sql, (vault, creator) => {
                vault.creator = creator;
                return vault;
            }, new {profileId}).ToList();
            return vaults;
        }
    }

}