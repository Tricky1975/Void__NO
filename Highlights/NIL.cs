using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace Void.Highlights {
    class NIL:Algemeen {

        public NIL() {
            Print("NIL Driver present");
        }

        public override void Highlight(RichTextBox RTB) {
            throw new NotImplementedException();
        }
    }
}
