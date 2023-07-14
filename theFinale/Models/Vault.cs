namespace theFinale.Models
{
  public class Vault
  {
    public int id { get; set; }
    public string creatorId { get; set; }
    public string name { get; set; }
    public string description { get; set; }
    public string img { get; set; }
    public bool isPrivate { get; set; }

    // virtuals

    public Account creator { get; set; }
  }
}