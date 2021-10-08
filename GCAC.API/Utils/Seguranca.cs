using System.Security.Cryptography;
using System.Text;

namespace GCAC.API.Utils
{
    /// <summary>
    /// 
    /// </summary>
    public static class Seguranca
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static string CriptografarSenha(string senha)
        {
            SHA256Managed crypt = new SHA256Managed();
            StringBuilder hash = new StringBuilder();
            byte[] crypto = crypt.ComputeHash(Encoding.UTF8.GetBytes(senha), 0, Encoding.UTF8.GetByteCount(senha));
            foreach (byte theByte in crypto)
            {
                hash.Append(theByte.ToString("x2"));
            }

            return hash.ToString();
        }
    }
}
