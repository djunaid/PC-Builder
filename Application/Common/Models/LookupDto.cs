using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Common.Models
{
    public class LookupDto
    {
        public int Id { get; init; }

        public string? Title { get; init; }

        private class Mapping : Profile
        {
            public Mapping()
            {
                //Create Map here
            }
        }
    }
}
