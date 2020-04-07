using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ConvertOperationToTransfer.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        /// <summary>
        /// Получение всех операций
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetALlOperations() 
        {
            return Ok();
        }

        /// <summary>
        /// Получение рперции по Id операции
        /// </summary>
        /// <param name="id">Id операции</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> GetOperationById(Guid id)
        {
            return Ok();
        }

        /// <summary>
        /// Создание новой операции
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> AddOperation() 
        {
            return Ok();
        }

        /// <summary>
        /// Удаление операции
        /// </summary>
        /// <returns></returns>
        [HttpDelete]
        public async Task<IActionResult> DeleteOperation() 
        {
            return Ok();
        }
    }
}