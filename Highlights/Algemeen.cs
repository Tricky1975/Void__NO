using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Windows;
using System.Windows.Controls;


namespace Void.Highlights {
    abstract class Algemeen {

        readonly public static Dictionary<string, Algemeen> HLDrivers = new Dictionary<string, Algemeen>();

        protected static void Print(string msg) {       
            Debug.WriteLine(msg);
            //Console.WriteLine(msg);
        }
        
        public static void Init() {
            Print("Loading Drivers");
            HLDrivers["NIL"] = new NIL();
        }

        abstract public void Highlight(RichTextBox RTB);

    }
}
