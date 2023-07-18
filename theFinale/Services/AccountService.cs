namespace theFinale.Services;

public class AccountService
{
  private readonly AccountsRepository _repo;

  public AccountService(AccountsRepository repo)
  {
    _repo = repo;
  }

  internal Account GetProfileByEmail(string email)
  {
    return _repo.GetByEmail(email);
  }

  internal Account GetOrCreateProfile(Account userInfo)
  {
    Account profile = _repo.GetById(userInfo.Id);
    if (profile == null)
    {
      return _repo.Create(userInfo);
    }
    return profile;
  }

  internal Account Edit(Account editData, string userEmail)
  {
    Account original = GetProfileByEmail(userEmail);
    original.Name = editData.Name.Length > 0 ? editData.Name : original.Name;
    original.Picture = editData.Picture.Length > 0 ? editData.Picture : original.Picture;
    return _repo.Edit(original);
  }

  internal List<Vault> GetMyVaults(string userId)
  {
    List<Vault> vaults = _repo.GetMyVaults(userId);
    return vaults;
  }

  internal Account UpdateAccount(Account updateData, string accountId)
  {
    Account foundAccount = _repo.GetById(accountId);

    Account original = foundAccount;

    original.Name = updateData.Name != null ? updateData.Name : original.Name;

    original.Picture = updateData.Picture != null ? updateData.Picture : original.Picture;

    original.Email = updateData.Email != null ? updateData.Email : original.Email;

    original.coverImg = updateData.coverImg != null ? updateData.coverImg : original.coverImg;

    _repo.UpdateAccount(original);
    return original;


  }
}
