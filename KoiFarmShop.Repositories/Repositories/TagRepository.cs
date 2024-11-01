using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly KoiFarmShop2024DbContext _dbContext;

        public TagRepository(KoiFarmShop2024DbContext dbContext) 
        {
            _dbContext = dbContext;
        }

        public Task<bool> AddTag(Tag tag)
        {
            try
            {
                _dbContext.Tags.AddAsync(tag);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex) 
            {
                throw new NotImplementedException(ex.ToString());
            }
        }

        public async Task<bool> DeleteTagAsync(int tagId)
        {
            var objDel = await _dbContext.Tags.Where(p => p.Id.Equals(tagId)).FirstOrDefaultAsync();
            try
            {
                if (objDel != null)
                {
                    _dbContext.Tags.Remove(objDel);
                    await _dbContext.SaveChangesAsync();
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                // Log the exception
                return false;
            }
        }

        public async Task<List<Tag>> GetTags()
        {
            List<Tag> tags = null;
            try
            {
                tags = await _dbContext.Tags.ToListAsync();
            }
            catch (Exception ex) 
            {
                tags?.Add(new Tag());
            }
            return tags;
        }

        public Task<bool> RemoveTagAsync(Tag tag)
        {
            throw new NotImplementedException();
        }

        public Task<bool> UpdateTag(Tag tag)
        {
            try
            {
                _dbContext.Tags.Update(tag);
                _dbContext.SaveChanges();
                return Task.FromResult(true);
            }
            catch (Exception ex)
            {
                return Task.FromResult(false);
            }
        }
    }
}
