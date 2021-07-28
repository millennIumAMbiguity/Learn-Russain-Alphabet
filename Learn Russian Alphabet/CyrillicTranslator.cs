using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Learn_Russian_Alphabet
{
	public class CyrillicTranslator
	{
		private readonly Dictionary<string, string> _words = new Dictionary<string, string>();
		
		public CyrillicTranslator()
		{
			string path = Form1.Resources.GetString("Path-Alphabet");
			if (path != null && File.Exists(path)) {
				using (var file = new StreamReader(path)) {
					string    line;
					while((line = file.ReadLine()) != null) {
						string[] s = line.Split(',');
						_words.Add(s[0], s[1]);
					}
				}
			} else {
				MessageBox.Show(Form1.Resources.GetString("MSG-Missing_Alphabet_in_translator"));
				_words.Add("а", "a");
	            _words.Add("б", "b");
	            _words.Add("в", "v");
	            _words.Add("г", "g");
	            _words.Add("д", "d");
	            _words.Add("е", "e");
	            _words.Add("ё", "yo");
	            _words.Add("ж", "zh");
	            _words.Add("з", "z");
	            _words.Add("и", "i");
	            _words.Add("й", "j");
	            _words.Add("к", "k");
	            _words.Add("л", "l");
	            _words.Add("м", "m");
	            _words.Add("н", "n");
	            _words.Add("о", "o");
	            _words.Add("п", "p");
	            _words.Add("р", "r");
	            _words.Add("с", "s");
	            _words.Add("т", "t");
	            _words.Add("у", "u");
	            _words.Add("ф", "f");
	            _words.Add("х", "h");
	            _words.Add("ц", "c");
	            _words.Add("ч", "ch");
	            _words.Add("ш", "sh");
	            _words.Add("щ", "sch");
	            _words.Add("ъ", "j");
	            _words.Add("ы", "i");
	            _words.Add("ь", "j");
	            _words.Add("э", "e");
	            _words.Add("ю", "yu");
	            _words.Add("я", "ya");
	            _words.Add("А", "A");
	            _words.Add("Б", "B");
	            _words.Add("В", "V");
	            _words.Add("Г", "G");
	            _words.Add("Д", "D");
	            _words.Add("Е", "E");
	            _words.Add("Ё", "Yo");
	            _words.Add("Ж", "Zh");
	            _words.Add("З", "Z");
	            _words.Add("И", "I");
	            _words.Add("Й", "J");
	            _words.Add("К", "K");
	            _words.Add("Л", "L");
	            _words.Add("М", "M");
	            _words.Add("Н", "N");
	            _words.Add("О", "O");
	            _words.Add("П", "P");
	            _words.Add("Р", "R");
	            _words.Add("С", "S");
	            _words.Add("Т", "T");
	            _words.Add("У", "U");
	            _words.Add("Ф", "F");
	            _words.Add("Х", "H");
	            _words.Add("Ц", "C");
	            _words.Add("Ч", "Ch");
	            _words.Add("Ш", "Sh");
	            _words.Add("Щ", "Sch");
	            _words.Add("Ъ", "J");
	            _words.Add("Ы", "I");
	            _words.Add("Ь", "J");
	            _words.Add("Э", "E");
	            _words.Add("Ю", "Yu");
	            _words.Add("Я", "Ya");
			}
		}

		public string CyrillicToLatin(string s) => _words.Aggregate(s, (current, pair) => current.Replace(pair.Key, pair.Value));
		public string LatinToCyrillic(string s) => _words.Aggregate(s, (current, pair) => current.Replace(pair.Value, pair.Key));
	}
}