using _03_Tutorial.Web.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace _03_Tutorial.Web.Controllers
{
    /// <summary>
    /// 我们自己定义的类需要继承自AspNetCore的Controller类
    /// </summary>
    [Route("Account")]
    public class AccountController: Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        // 进行依赖注入
        public AccountController(
            SignInManager<IdentityUser> signInManager, 
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            // 验证用户名和密码是不是都填写了
            if (!ModelState.IsValid)
            {
                return View(loginViewModel);
            }

            // 通过用户名去数据存储中查询用户名是否存在
            var user = await _userManager.FindByNameAsync(loginViewModel.UserName);
            // 用户名不为空,说明用户名存在
            if(user != null)
            {
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, false, false);
                // 如果密码也验证成功,说明用户校验通过,就直接跳转到首页
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // 如果验证失败,就返回一个Model级别的错误,第一个参数必须是空字符串,第二个参数是具体的描述
            ModelState.AddModelError("", "用户名/密码不正确");
            return View(loginViewModel);
        }

        // 返回到Register视图
        [Route("Register")]
        public IActionResult Register()
        {
            return View();
        }

        // 注册用户
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if(!ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = registerViewModel.UserName
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if(result.Succeeded)
                {
                    return RedirectToAction("Index", "Home");
                }
            }

            // 如果在注册的时候,没有校验通过,就通过重定向到原来的注册页面,再一次进行注册
            return View(registerViewModel);
        }

        // 用户登出
        public async Task<IActionResult> Logout()
        {
            // 进行登出操作
            await _signInManager.SignOutAsync();

            return RedirectToAction("Index", "Home");
        }
    }
}
