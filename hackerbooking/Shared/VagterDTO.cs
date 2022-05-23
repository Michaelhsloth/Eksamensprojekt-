namespace hackerbooking.Shared
{
    public class VagterDTO
    {
        private bool vagt_status { get; set; }
        public DateTime dato_tid_start { get; set; }
        public DateTime dato_tid_slut { get; set; }
        public int vagt_id { get; set; }
        public int frivillig_id { get; set; }
        public string? opgave_navn { get; set; }
        public int område_id { get; set; }
    }
}