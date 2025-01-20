﻿using Auth.API.Dtos.Requests;
using Auth.API.Dtos.Responses;

namespace Auth.API.ServiceContracts;

public interface IAuthService
{
    Task<bool> Register(RegisterRequest registerRequest);
    Task<bool> ConfirmEmailAsync(string token, string email);
    Task<LoginResponse> Login(LoginRequest loginRequest);
    Task<bool> UnlockAccountAsync(string email);
    Task<bool> ForgotPasswordAsync(string email);
    Task<bool> ResetPasswordAsync(ResetPasswordRequest request);
    Task<LoginResponse> Refresh(TokenApiRequest request);
}