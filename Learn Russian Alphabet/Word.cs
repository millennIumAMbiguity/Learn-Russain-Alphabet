using System.Linq;

namespace Learn_Russian_Alphabet
{
	public struct Word
	{
		public readonly string Key;
		public string[] Values;

		public Word(string key, string[] values)
		{
			Key    = key;
			Values = values;
		}

		public Word(string s)
		{
			string[] sArray = s.Split(',');
			Key    = sArray[0];
			Values = new string[sArray.Length - 1];
			for (int i = 0; i < Values.Length; i++) Values[i] = sArray[i + 1];
		}

		public bool HaveAnswers(string s)
		{
			s = s.ToLower();
			return Values.Any(value => value.ToLower() == s);
		}
	}
}