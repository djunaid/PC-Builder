using Application.Common.Models;
using Application.Common.Models.Interface;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.PCComponents.Commands
{
    public record CreateComponentCommand : IRequest<Result>
    {
        public string Name { get; set; }

        public string Type {  get; set; }

        public int[] Tags { get; set; }

        public decimal Price { get; set; }

        public string CreatedBy { get; set; }   
       
    }

    public class CreateComponentHandler : IRequestHandler<CreateComponentCommand, Result>
    {
        private readonly IPCComponentRepository _pcComponentRepository;

        public CreateComponentHandler(IPCComponentRepository pcComponentRepository)
        {
            _pcComponentRepository = pcComponentRepository;
        }

        public async Task<Result> Handle(CreateComponentCommand request, CancellationToken cancellationToken)
        {
            
            try
            {
                List<PCComponentTag> pcComponentTags = new();
                foreach(var tagId in request.Tags)
                {
                    PCComponentTag pCComponentTag = new PCComponentTag();
                    pCComponentTag.TagId = tagId;

                    pcComponentTags.Add(pCComponentTag);
                }

                PriceComponent price = new PriceComponent
                {
                    Price = request.Price,
                    CreatedBy = request.CreatedBy,
                    Created = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                    EffectiveDate = DateTime.UtcNow
                };

                PCComponent pCComponent = new PCComponent()
                {
                    Name = request.Name,
                    Type = request.Type,
                    CreatedBy = request.CreatedBy,
                    PCComponentTags = pcComponentTags,
                    Created = DateTime.UtcNow,
                    LastModified = DateTime.UtcNow,
                };

                pCComponent.AddPriceComponent(price);
                

                var response = await _pcComponentRepository.CreateComponentAsync( pCComponent ,  cancellationToken);

                return Result.Success();

            } catch (Exception ex)
            {
                var error = ex.ToString();

                return Result.Failure(new List<string>() { error });
            }
        }
    }
}
