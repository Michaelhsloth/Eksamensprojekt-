namespace hackerbooking.Shared
{
    public class FrivilligeDTO
    {
        public int telefon_nummer { get; set; }
        public string? navn { get; set; }
        public string? efternavn { get; set; }
        public string? email { get; set; }
        public string? kompetence { get; set; }
        public int frivillig_id { get; set; }
        public DateTime fødselsdag { get; set; }
        public string? password { get; set; }
    }
}