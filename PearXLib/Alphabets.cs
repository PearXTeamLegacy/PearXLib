namespace PearXLib
{
	public static class Alphabets
	{
		public const string Russian = "абвгдеёжзийклмнопрстуфхцчшщъыьэюя";
		public const string RussianUpper = "АБВГДЕЁЖЗИЙКЛМНОПРСТУФХЦЧШЩЪЫЬЭЮЯ";
		public const string English = "abcdefghijklmnopqrstuvwxyz";
		public const string EnglishUpper = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
		public const string Digits = "0123456789";
		public const string Symbols = "!@#$%^&*()_+\"№;%:?*()=-.,/\\|'";
		public const string EngAllWithoutSymbols = English + EnglishUpper + Digits;
		public const string EngAll = EngAllWithoutSymbols + Symbols;
	}
}
