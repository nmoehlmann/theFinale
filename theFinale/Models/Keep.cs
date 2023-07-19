namespace theFinale.Models
{
  public class Keep
  {
    public int id { get; set; }
    public string creatorId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string img { get; set; }
    public int views { get; set; }

    // virtuals section below

    public int kept { get; set; }
    public Account creator { get; set; }

  }

  public class vk : Keep
  {
    public int vaultKeepId { get; set; }
  }
}