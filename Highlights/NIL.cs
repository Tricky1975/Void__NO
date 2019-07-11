using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media;


using TrickyUnits;

namespace Void.Highlights {
    class NIL:Algemeen {

        static List<string> GenNILKeyWords() {
            string[] l = { "void","int","number","string","self","function","delegate","bool","boolean","table","end","for","repeat","until","forever","if","while","class","get","set","global","nil" };
            return new List<string>(l);
        }

        static List<char> GenNILTags() {
            char[] c = {
                '.',
                ')',
                '(',
                '[',
                ']',
                '>',
                '<',
                ':',
                ';',
                '\n',
                '\t'
            };

            return new List<char>(c);
        }

        static List<string> Keywords = GenNILKeyWords();
        static List<char> Tags = GenNILTags();


        public NIL() {
            Print("NIL Driver present");
        }

        class Tag {
            public TextPointer StartPosition;
            public TextPointer EndPosition;
            public string Word;
        }

        public override void Highlight(RichTextBox RTB, string text) {
            TextPointer TP;
            //Print(TXT);
            int sIndex = 0;
            int eIndex = 0;
            //bool IsKnownKW(string gword) => Keywords.Exists(delegate (string s) { return s.ToLower().Equals(gword.ToLower()); });
            var kws = new List<Tag>();
            // Scan the source code
            for (int i = 0; i < text.Length; i++) {
                if (char.IsWhiteSpace(text[i]) || Tags.Contains(text[i])) {
                    if (i > 0 && !(char.IsWhiteSpace(text[i - 1]) || Tags.Contains(text[i - 1]))) {
                        eIndex = i - 1;
                        string word = text.Substring(sIndex, eIndex - sIndex + 1);
                        Print($"{i}/{text.Length}: Check word '{word}' at position {sIndex}-{eIndex} -- Keyword: {Keywords.Contains(word)} -- {kws.Count}");
                        if (Keywords.Contains(word)) {
                            Tag t = new Tag();
                            t.StartPosition = RTB.Document.ContentStart.GetPositionAtOffset(sIndex, LogicalDirection.Forward);
                            t.EndPosition = RTB.Document.ContentStart.GetPositionAtOffset(eIndex + 1, LogicalDirection.Backward);
                            t.Word = word;
                            kws.Add(t);
                        }
                    }
                    sIndex = i + 1;
                }
            }
            foreach (Tag kw in kws) {
                TextRange range = new TextRange(kw.StartPosition, kw.EndPosition);
                range.ApplyPropertyValue(TextElement.ForegroundProperty, new SolidColorBrush(Colors.Blue));                
                //range.ApplyPropertyValue(TextElement.FontWeightProperty, FontWeights.Bold);
            }
            kws.Clear();
        }

        public override bool Recognize(string filename) {
            return qstr.ExtractExt(filename.ToUpper()) == "NIL";
        }
    }
}
