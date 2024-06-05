using PCBuilder.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories.Interface
{
    public interface ITagRepository
    {
        Task<IEnumerable<Tag>> GetAllTagsAsync(CancellationToken cancellationToken);
        Task<Tag?> GetTagByIdAsync(int id, CancellationToken cancellationToken);

        Task<Tag?> GetTagByNameAsync(string name, CancellationToken cancellationToken);

        Task<IEnumerable<Tag>?> GetAllTagsByNameAsync(string name, CancellationToken cancellationToken);
        Task<int> CreateTagAsync(Tag tag, CancellationToken cancellationToken);

        Task UpdateTagAsync(Tag tag, CancellationToken cancellationToken);

        Task DeleteTagAsync(int id, CancellationToken cancellationToken);

    }
}
