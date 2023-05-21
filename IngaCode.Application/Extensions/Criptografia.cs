using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace IngaCode.Application.Extensions
{
    public static class Criptografia
    {
        public static string GerarHashSenha(this string senha)
        {
            var hash = SHA1.Create();
            var enconde = new ASCIIEncoding().GetBytes(senha);

            enconde = hash.ComputeHash(enconde);
            var strinHexa = new StringBuilder();

            foreach (var item in enconde)
            {
                strinHexa.Append(item.ToString("x2"));
            }
            return strinHexa.ToString();
        }

        public static bool VerificarHashSenha(string senhaDigitada, string senhaCadastrada)
        {
            return senhaDigitada.GerarHashSenha().Equals(senhaCadastrada);
        }
    }
}
