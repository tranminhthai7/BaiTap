using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KoiFarmShop.Services.Services
{
    public class TagService : ITagService
    {
        private readonly ITagRepository _tagRepository;

        public TagService(ITagRepository tagRepository) {
            _tagRepository = tagRepository;
        }

        public Task<bool> AddTag(Tag tag)
        {
            return _tagRepository.AddTag(tag);
        }

        public Task<bool> DeleteTagAsync(int tagId)
        {
            return _tagRepository.DeleteTagAsync(tagId);
        }

        public async Task<List<Tag>> GetTags()
        {
            return await _tagRepository.GetTags();
        }

        public Task<bool> UpdateTag(Tag tag)
        {
            return _tagRepository.UpdateTag(tag);
        }

        public Task<bool> RemoveTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }
    }
}
