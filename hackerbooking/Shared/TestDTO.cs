using System;
using Dapper;
using Npgsql;
namespace hackerbooking.Shared
{
    public class TestDTO
    {

        public int id { get; set; }
        public string opgave { get; set; }
        public DateTime start { get; set; }
        public DateTime slut { get; set; }
        public int områdeid { get; set; }
    }
}