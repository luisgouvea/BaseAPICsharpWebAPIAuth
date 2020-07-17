using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace BaseAPICsharpWebAPIAuth.Controllers
{
    public class AuthController : ApiController
    {

        [AllowAnonymous]
        [HttpGet]
        public HttpResponseMessage GetToken()
        {
            string key = "my_secret_key_12345";
            var issuer = "http://mysite.com";
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var permClaims = new List<Claim>();
            permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
            permClaims.Add(new Claim("valid", "1"));
            permClaims.Add(new Claim("userid", "1"));
            permClaims.Add(new Claim("name", "bilal"));

            var token = new JwtSecurityToken(issuer,
                            issuer,
                            permClaims,
                            expires: DateTime.Now.AddMinutes(30),
                            signingCredentials: credentials);


            var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);

            return Request.CreateResponse(HttpStatusCode.OK, jwt_token);
        }

        // Do video tutorial que eu segui

        //[HttpGet]
        //public Object GetToken()
        //{
        //    string key = "my_secret_key_12345";
        //    var issuer = "http://mysite.com";
        //    var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        //    var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        //    var permClaims = new List<Claim>();
        //    permClaims.Add(new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()));
        //    permClaims.Add(new Claim("valid", "1"));
        //    permClaims.Add(new Claim("userid", "1"));
        //    permClaims.Add(new Claim("name", "bilal"));

        //    var token = new JwtSecurityToken(issuer,
        //                    issuer,
        //                    permClaims,
        //                    expires: DateTime.Now.AddDays(1),
        //                    signingCredentials: credentials);
        //    var jwt_token = new JwtSecurityTokenHandler().WriteToken(token);
        //    return new { data = jwt_token };


        //}


        // Do Aspnet Core


        //[AllowAnonymous]
        //[HttpPost]
        //public IActionResult RequestToken([FromBody] Usuario request)
        //{
        //    if (request.Nome == "Mac" && request.Senha == "numsey")
        //    {
        //        var claims = new[]
        //        {
        //             new Claim(ClaimTypes.Name, request.Nome)
        //        };

        //        //recebe uma instancia da classe SymmetricSecurityKey 
        //        //armazenando a chave de criptografia usada na criação do token
        //        var key = new SymmetricSecurityKey(
        //                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"]));

        //        //recebe um objeto do tipo SigninCredentials contendo a chave de 
        //        //criptografia e o algoritmo de segurança empregados na geração 
        //        // de assinaturas digitais para tokens
        //        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        //        var token = new JwtSecurityToken(
        //             issuer: "macoratti.net",
        //             audience: "macoratti.net",
        //             claims: claims,
        //             expires: DateTime.Now.AddMinutes(30),
        //             signingCredentials: creds);

        //        return Ok(new
        //        {
        //            token = new JwtSecurityTokenHandler().WriteToken(token)
        //        });
        //    }
        //    return BadRequest("Credenciais inválidas...");
        //}
    }
}