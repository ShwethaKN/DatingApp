using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.Api.Data;
using DatingApp.Api.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatingApp.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private DatingAppDbContext _context;
        public ValuesController(DatingAppDbContext context)
        {
           _context = context;
        }
        //public IEnumerable<string> Colors = new string[] {"pink","red","black","white","blue","yellow","orange","green"};
        [HttpGet]
        public IActionResult GetData()
        {
            var values = _context.TestModels.ToList();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public IActionResult GetDataById(int id)
        {
            return Ok(_context.TestModels.FirstOrDefault(x => x.Id == id));
        }

        [HttpPost]
        public void PostData([FromBody] TestModel modelObj)
        {
            if(modelObj != null)
            {
                _context.TestModels.Add(modelObj);
                _context.SaveChanges();
            }
                
        }

        [HttpPut]
        public void PutData([FromBody] TestModel modelObj)
        {
            var data = _context.TestModels.FirstOrDefault(x => x.Id == modelObj.Id);
            data.Id = modelObj.Id;
            data.Name = modelObj.Name;
            
            _context.TestModels.Update(data);
            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public void DeleteData(int id)
        {
            var data = _context.TestModels.FirstOrDefault(x => x.Id == id);
            _context.TestModels.Remove(data);
            _context.SaveChanges();
        }
    }
}
