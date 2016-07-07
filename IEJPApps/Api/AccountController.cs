using System.Threading.Tasks;
using System.Web.Http;
using IEJPApps.ViewModels;

namespace IEJPApps.Api
{
    [RoutePrefix("api/account")]
    public class AccountController : BaseApiController
    {
        private readonly ApplicationUserManager _userManager;

        public AccountController(ApplicationUserManager userManager)
        {
            _userManager = userManager;
        }

        // POST api/account/register
        [AllowAnonymous]
        [Route("register")]
        public async Task<IHttpActionResult> Register(UserViewModel model)
        {
            if (!ModelState.IsValid || model.Password != model.ConfirmPassword)
            {
                return BadRequest(ModelState);
            }

            var result = await _userManager.RegisterUser(model.UserName, model.Password);
            
            var errorResult = GetErrorResult(result);
            if (errorResult != null)
            {
                return errorResult;
            }

            return Ok();
        }
    }
}