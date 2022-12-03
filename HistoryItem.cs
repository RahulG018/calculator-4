using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace Calculator
{

    [Table("exprsn name")]
    public class HistoryItem
    {
        [MaxLength(210)]
        public string QuestionAnswer { get; set; }
       

        
    }
}
