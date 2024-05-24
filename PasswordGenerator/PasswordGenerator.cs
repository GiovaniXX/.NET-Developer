using System;
using System.Text;

namespace PasswordGenerator
{
    public class PasswordGenerator
    {
        public string GeneratePassword(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            const string lower = "abcdefghijklmnopqrstuvwxyz";
            const string upper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
            const string numbers = "0123456789";
            const string special = "!@#$%^&*()_+-=[]{}|;:,.<>?";

            StringBuilder characterSet = new StringBuilder(lower);
            if (includeUppercase) characterSet.Append(upper);
            if (includeNumbers) characterSet.Append(numbers);
            if (includeSpecial) characterSet.Append(special);

            if (characterSet.Length == 0)
                throw new ArgumentException("Pelo menos um tipo de caractere deve ser incluído.");

            StringBuilder password = new StringBuilder();
            Random random = new Random();
            for (int i = 0; i < length; i++)
            {
                int index = random.Next(characterSet.Length);
                password.Append(characterSet[index]);
            }

            return password.ToString();
        }

        public async Task<string> GeneratePasswordAsync(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {           
            return await Task.Run(() => GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial));
        }      
    }
}
