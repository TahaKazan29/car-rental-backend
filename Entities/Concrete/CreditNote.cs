using System;
using System.Collections.Generic;
using System.Text;
using Core.Entities;

namespace Entities.Concrete
{
    public class CreditNote:IEntity
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Tc { get; set; }
        public int FindeksValue { get; set; }
    }
}
