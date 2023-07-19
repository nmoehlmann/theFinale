namespace theFinale.Services
{
  public class KeepsService
  {
    readonly KeepsRepository _repo;

    public KeepsService(KeepsRepository repo)
    {
      _repo = repo;
    }

    internal Keep CreateKeep(Keep keepData)
    {
      Keep newKeep = _repo.CreateKeep(keepData);
      return newKeep;
    }


    internal List<Keep> GetAllKeeps()
    {
      List<Keep> keeps = _repo.GetAllKeeps();
      return keeps;
    }

    internal Keep GetKeepById(int keepId)
    {
      Keep keep = _repo.GetKeepById(keepId);
      if (keep.name == null) throw new Exception("Invalid Id");
      keep.views++;
      _repo.UpdateKeep(keep);
      return keep;
    }

    internal Keep UpdateKeep(Keep updateData, Account userInfo, int keepId)
    {
      Keep foundKeep = GetKeepById(keepId);
      updateData.creatorId = foundKeep.creatorId;

      if (updateData.creatorId != userInfo.Id) throw new Exception("Unauthorized to edit this keep");

      Keep original = GetKeepById(updateData.id);

      original.name = updateData.name != null ? updateData.name : original.name;

      original.description = updateData.description != null ? updateData.description : original.description;

      original.img = updateData.img != null ? updateData.img : original.img;

      _repo.UpdateKeep(original);
      return original;
    }
    internal Keep DeleteKeep(int keepId, string userId)
    {
      Keep foundKeep = GetKeepById(keepId);
      if (foundKeep == null) throw new Exception("Keep doesnt exist");
      if (foundKeep.creatorId != userId) throw new Exception("Unauthorized to delete");

      int rows = _repo.DeleteKeep(keepId);
      return foundKeep;
    }
  }
}