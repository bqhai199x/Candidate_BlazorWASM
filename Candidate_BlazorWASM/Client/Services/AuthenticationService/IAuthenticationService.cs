﻿using Candidate_BlazorWASM.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Candidate_BlazorWASM.Client.Services
{
    public interface IAuthenticationService
    {
        Task<RegistrationResponseDto> RegisterUser(UserForRegistrationDto userForRegistration);

        Task<AuthResponseDto> Login(UserForAuthenticationDto userForAuthentication);

        Task Logout();

        Task<string> RefreshToken();
    }
}
