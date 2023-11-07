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