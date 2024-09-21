using Application.Common.Interfaces;
using Azure.Core;
using MediatR;
using Microsoft.EntityFrameworkCore;
using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repository
{
    internal class TagRepository : ITagRepository
    {
        private readonly IApplicationDbContext _context;

        public TagRepository(IApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<int> CreateTagAsync(Tag tag, CancellationToken cancellationToken)
        {
            try
            {
                var dbTag = await _context.Tag.AddAsync(tag);

                await _context.SaveChangesAsync(cancellationToken);

                return dbTag.Entity.Id;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task DeleteTagAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                var tag = await _context.Tag.Where(x=> x.Id == id).FirstOrDefaultAsync(cancellationToken);

                if (tag is null)
                {
                    throw new Exception("Unable to delete tag is not found");
                }

                _context.Tag.Remove(tag);

                await _context.SaveChangesAsync(cancellationToken);

            }  
            catch (Exception) {
                throw;
            }
        }

        public async Task<IEnumerable<Tag>> GetAllTagsAsync(CancellationToken cancellationToken)
        {
            try
            {
            var tags = await _context.Tag.AsNoTracking().ToListAsync(cancellationToken);
            return tags;

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task<IEnumerable<Tag>?> GetAllTagsByNameAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Tag.Where(x => x.Name.Contains(name) || x.Value.Contains(name)).AsNoTracking().ToListAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }          

        }

        public async Task<Tag?> GetTagByIdAsync(int id, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Tag.Where(x => x.Id == id).AsNoTracking().FirstOrDefaultAsync(cancellationToken);
            }
            catch (Exception)
            {

                throw;
            }
           
        }


     
        public async Task<Tag?> GetTagByNameAsync(string name, CancellationToken cancellationToken)
        {
            try
            {
                return await _context.Tag.Where(x => x.Name == name).AsNoTracking().FirstOrDefaultAsync(cancellationToken);

            } catch (Exception)
            {
                throw;
            }
        }

        public async Task UpdateTagAsync(Tag tag, CancellationToken cancellationToken)
        {
            try
            {
                _context.Tag.Entry(tag).Property("SystemTimeStamp").OriginalValue = tag.SystemTimeStamp;

                _context.Tag.Update(tag);

                await _context.SaveChangesAsync(cancellationToken);
                
            }
            catch (DbUpdateConcurrencyException)
            {
                throw;
            } catch (DbUpdateException)
            {
                throw;
            }
        }
    }
}
