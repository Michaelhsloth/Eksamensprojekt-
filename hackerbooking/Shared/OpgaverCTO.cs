﻿using System;
using Dapper;
using Npgsql;
namespace hackerbooking.Shared
{
    public class OpgaverDTO
    {

        public string opgnavn { get; set; }
        public int opgid { get; set; }
    }
}