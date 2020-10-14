using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CRUDApi.Data;
using CRUDApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WaterMeterController : ControllerBase
    {
        private readonly Context _context;

        public WaterMeterController(Context context)
        {
            _context = context;
        }

        // GET: api/<WaterMeterController>
        // We get all the items from WaterMeter table
        [HttpGet]
        public IEnumerable<WaterMeter> Get()
        {
            try
            {
                return _context.WaterMeter.ToList();
            }
            catch (Exception e)
            {
                return _context.WaterMeter = null;
            }

        }

        // GET api/<WaterMeterController>
        //We get one item of WaterMeter table by its ID
        [Route("GetElement")]
        public WaterMeter Get(long id)
        {
            WaterMeter gate = new WaterMeter();
            gate = _context.WaterMeter.Where(p => p.id == id).FirstOrDefault();
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
                WaterMeter gate = _context.WaterMeter.Where(p => p.SerialNumber == name).FirstOrDefault();
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

        // POST api/<WaterMeterController>
        //We ADD a new item in WaterMeter
        [HttpPost]
        public bool Post(WaterMeter value)
        {
            bool result = false;
            try
            {
                _context.WaterMeter.Add(value);
                _context.SaveChanges();

                result = true;

            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        // PUT api/<WaterMeterController>/5
        //We MODIFY one item from Water Meter by its ID
        [HttpPut]
        public bool Put(WaterMeter value)
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


        //We DELETE one item from WaterMeter looking for his ID
        [Route("DeleteItem")]
        public bool DeleteItem(int id)
        {
            bool result = false;

            var deleteItem = _context.WaterMeter.Where(p => p.id == id).FirstOrDefault();

            if (deleteItem != null)
            {
                _context.WaterMeter.Remove(deleteItem);
                _context.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
