using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data.Converter;
using API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly PessoaService _pessoaService;
        private readonly FileService _fileService;
        private readonly PessoaConverter _converter;

        public FileController(PessoaService pessoaService, FileService fileService)
        {
            _pessoaService = pessoaService;
            _fileService = fileService;
            _converter = new PessoaConverter();
        }

        [HttpGet]
        public IActionResult GetFile()
        {
            var pessoas = _converter.ParseList(_pessoaService.FindAll());
            var file = _fileService.Excel(pessoas);

            return File(file, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "relatorio.xlsx");
        }
    }
}
