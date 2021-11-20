using System;
using System.Text.RegularExpressions;

namespace BattleShipGame.Services
{
    public class ConsoleService : IConsoleService
    {
		public void WriteLine(string s)
		{
			Console.WriteLine(s);
		}

		public string ReadLine()
		{
			return Console.ReadLine();
		}

		public int ReadInteger()
		{
			var num = 0;
			while (!Int32.TryParse(ReadLine(), out num))
			{
				Console.WriteLine("Not a valid number, try again.");
			}

			return num;
		}

		public string ReadString()
		{
			var pattern = @"^[a-zA-Z]+$";
            var inputString = ReadLine();

			while (!(inputString.Length < 2 && Regex.IsMatch(inputString, pattern)))
			{
				Console.WriteLine("Not a valid direction input, try again.");
				inputString = ReadLine();
			}				

			return inputString;
		}
	}
}
