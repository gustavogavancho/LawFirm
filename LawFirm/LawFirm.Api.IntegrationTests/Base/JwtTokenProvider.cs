using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Cryptography;

namespace LawFirm.Api.IntegrationTests.Base;

//public class JwtTokenProvider
//{
//    // our fake issuer - can be anything
//    public static string Issuer { get; } = "Sample_Auth_Server";

//    // Our random signing key - used to sign and validate the tokens
//    public static SecurityKey SecurityKey { get; } = new SymmetricSecurityKey(Guid.NewGuid().ToByteArray());

//    // the signing credentials used by the token handler to sign tokens
//    public static SigningCredentials SigningCredentials { get; } = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);

//    // the token handler we'll use to actually issue tokens
//    public static readonly JwtSecurityTokenHandler JwtSecurityTokenHandler = new();
//}

public class JwtTokenProvider
{
    public static string Issuer { get; } = "Sample_Auth_Server";

    public static SecurityKey SecurityKey { get; }

    public static SigningCredentials SigningCredentials { get; }

    public static readonly JwtSecurityTokenHandler JwtSecurityTokenHandler = new JwtSecurityTokenHandler();

    static JwtTokenProvider()
    {
        using (var provider = new RNGCryptoServiceProvider())
        {
            var keyBytes = new byte[32]; // 256 bits
            provider.GetBytes(keyBytes);
            SecurityKey = new SymmetricSecurityKey(keyBytes);
        }

        SigningCredentials = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256);
    }
}