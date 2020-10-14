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
    public class GatewayController : ControllerBase
    {
        private readonly Context _context;

        public GatewayController(Context context)
        {
            _context = context;
        }

        // GET: api/<GatewayController>
        // We get all the items from Gateway table
        [HttpGet]
        public IEnumerable<Gateway> Get()
        {
            try
            {
                return _context.Gateway.ToList();
            }
            catch (Exception e)
            {
                return _context.Gateway = null;
            }
            
        }

        // GET api/<GatewayController>
        //We get one item of Gateway table by its ID
        [Route("GetElement")]
        public Gateway Get(long id)
        {
            Gateway gate = new Gateway();
            gate = _context.Gateway.Where(p => p.id == id).FirstOrDefault();
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
                Gateway gate = _context.Gateway.Where(p => p.SerialNumber == name).FirstOrDefault();
                if (gate == null)
                {
                    result = true;
                }
            }
            catch(Exception e)
            {
                result = true;
            }

            return result;
        }

        // POST api/<GatewayController>
        //We ADD a new item in Gateway
        [HttpPost]
        public bool Post(Gateway value)
        {
            bool result = false;
            try
            {
                _context.Gateway.Add(value);
                _context.SaveChanges();

                result = true;
                
            }
            catch (Exception e)
            {
                result = false;
            }
            return result;
        }

        // PUT api/<GatewayController>/5
        //We MODIFY one item from Gateway by its ID
        [HttpPut]
        public bool Put(Gateway value)
        {
            bool result = false;

            try
            {
                _context.Entry(value).State = EntityState.Modified;
                _context.SaveChanges();

                result = true;
            }
            catch(Exception e)
            {
               
            }

            return result;
        }

        //We DELETE one item from Gateway looking for his ID
        [Route("DeleteItem")]
        public bool DeleteItem(int id)
        {
            bool result = false;

            var deleteItem = _context.Gateway.Where(p => p.id == id).FirstOrDefault();

            if (deleteItem != null)
            {
                _context.Gateway.Remove(deleteItem);
                _context.SaveChanges();
                result = true;
            }

            return result;
        }
    }
}
