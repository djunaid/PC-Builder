using Application.Common.Models;
using Application.Tags.ViewModel;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Application.PCComponents.ViewModel
{
    public class PCComponentVM
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string Type { get; set; }

        public decimal Rating { get; set; }

        public List<TagVM> Tags { get; set; } = new();

        public List<PriceComponent>? PriceComponent { get; set; } = null;

        public int[] TagIds { get; set; }

        public decimal Price { get; set; }

        public Result Result { get; set; }

    }
}
