using EStall.App_Start;
using EStall.Helpers;
using PCLEStall.Models;
using EStall.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EStall.Controllers
{
    public class EmployersController : ApiController
    {
        public IEnumerable<Profile> GetEmployersByProfile(string id)
        {
            return DataBaseConfig.ExecuteReader(ProfileQuerys.GetEmployeersByProfile(id), QueryHelper.ReaderToObject);
        }
    }
}
