// Lic:
// Void
// Simple Editor for NIL and a few other languages
// 
// 
// 
// (c) Jeroen P. Broks, 
// 
// This program is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// This program is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// You should have received a copy of the GNU General Public License
// along with this program.  If not, see <http://www.gnu.org/licenses/>.
// 
// Please note that some references to data like pictures or audio, do not automatically
// fall under this licenses. Mostly this is noted in the respective files.
// 
// Version: 19.07.11
// EndLic

#define AlwaysNIL

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Void {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        bool HL_BLOCK = false;
        private void TextChangedEventHandler(object sender, TextChangedEventArgs e) {
            // Nothing here, then get the hell out of here!
            if (TextInput.Document == null) return;
            if (HL_BLOCK) return;
            HL_BLOCK = true;
            // Clear all previos settings! They can only spook things up!
            var documentRange = new TextRange(TextInput.Document.ContentStart, TextInput.Document.ContentEnd);
            documentRange.ClearAllProperties();
            var TXT = documentRange.Text;

            var recognizedas = "";
#if AlwaysNIL
            recognizedas = "NIL";
#else
#endif
            if (recognizedas != "") {
                Highlights.Algemeen.HLDrivers[recognizedas].Highlight(TextInput,TXT);
            }
            HL_BLOCK = false;
        }
    }
}


