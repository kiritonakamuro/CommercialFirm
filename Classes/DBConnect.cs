using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommercialFirm.Models;

namespace CommercialFirm.Classes
{
    internal class DBConnect
    {
        public static Commercial_FirmEntities connectDB { get; set; } = new Commercial_FirmEntities();
    }
}
