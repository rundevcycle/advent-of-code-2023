using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AoC_2023_Day03
{
    public class PartNumber
    {
        public int Number { get; set; }
        public int LineNumber { get; set; }
        public int StartPosition { get; set; }
        public int EndPosition { get; set; }

        public bool IsValidPartNumber { get; set; } = false;
    }
}
