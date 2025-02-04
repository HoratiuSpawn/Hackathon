﻿using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;

namespace AuthenticationApi.AuthService
{
    public class JwtGenerator
    {
        readonly RsaSecurityKey _key;
        public JwtGenerator(string signingKey)
        {
            RSA privateRSA = RSA.Create();
            privateRSA.ImportRSAPrivateKey(Convert.FromBase64String(signingKey), out _);
            _key = new RsaSecurityKey(privateRSA);
        }

        public string CreateUserAuthToken(string userId)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var roleGenerator = new RoleGenerator();

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Audience = "AuthentificationApi",
                Issuer = "AuthService",
                Subject = new ClaimsIdentity(new Claim[]
                {
                        new Claim(ClaimTypes.Sid, userId.ToString()),
                        new Claim(ClaimTypes.Role, roleGenerator.AssignRole(userId))

                }),
                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(_key, SecurityAlgorithms.RsaSha256)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
        
    }
}
