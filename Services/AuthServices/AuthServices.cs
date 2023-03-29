using AutoMapper;
using Login.Data;
using Login.Data.DTO;
using Login.Data.DTO.Request;
using Login.Data.DTO.Response;
using Login.Data.Enum;
using Login.Data.Generic;
using Login.Data.Models;
using Login.Services.EmailSenderService;
using Login.Utils;
using Login.Utils.Tokens;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Security.Claims;

namespace Login.Services.AuthServices
{
    public partial class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly IMapper _mapper;
        private readonly IEmailConfirmTokenHelper _emailConfirmToken;
        private readonly IPasswordResetTokenHelper _passwordResetToken;
        private readonly IEmailSenderService _emailSenderService;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly ApplicationDbContext _db;

        public AuthService(
            UserManager<AppUser> userManager,
            IConfiguration configuration,
            IMapper mapper,
            IEmailConfirmTokenHelper emailConfirmToken,
            IPasswordResetTokenHelper passwordResetToken,
            RoleManager<IdentityRole> roleManager,
            ApplicationDbContext db,
            IEmailSenderService emailSenderService,
            IHttpContextAccessor httpContextAccessor
        )
        {
            _userManager = userManager;
            _configuration = configuration;
            _mapper = mapper;
            _emailConfirmToken = emailConfirmToken;
            _passwordResetToken = passwordResetToken;
            _emailSenderService = emailSenderService;
            _roleManager = roleManager;
            _httpContextAccessor = httpContextAccessor;
            _db = db;
        }
    }
}