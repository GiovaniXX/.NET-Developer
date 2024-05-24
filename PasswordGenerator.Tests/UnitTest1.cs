using System;
using Xunit;
using PasswordGenerator;

namespace PasswordGenerator.Tests
{
    public class PasswordGeneratorTests
    {
        private readonly PasswordGenerator _passwordGenerator;

        public PasswordGeneratorTests()
        {
            _passwordGenerator = new PasswordGenerator();
        }

        [Theory]
        [InlineData(12, true, true, true)]
        public void GeneratePassword_LengthIsCorrect(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            string password = _passwordGenerator.GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial);
            Assert.Equal(length, password.Length);
        }

        [Theory]
        [InlineData(12, true, false, false)]
        public void GeneratePassword_IncludesUppercase(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            string password = _passwordGenerator.GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial);
            Assert.Matches("[A-Z]", password);
        }

        [Theory]
        [InlineData(12, false, true, false)]
        public void GeneratePassword_IncludesNumbers(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            string password = _passwordGenerator.GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial);
            Assert.Matches("[0-9]", password);
        }

        [Theory]
        [InlineData(12, false, false, true)]
        public void GeneratePassword_IncludesSpecialCharacters(int length, bool includeUppercase, bool includeNumbers, bool includeSpecial)
        {
            string password = _passwordGenerator.GeneratePassword(length, includeUppercase, includeNumbers, includeSpecial);
            Assert.Matches("[!@#$%^&*()_+\\-=\\[\\]{}|;:,.<>?]", password);
        }      
    }
}

