namespace theFinale.Services
{
  public class ProfilesServices
  {
    private readonly ProfilesRepository _repo;

    public ProfilesServices(ProfilesRepository repo)
    {
      _repo = repo;
    }

    internal List<Keep> GetUserKeeps(string profileId)
    {
      List<Keep> keeps = _repo.GetUserKeeps(profileId);
      return keeps;
    }

    internal Profile GetUserProfile(string profileId)
    {
      Profile profile = _repo.GetUserProfile(profileId);
      if (profile == null) throw new Exception("Invalid Id");
      return profile;
    }

    internal List<Vault> GetUserVaults(string profileId, string userId)
    {
      List<Vault> vaults = _repo.GetUserVaults(profileId, userId);
      return vaults;
    }
  }
}