using EStall.App_Start;
using EStall.Helpers;
using PCLEStall.Models;
using EStall.Querys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace EStall.Controllers
{
    public class ProfileController : ApiController
    {
        private IEnumerable<Profile> GetProfileMock()
        {
            List<Profile> profiles = new List<Profile>();

            profiles.Add(new Profile()
            {
                DataAdmissao = DateTime.Now.AddDays(-10),
                DataNascimento = DateTime.Now.AddYears(-20),
                Nome = "Little Jhon",
                TipoColaborador = 1,
                Viaja = false,
                Handle =1
            });

            profiles.Add(new Profile()
            {
                DataAdmissao = DateTime.Now.AddDays(-30),
                DataNascimento = DateTime.Now.AddYears(-40),
                Nome = "Little Mary",
                TipoColaborador = 2,
                Viaja = false,
                Handle = 2
            });

            profiles.Add(new Profile()
            {
                DataAdmissao = DateTime.Now.AddDays(10),
                DataNascimento = DateTime.Now.AddYears(-22),
                Nome = "Gabriel",
                TipoColaborador = 1,
                Viaja = true,
                Handle = 3
            });

            profiles.Add(new Profile()
            {
                DataAdmissao = DateTime.Now.AddDays(-10),
                DataNascimento = DateTime.Now.AddYears(50),
                Nome = "Boss",
                TipoColaborador = 2,
                Viaja = false,
                Handle = 3
            });

            profiles.Add(new Profile()
            {
                DataAdmissao = DateTime.Now.AddDays(-10),
                DataNascimento = DateTime.Now.AddYears(-20),
                Nome = "Little Jhon",
                TipoColaborador = 1,
                Viaja = false,
                Handle = 4
            });


            return profiles;
        }

        // GET api/HelloWorld
        public IEnumerable<Profile> Get()
        {
            return DataBaseConfig.ExecuteReader(ProfileQuerys.GetProfileByName(), QueryHelper.ReaderToObject);
        }

        // GET api/HelloWorld
        public IEnumerable<Profile> Get(string id)
        {
            return DataBaseConfig.ExecuteReader(ProfileQuerys.GetProfileByName(id), QueryHelper.ReaderToObject);
        }


    }
}
