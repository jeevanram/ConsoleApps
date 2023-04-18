using DataAccess.Database.Repository.Interface;
using DataAccess.Database.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;

namespace DataAccess.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ODataController
    {
        private readonly ITestDBRepositoryWrapper _testDBRepositoryWrapper;

        public UsersController(ITestDBRepositoryWrapper testDBRepositoryWrapper)
        {
            _testDBRepositoryWrapper = testDBRepositoryWrapper;
        }

        [HttpGet, EnableQuery]
        public ActionResult<IEnumerable<UserInfo>> Get()
        {
            return Ok(_testDBRepositoryWrapper.UserRepository.GetAll());
        }
    }
}