using CsvHelper;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Office = Microsoft.Office.Core;
using Word = Microsoft.Office.Interop.Word;

namespace DataLookup
{
    public partial class nameSearchUC : UserControl
    {

        // Store all unique names loaded from the CSV
        private List<string> allFirstNames = new List<string>();
        private List<string> allSurnames = new List<string>();

        private Timer typingTimer;
        private string lastWord = "";
        private Word.ContentControl suggestionControl;


        public nameSearchUC()
        {
            InitializeComponent();
        }

 
        private void LoadNamesFromData()
        {
       

            List<NameAndProperties> records;
            using (var reader = new StreamReader(GetGhanaianNamesFilePath()))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
               records = csv.GetRecords<NameAndProperties>().ToList();
            }
        

            allFirstNames.AddRange(records.Select(r => r.OtherName).ToList());
            allSurnames.AddRange(records.Select(r => r.Surname).ToList());

            // Initialize ListBoxes with all data
            RefreshListBoxes(allFirstNames, allSurnames);
        }


        public string GetGhanaianNamesFilePath()
        {
            string path;

            #if DEBUG
                        // When running from Visual Studio
                        path = Path.Combine(
                            Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.Parent.FullName,
                            @"Data\GhanaianNames.csv"
                        );
            #else
                // When deployed as an add-in
                path = Path.Combine(
                    Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location),
                    "GhanaianNames.xlsx"
                );
            #endif

            return path;
        }

        private void RefreshListBoxes(List<string> filteredFirstNames, List<string> filteredSurnames)
        {
            // Ensure the controls exist before attempting to access them
            if (firstNameLBox != null)
            {
                firstNameLBox.Items.Clear();
                firstNameLBox.Items.AddRange(filteredFirstNames.ToArray());
            }

            if (surnameLBox != null)
            {
                surnameLBox.Items.Clear();
                surnameLBox.Items.AddRange(filteredSurnames.ToArray());
            }
        }

        // Public method to be called from ThisAddIn when text is typed in the document
        public void FilterNames(string filterText)
        {
            if (string.IsNullOrWhiteSpace(filterText))
            {
                // If the filter is empty, show all names
                RefreshListBoxes(allFirstNames, allSurnames);
                return;
            }

            string lowerFilter = filterText.ToLower();

            // Filter First Names
            var filteredFirstNames = allFirstNames
                .Where(name => name.ToLower().Contains(lowerFilter))
                .ToList();

            // Filter Surnames
            var filteredSurnames = allSurnames
                .Where(name => name.ToLower().Contains(lowerFilter))
                .ToList();

            RefreshListBoxes(filteredFirstNames, filteredSurnames);
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void nameSearchUC_Load(object sender, EventArgs e)
        {
            LoadNamesFromData();
            Globals.ThisAddIn.Application.WindowSelectionChange += Application_WindowSelectionChange;

            typingTimer = new Timer();
            typingTimer.Interval = 300;
            typingTimer.Tick += TypingTimer_Tick;
            typingTimer.Start();
        }

        private void Application_WindowSelectionChange(Word.Selection Sel)
        {
            typingTimer.Stop();
            typingTimer.Start();
        }

        private void TypingTimer_Tick(object sender, EventArgs e)
        {
            try
            {
                Word.Selection sel = Globals.ThisAddIn.Application.Selection;
                if (sel == null || sel.Range == null)
                    return;

                //Word.Range range = sel.Range.Duplicate;
                Word.Range range = sel.Range;

                // Move start to previous word safely
                try
                {
                    range.MoveStart(Word.WdUnits.wdWord, -1);
                }
                catch { /* ignore if at beginning */ }

                string currentWord = range.Text?.Trim();

                if (!String.IsNullOrEmpty(currentWord) && currentWord != lastWord)
                {
                        lastWord = currentWord;
                        GetSuggestion(currentWord);
                    
                }
                else if (String.IsNullOrEmpty(currentWord) && currentWord == lastWord)
                {
                    // Call the filter method on your custom control
                    FilterNames("");
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TypingTimer_Tick error: " + ex.Message);
            }
        }

        private void GetSuggestion(string word)
        {
            // Call the filter method on your custom control
            FilterNames(word);
        }
    }
}
