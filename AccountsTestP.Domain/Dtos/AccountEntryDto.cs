using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;


namespace AccountsTestP.Domain.Dtos
{
    public class AccountEntryDto
    {


        [JsonPropertyName("current_balance")]
        public decimal CurrentBalance { get; set; }


    }
}
