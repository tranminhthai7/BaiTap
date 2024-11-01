using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Repositories.Interfaces
{
    public interface ITagRepository
    {
        Task<List<Tag>> GetTags();
        Task<bool> AddTag(Tag tag);
        Task<bool> RemoveTagAsync(Tag tag);
        Task<bool> DeleteTagAsync(int tagId);
        Task<bool> UpdateTag(Tag tag);
    }
}