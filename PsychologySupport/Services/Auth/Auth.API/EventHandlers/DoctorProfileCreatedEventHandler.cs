﻿using Auth.API.Models;
using BuildingBlocks.Constants;
using BuildingBlocks.Messaging.Events.Auth;
using MassTransit;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Auth.API.EventHandlers;

public class DoctorProfileCreatedEventHandler : IConsumer<DoctorProfileCreatedIntegrationEvent>
{
    private readonly UserManager<User> _userManager;

    public DoctorProfileCreatedEventHandler(UserManager<User> userManager)
    {
        _userManager = userManager;
    }

    public async Task Consume(ConsumeContext<DoctorProfileCreatedIntegrationEvent> context)
    {
        var message = context.Message;

        var existingUser = await _userManager.FindByEmailAsync(message.Email);
        existingUser ??= await _userManager.Users.FirstOrDefaultAsync(u => u.PhoneNumber == message.PhoneNumber);

        if (existingUser is not null)
        {
            throw new InvalidDataException("Email or phone number already exists in the system");
        }

        //var password = string.IsNullOrEmpty(message.Password) ? GenerateRandomPassword() : message.Password;
        var password = "Doctor001";

        var user = new User
        {
            Id = Guid.NewGuid(),
            FullName = message.FullName,
            Gender = message.Gender,
            Email = message.Email,
            UserName = message.Email,
            PhoneNumber = message.PhoneNumber,
            EmailConfirmed = true,
            PhoneNumberConfirmed = true
        };

        var result = await _userManager.CreateAsync(user, password);
        if (!result.Succeeded)
        {
            var errors = string.Join("; ", result.Errors.Select(e => e.Description));
            throw new InvalidDataException($"User registration failed: {errors}");
        }

        var roleResult = await _userManager.AddToRoleAsync(user, Roles.DoctorRole);
        if (!roleResult.Succeeded)
        {
            throw new InvalidDataException("Role assignment failed");
        }

        // Publish success response
        await context.Publish(new DoctorProfileCreatedResponseEvent(user.Id, true));
    }

    private string GenerateRandomPassword()
    {
        const string lowerCase = "abcdefghijklmnopqrstuvwxyz";
        const string upperCase = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        const string digits = "0123456789";
        const string specialChars = "@#$%^&*!";

        Random random = new Random();

        char[] password = new char[8];
        password[0] = lowerCase[random.Next(lowerCase.Length)];
        password[1] = upperCase[random.Next(upperCase.Length)];
        password[2] = digits[random.Next(digits.Length)];
        password[3] = specialChars[random.Next(specialChars.Length)];

        string allChars = lowerCase + upperCase + digits + specialChars;
        for (int i = 4; i < password.Length; i++)
        {
            password[i] = allChars[random.Next(allChars.Length)];
        }

        return new string(password.OrderBy(_ => random.Next()).ToArray());
    }

}

