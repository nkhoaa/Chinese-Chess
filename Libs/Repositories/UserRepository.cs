using Libs.Data;
using Libs.Entity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libs.Repositories
{
    //public interface IUserRepository : IRepository<IdentityUser>
    //{
    //    Task<IdentityResult> RegisterUserAsync(IdentityUser user, string password);
    //    Task<SignInResult> LoginUserAsync(string username, string password, bool rememberMe);
    //    Task LogoutUserAsync();
    //    Task<IdentityUser> FindByNameAsync(string username);
    //}

    //public class UserRepository : IUserRepository
    //{
    //    private readonly UserManager<IdentityUser> _userManager;
    //    private readonly SignInManager<IdentityUser> _signInManager;

    //    public UserRepository(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    //    {
    //        _userManager = userManager;
    //        _signInManager = signInManager;
    //    }

    //    public async Task<IdentityResult> RegisterUserAsync(IdentityUser user, string password)
    //    {
    //        return await _userManager.CreateAsync(user, password);
    //    }

    //    public async Task<SignInResult> LoginUserAsync(string username, string password, bool rememberMe)
    //    {
    //        return await _signInManager.PasswordSignInAsync(username, password, rememberMe, lockoutOnFailure: false);
    //    }

    //    public async Task LogoutUserAsync()
    //    {
    //        await _signInManager.SignOutAsync();
    //    }

    //    public async Task<IdentityUser> FindByNameAsync(string username)
    //    {
    //        return await _userManager.FindByNameAsync(username);
    //    }
    //}
}
