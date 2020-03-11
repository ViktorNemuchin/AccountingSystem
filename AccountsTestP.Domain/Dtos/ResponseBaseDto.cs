﻿using System.Text.Json;
using System.Text.Json.Serialization;

namespace AccountsTestP.Domain.Dtos
{
    /// <summary>
    /// Базовый DTO использующийся для сериализации результатов запросов и комманд для отправки внешним сервисам 
    /// </summary>
    public class ResponseBaseDto
    {
        /// <summary>
        /// Статус выполнения запроса
        /// </summary>
        public string Status { get; set; }
    }
}
