using System;
using System.Collections.Generic;
using System.Text;

namespace _10._The_Heigan_Dance
{
    public class Position
    {
        public int row { get; set; }
        public int col { get; set; }
        public Position()
        {

        }
        public Position(int Row, int Col)
        {
            this.row = Row;
            this.col = Col;
        }
    }
}
