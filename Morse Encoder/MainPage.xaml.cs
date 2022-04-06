using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Morse_Encoder
{
    public partial class MainPage : ContentPage
    {
        // international morse code
        private Dictionary<string, char> MORSE_MAP = new Dictionary<string, char>() {
           { ".-", 'a' },
           { "-...", 'b' },
           { "-.-.", 'c' },
           { "-..", 'd' },
           { ".", 'e' },
           { "..-.", 'f' },
           { "--.", 'g' },
           { "....", 'h' },
           { "..", 'i' },
           { ".---", 'j' },
           { "-.-", 'k' },
           { ".-..", 'l' },
           { "--", 'm' },
           { "-.", 'n' },
           { "---", 'o' },
           { ".--.", 'p' },
           { "--.-", 'q' },
           { ".-.", 'r' },
           { "...", 's' },
           { "-", 't' },
           { "..-", 'u' },
           { "...-", 'v' },
           { ".--", 'w' },
           { "-..-", 'x' },
           { "-.--", 'y' },
           { "--..", 'z' },
           { ".----", '1' },
           { "..---", '2' },
           { "...--", '3' },
           { "....-", '4' },
           { ".....", '5' },
           { "-....", '6' },
           { "--....", '7' },
           { "---..", '8' },
           { "----.", '9' },
           { "-----", '0' },
        };

        public MainPage()
        {
            InitializeComponent();

            StyleButton(morse_dot_btn);
            StyleButton(morse_dash_btn);
            StyleButton(morse_gap_btn);
            StyleButton(morse_back_btn);
        }

        private void StyleButton(Button btn) {
            btn.Font = Font.OfSize("monospace", 24);
            btn.BackgroundColor = Color.FromHex("#EEE");
            btn.BorderColor = Color.FromHex("#CCC");
            btn.BorderWidth = 2;
        }

        private void ParseSymbol(char symbol)
        {
            if (symbol == ' ') {
                char value = '_';
                if (MORSE_MAP.ContainsKey(morse_active.Text)) { value = MORSE_MAP[morse_active.Text]; }
                morse_encoded.Text += value;
                morse_active.Text = "";
            }

            else if (symbol == '<') {
                if (morse_active.Text == "" && morse_encoded.Text != "") { morse_encoded.Text = morse_encoded.Text.Remove(morse_encoded.Text.Length - 1, 1); }
                else if (morse_active.Text != "" && morse_active.Text != "") { morse_active.Text = morse_active.Text.Remove(morse_active.Text.Length - 1, 1); }
            }

            else { morse_active.Text += symbol; }
        }

        private void morse_dot_btn_Clicked(object sender, EventArgs e) { ParseSymbol('.'); }
        private void morse_dash_btn_Clicked(object sender, EventArgs e) { ParseSymbol('-'); }
        private void morse_gap_btn_Clicked(object sender, EventArgs e) { ParseSymbol(' '); }
        private void morse_back_btn_Clicked(object sender, EventArgs e) { ParseSymbol('<'); }
    }
}
