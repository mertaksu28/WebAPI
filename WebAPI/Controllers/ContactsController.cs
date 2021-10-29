using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController : ControllerBase
    {
        [HttpGet("get")]
        [Authorize(Roles = "Admin")]
        public List<ContactModel> GetAll()
        {
            return new List<ContactModel>
            {
                new ContactModel { Id=1, FirstName="Mert", LastName = "LastName"}
            };
        }
    }
}
