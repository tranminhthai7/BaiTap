using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;

namespace KoiFarmShop.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository)
        {
            _tagRepository = tagRepository;
        }

        public Task<List<TbTag>> GetTagsAsync()
        {
            return _tagRepository.GetTagsAsync();
        }

        public Task<int> AddTagAsync(TbTag tag)
        {
            return _tagRepository.AddTagAsync(tag);
        }

        public Task<int> RemoveTagAsync(int tagId)
        {
            return _tagRepository.RemoveTagAsync(tagId);
        }

        public Task<bool> DeleteTagAsync(int tagId)
        {
            return _tagRepository.DeleteTagAsync(tagId);
        }

        public Task<int> UpdateTagAsync(TbTag tag)
        {
            return _tagRepository.UpdateTagAsync(tag);
        }
    }
}