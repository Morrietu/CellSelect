using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CellSelect.Classes
{
    /// <summary>
    /// Baase from which other count classes will inherit
    /// </summary>
    public class Count
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
    }
}
