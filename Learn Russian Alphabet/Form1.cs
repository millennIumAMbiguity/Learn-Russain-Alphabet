using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Learn_Russian_Alphabet
{
	public partial class Form1 : Form
	{
		private Difficulty _gamemode;
		private bool       _isPlaying;
		private bool       _autoPlay        = true;
		private bool       _readTypedLetter = true;
		private string     _input           = "";
		private string     _answer           = "";
		
		private SpeechSynthesizer          _speechSynthesizerObj;
		private CyrillicTranslator         _translator;
		private List<Word> gameData = new List<Word>();

		internal static System.Resources.ResourceManager Resources;
		public Form1() => InitializeComponent();

		private void Form1_Load(object sender, EventArgs e)
		{
			Resources = new System.Resources.ResourceManager(typeof(Form1));
			_translator = new CyrillicTranslator();
			
			

			var synthesizer = new SpeechSynthesizer();
			synthesizer.SelectVoiceByHints(
				VoiceGender.NotSet, VoiceAge.NotSet, 0, CultureInfo.CreateSpecificCulture("ru-RU"));
			_speechSynthesizerObj                =  synthesizer;
			_speechSynthesizerObj.SpeakCompleted += SpeakCompleted;
			
			ChangeGamemode(alphabetToolStripMenuItem, Difficulty.Alphabet);
			StartGame();
		}

		private void StartGame()
		{
			_input          = "";
			inputLabel.Text = _input;
			int index = new Random().Next(0, gameData.Count);
			label.Text = _gamemode == Difficulty.AlphabetSoundOnly ? "?" : gameData[index].Key;
			_answer    = gameData[index].Value.ToLower();
			if (_autoPlay) ForcePlay(label.Text);
		}
		
		private void SpeakCompleted(object obj, SpeakCompletedEventArgs args) => _isPlaying = false;

		private void PlayStop(string s)
		{
			if (_isPlaying) _speechSynthesizerObj.SpeakAsyncCancelAll();
			else _speechSynthesizerObj.SpeakAsync(s);
			_isPlaying = !_isPlaying;
		}

		private void ForcePlay(string s)
		{
			if (_isPlaying) _speechSynthesizerObj.SpeakAsyncCancelAll();
			_speechSynthesizerObj.SpeakAsync(s);
			_isPlaying = true;
		}

		private void label_Click(object sender, EventArgs e)
		{
			var me = (MouseEventArgs) e;
			if (me.Button == MouseButtons.Right) contextMenu.Show(this, me.Location + new Size(15,11));
			else PlayStop(label.Text);
		}

		private void ChangeGamemode(ToolStripMenuItem sender, Difficulty mode)
		{
			foreach (ToolStripMenuItem item in difficultyToolStripMenuItem.DropDownItems)
				item.Checked = false;
			sender.Checked = true;
			_gamemode      = mode;
			
			//load data to memory
			gameData.Clear();
			string path = Resources.GetString("Path-" + mode);
			
			if (path != null && File.Exists(path)) {
				using (var file = new StreamReader(path)) {
					string line;
					while((line = file.ReadLine()) != null) {
						string[] s = line.Split(',');
						gameData.Add(new Word(s[0], s[1]));
					}
				}
			} else MessageBox.Show($"{Resources.GetString("MSG-Missing_File")}\n{path}"); 
		}

		private void alphabetToolStripMenuItem_Click(object sender, EventArgs e) =>
			ChangeGamemode(alphabetToolStripMenuItem, Difficulty.Alphabet);

		private void alphabetSoundOnlyToolStripMenuItem_Click(object sender, EventArgs e) => 
			ChangeGamemode(alphabetSoundOnlyToolStripMenuItem, Difficulty.AlphabetSoundOnly);

		private void missingCharacterToolStripMenuItem_Click(object sender, EventArgs e) => 
			ChangeGamemode(missingCharacterToolStripMenuItem, Difficulty.MissingCharacter);

		private void typeWordToolStripMenuItem_Click(object sender, EventArgs e) =>
			ChangeGamemode(typeWordToolStripMenuItem, Difficulty.TypeWord);

		private void autoPlayToolStripMenuItem_Click(object sender, EventArgs e)
		{
			autoPlayToolStripMenuItem.Checked = !autoPlayToolStripMenuItem.Checked;
			_autoPlay                         = autoPlayToolStripMenuItem.Checked;
		}
		private void readTypedLetterToolStripMenuItem_Click(object sender, EventArgs e)
		{
			readTypedLetterToolStripMenuItem.Checked = !readTypedLetterToolStripMenuItem.Checked;
			_readTypedLetter                         = readTypedLetterToolStripMenuItem.Checked;
		}

		private void Form1_KeyPress(object sender, KeyPressEventArgs e)
		{
			
			if (e.KeyChar == Convert.ToChar(Keys.Enter)) {
				if (_input.ToLower() == _answer) {
					StartGame();
				}
			} else if (e.KeyChar == Convert.ToChar(Keys.Back)) {
				if (_input.Length > 0)_input = _input.Substring(0, _input.Length - 1);
				inputLabel.Text = _input;
			} else {
				_input          += e.KeyChar;
				inputLabel.Text =  _input;
				string translation = _translator.LatinToCyrillic(_input);
				if (_readTypedLetter)
					ForcePlay(translation.Last().ToString());
				
			}
		}

	}
}