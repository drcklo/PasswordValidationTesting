namespace PasswordValidationTesting
{
	public class UnitTest1
	{
		[Fact]
		public void Test1()
		{

		}
	}

	internal class RegisterViewModel
	{
		private bool ContieneSimbolo(string password)
		{
			return password.Any(c => Char.IsSymbol(c) || (Char.IsWhiteSpace(c) && !Char.IsLetterOrDigit(c)));
		}
	}
}