namespace theFinale.Models
{
    public class VaultKeep
    {
        public int id {get; set;}
        public string creatorId {get; set;}
        public int vaultId {get; set;}
        public int keepId {get; set;}

        // virtuals below

        // public Account creator {get; set;}

        // this is only here for postman
        // public int vaultKeepId {get; set;}
    }
}