namespace PasswordValidationTesting
{
	public class UnitTest1
	{
		[Fact]
		public void IsPasswordSecure_returns_false_if_password_has_less_than_8_characters()
		{
			var registerViewModel = new RegisterViewModel();

			bool result = registerViewModel.IsPasswordSecure("1234567");

			Assert.False(result);
		}
		[Fact]
		public void IsPasswordSecure_returns_false_if_password_does_not_contains_uppercase_character()
		{
			var registerViewModel = new RegisterViewModel();

			bool result = registerViewModel.IsPasswordSecure("12345678a");

			Assert.False(result);

		}
		[Fact]
		public void IsPasswordSecure_returns_true_if_password_contains_an_uppercase_character_and_a_symbol()
		{
			var registerViewModel = new RegisterViewModel();

			bool result = registerViewModel.IsPasswordSecure("Q23D@45");

			Assert.False(result);
		}
	}

	internal class RegisterViewModel
	{
		internal bool IsPasswordSecure(string password)
		{
			if (password.Length < 8)
			{
				return false;
			}
			//1234A5678
			if (!ContieneMayuscula(password))
			{
				return false;
			}

			if (!ContieneSimbolo(password))
			{
				return false;
			}

			return true;
		}

		private bool ContieneMayuscula(string password)
		{
			return password.Any(c => Char.IsLetter(c) && Char.IsUpper(c));
		}

		private bool ContieneSimbolo(string password)
		{
			return password.Any(c => Char.IsSymbol(c) || (Char.IsWhiteSpace(c) && !Char.IsLetterOrDigit(c)));
		}
	}
}