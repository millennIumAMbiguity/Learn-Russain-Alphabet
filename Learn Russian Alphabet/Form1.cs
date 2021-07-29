﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Learn_Russian_Alphabet
{
	public partial class Form1 : Form
	{
		internal static ResourceManager Resources;
		private         string          _answer        = "";
		private         bool            _autoPlay      = true;
		private         bool            _disableSpeech = true;
		private         Difficulty      _gamemode;
		private         string          _input = "";
		private         bool            _isPlaying;
		private         bool            _readTypedLetter = true;

		private          SpeechSynthesizer  _speechSynthesizerObj;
		private          CyrillicTranslator _translator;
		private          string             _word    = "";
		private readonly List<Word>         gameData = new();
		public Form1() => InitializeComponent();

		private void Form1_Load(object sender, EventArgs e)
		{
			Resources   = new ResourceManager(typeof(Form1));
			_translator = new CyrillicTranslator();

			try {
				var synthesizer = new SpeechSynthesizer();
				synthesizer.SelectVoiceByHints(
					VoiceGender.NotSet, VoiceAge.NotSet, 0, CultureInfo.CreateSpecificCulture("ru-RU"));
				_speechSynthesizerObj                =  synthesizer;
				_speechSynthesizerObj.SpeakCompleted += SpeakCompleted;
				_disableSpeech                       =  false;
			} catch { MessageBox.Show(Resources.GetString("MSG-No_Speech_Synthesizer_found")); }


			ChangeGamemode(alphabetToolStripMenuItem, Difficulty.Alphabet);
			StartGame();
		}

		private void StartGame()
		{
			_input          = "";
			inputLabel.Text = _input;
			string oldWord = _word;
			int    index   = 0;
			while (_word == oldWord) {
				index = new Random().Next(0, gameData.Count);
				_word = gameData[index].Key;
			}

			label.Text = _gamemode == Difficulty.AlphabetSoundOnly
				? "?"
				: gameData[index].Key.ToUpper() + gameData[index].Key.ToLower();
			;
			_answer = gameData[index].Value.ToLower();
			if (_autoPlay) ForcePlay(_word);
		}

		private void SpeakCompleted(object obj, SpeakCompletedEventArgs args) => _isPlaying = false;

		private void PlayStop(string s)
		{
			if (_disableSpeech) return;
			if (_isPlaying) _speechSynthesizerObj.SpeakAsyncCancelAll();
			else _speechSynthesizerObj.SpeakAsync(s);
			_isPlaying = !_isPlaying;
		}

		private void ForcePlay(string s)
		{
			if (_disableSpeech) return;
			if (_isPlaying) _speechSynthesizerObj.SpeakAsyncCancelAll();
			_speechSynthesizerObj.SpeakAsync(s);
			_isPlaying = true;
		}

		private void label_Click(object sender, EventArgs e)
		{
			var me = (MouseEventArgs) e;
			if (me.Button == MouseButtons.Right) contextMenu.Show(this, me.Location + new Size(15, 11));
			else PlayStop(_word);
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

			if (path != null && File.Exists(path))
				using (var file = new StreamReader(path)) {
					string line;
					while ((line = file.ReadLine()) != null) {
						string[] s = line.Split(',');
						gameData.Add(new Word(s[0], s[1]));
					}
				}
			else MessageBox.Show($"{Resources.GetString("MSG-Missing_File")}\n{path}");

			StartGame();
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
				if (_input.ToLower() == _answer) StartGame();
			} else if (e.KeyChar == Convert.ToChar(Keys.Back)) {
				if (_input.Length > 0) _input = _input.Substring(0, _input.Length - 1);
				inputLabel.Text = _input;
			} else if (e.KeyChar == Convert.ToChar(Keys.Escape)) {
				if (_gamemode == Difficulty.AlphabetSoundOnly) label.Text = label.Text == "?" ? _word : _answer;
				else label.Text                                           = _answer;
			} else if (e.KeyChar == Convert.ToChar(Keys.Tab)) PlayStop(_word);
			else {
				_input          += e.KeyChar;
				inputLabel.Text =  _input;
				string translation = _translator.LatinToCyrillic(_input);
				if (_readTypedLetter)
					ForcePlay(translation.Last().ToString());
			}
		}
	}
}