using Microsoft.Office.Interop.Word;
using Microsoft.Office.Tools.Ribbon;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Word = Microsoft.Office.Interop.Word;

namespace DataLookup
{
    public partial class LookupRibbon
    {
        private nameSearchUC myNameSearchUC; // Replace UserControl1 with your control's name
        private Microsoft.Office.Tools.CustomTaskPane myNameSearchTaskPane;
        private void LookupRibbon_Load(object sender, RibbonUIEventArgs e)
        {

        }

        private void button1_Click(object sender, RibbonControlEventArgs e)
        {
            // 1. Instantiate the user control
            myNameSearchUC = new nameSearchUC();

            myNameSearchTaskPane = Globals.ThisAddIn.CustomTaskPanes.Add(myNameSearchUC, "Name Suggestions");

            // 3. Make the task pane visible (optional, you can control visibility later)
            myNameSearchTaskPane.Visible = true;
            myNameSearchTaskPane.Width = 300; // Set a suitable width

        }


    }
}
