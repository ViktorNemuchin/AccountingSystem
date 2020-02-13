using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    public class ResponseOkDto<T>:ResponseBaseDto
    {

        public T Result { get; set; }

    }
}
