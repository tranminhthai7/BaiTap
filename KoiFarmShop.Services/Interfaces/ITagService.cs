using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;

namespace KoiFarmShop.Services.Interfaces
{
    public interface ITagService
    {
        Task<List<TbTag>> GetTagsAsync();
        Task<int> AddTagAsync(TbTag tag);
        Task<int> RemoveTagAsync(int tagId);
        Task<bool> DeleteTagAsync(int tagId);
        Task<int> UpdateTagAsync(TbTag tag);
    }
}