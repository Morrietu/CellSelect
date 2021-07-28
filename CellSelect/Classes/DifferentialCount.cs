using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CellSelect.Classes
{
    /// <summary>
    /// Stores differential count entries, inherits from the Count class
    /// </summary>
    public class DifferentialCount
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
        public int Neutrophil { get; set; }
        public int Lymphocyte { get; set; }
        public int Monocyte { get; set; }
        public int Eosinophil { get; set; }
        public int Basophil { get; set; }
        public int AtypicalLymphocyte { get; set; }
        public int Metamyelocyte { get; set; }
        public int Myelocyte { get; set; }
        public int Promyelocyte { get; set; }
        public int Blast { get; set; }
        // User entered title
        public string DiffTitle { get; set; }
    }
}
