using AmirRestAPI.Models;
using AmirRestAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AmirRestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {

        static List<AmirRestoran> customer = new List<AmirRestoran>();
        //public Jason jasonService;
        // GET: api/<UserController>
        //public UserController(Jason json)
        //{
        //    jasonService = json;
        //}
        [HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}
        public List<AmirRestoran> Get()
        {
            if (customer.Count == 0)
            {
                customer = Jason.LoadJsonFile<AmirRestoran>("UserList.json");

                if (customer == null)
                {
                    customer = new List<AmirRestoran>();
                    //Payment.Print();
                }
            }
            Jason.SaveJsonFile<AmirRestoran>(customer, "UserList.json");
            return customer;
        }


        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public AmirRestoran Get(int id)
        {
            return customer.Find(x => x.userID == id);
        }

        //public static void moneyChanges(Main m, Main i)
        //{
        //    float res = m.moneyPaid - i.items;

        //}



        // POST api/<UserController>
        [HttpPost]
        public void Post([FromBody] AmirRestoran value)
        {
            if (customer.Count == 0)
            {
                customer = Jason.LoadJsonFile<AmirRestoran>("UserList.json");
                //customer = JsonFileServices.LoadJsonFile<Main>("UserList.json");
                if (customer == null)
                {
                    customer = new List<AmirRestoran>();
                    value.userID = 1;

                    value.orderID = Payment.Print();
                }
                else
                {
                    value.userID = customer.Count + 1;
                    value.orderID = Payment.Print();
                }
            }
            else
            {
                value.userID = customer.Count + 1;
                value.orderID = Payment.Print();
            }
            customer.Add(value);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] AmirRestoran value)
        {
            AmirRestoran searchUser = customer.Find(x => x.userID == id);

            if (searchUser != null)
            {
                if (value.icNumber != null)
                    searchUser.icNumber = value.icNumber;
                if (value.fullName != null)
                    searchUser.fullName = value.fullName;

            }

            //JsonFileServices.SaveJsonFile(usrNew);
            Jason.SaveJsonFile<AmirRestoran>(customer, "UserList.json");
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            AmirRestoran selectedUser = customer.Find(x => x.userID == id);

            if (selectedUser != null)
            {
                customer.Remove(selectedUser);
            }

            Jason.SaveJsonFile<AmirRestoran>(customer, "UserList.json");
        }
    }
}
