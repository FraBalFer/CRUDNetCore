using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDApi.Data;
using CRUDApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElectricMeterController : ControllerBase
    {
        private readonly Context _context;

        public ElectricMeterController(Context context)
        {
            _context = context;
        }

        // GET: api/<ElectricMeterController>
        // We get all the items from ElectricMeter table
        [HttpGet]
        public IEnumerable<ElectricMeter> Get()
        {
            try
            {
                return _context.ElectricMeter.ToList();
            }
            catch (Exception e)
            {
                return _context.ElectricMeter = null;
            }

        }

        // GET api/<ElectricMeterController>
        //We get one item of ElectricMeter table by its ID
        [Route("GetElement")]
        public ElectricMeter Get(long id)
        {
            ElectricMeter gate = new ElectricMeter();
            gate = _context.ElectricMeter.Where(p => p.id == id).FirstOrDefault();
            return gate;
        }

        // GET
        //We use this function in order to make sure that there isn´t duplicate name
        [Route("ElementWithSameName")]
        public bool ElementWithSameName(string name)
        {
            bool result = false;

            try
            {
                ElectricMeter gate = _context.ElectricMeter.Where(p => p.SerialNumber == name).FirstOrDefault();
                if (gate == null)
                {
                    result = true;
                }
            }
            catch (Exception e)
            {
                result = true;
            }

            return result;
        }

        // POST api/<ElectricMeterController>
        //We ADD a new item in ElectricMeter
        [HttpPost]
        public bool Post(ElectricMeter value)
        {
            bool result = false;
            try
            {
                _context.ElectricMeter.Add(value);
                _context.SaveChanges();

                result = true;

            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        // PUT api/<ElectricMeterController>/5
        //We MODIFY one item from ElectricMeter by its ID
        [HttpPut]
        public bool Put(ElectricMeter value)
        {
            bool result = false;

            try
            {
                _context.Entry(value).State = EntityState.Modified;
                _context.SaveChanges();

                result = true;
            }
            catch (Exception e)
            {

            }

            return result;
        }

        //We DELETE one item from ElectricMeter looking for his ID
        [Route("DeleteItem")]
        public bool DeleteItem(int id)
        {
            bool result = false;

            var deleteItem = _context.ElectricMeter.Where(p => p.id == id).FirstOrDefault();

            if (deleteItem != null)
            {
                _context.ElectricMeter.Remove(deleteItem);
                _context.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
