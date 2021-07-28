using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CellSelect.Classes
{
    /// <summary>
    /// Stores cell count entries, inherits from the Count class
    /// </summary>
    public class CellCount
    {
        // Primary key
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        // Cell types
        public int WhiteCell { get; set; }
        // Specimen type
        public string FluidType { get; set; }
        // Dates created and altered 
        public DateTime DateCreated { get; set; }
        public DateTime DateModified { get; set; }
        // Cell types
        public int RedCell { get; set; }
        // User entered title
        public string CountTitle { get; set; }
    }
}
