using CsvHelper;
using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLookup
{
    public class NameAndProperties
    {
        // CSV Columns:
        public string Surname { get; set; }
        public string OtherName { get; set; }
    }
}
