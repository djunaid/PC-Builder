using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PCBuilder.Domain.Entities
{
    public class PCComponentTag
    {
        public int PCComponentId { get; set; }

        public int TagId { get; set; }

        public PCComponentTag() { 
        }
       
    }
}
