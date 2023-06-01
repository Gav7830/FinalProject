using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class CarModel
    {
        public int Id { get; set; }
        public int CarNameId { get; set; }
        public string Name { get; set; }
        public int NumberOfDoors { get; set; }
        public string TransmissionAndDrive { get; set; }
        public string FuelAndAC { get; set; }
    }
}
