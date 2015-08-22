using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Training.Utilities.BaseCore.JSON
{
    public class JSONHoliday : JSONPage
    {
        public string DifficultyLabel { get; set; }
        public string Difficulty { get; set; }
        public string TerrainLabel { get; set; }
        public string Terrain { get; set; }
        public string TypeLabel { get; set; }
        public string Type { get; set; }
    }
}
