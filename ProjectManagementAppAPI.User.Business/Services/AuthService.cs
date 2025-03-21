using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ProjectManagementAppAPI.User.Business.Interfaces;
using ProjectManagementAppAPI.User.Data.Access;
using ProjectManagementAppAPI.User.Data.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManagementAppAPI.User.Business.Services
{
    public class AuthService : IAuthService
    {
        private readonly ITokenService _tokenService;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IPasswordHasher<Data.Model.Models.User> _passwordHasher;

        public AuthService(
            ITokenService tokenService,
            IUserRepository userRepository,
            IMapper mapper,
            IPasswordHasher<Data.Model.Models.User> passwordHasher)
        {
            _tokenService = tokenService;
            _userRepository = userRepository;
            _mapper = mapper;
            _passwordHasher = passwordHasher;
        }

        public async Task<UserLoginResponse> LoginUserAsync(UserLoginRequest request)
        {
            UserLoginResponse response = new();

            var user = await _userRepository.GetUserNameAsync(request.UserName);

            if(user == null)
            {
                response.AuthenticateResult = false;
                return response;
            }

            var passwordValidationResult = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, request.PasswordHash);

            if(passwordValidationResult == PasswordVerificationResult.Failed)
            {
                response.AuthenticateResult = false;
                return response;
            }

            var generatedTokenInformation = await _tokenService.GenerateToken(new GenerateTokenRequest 
            { 
                UserName = request.UserName
            });

            response.AccessTokenExpireDate = generatedTokenInformation.TokenExpireDate;
            response.AuthenticateResult = true;
            response.AuthToken = generatedTokenInformation.Token;

            return response;
        }
    }
}
