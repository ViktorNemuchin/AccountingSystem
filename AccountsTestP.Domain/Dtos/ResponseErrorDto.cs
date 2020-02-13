using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class ResponseErrorDto: ResponseBaseDto
    {
        public string Message { get; set; }
    }
}
