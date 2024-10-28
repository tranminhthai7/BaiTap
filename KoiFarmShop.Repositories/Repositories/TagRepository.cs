using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using KoiFarmShop.Repositories.Entities;
using KoiFarmShop.Repositories.Interfaces;

namespace KoiFarmShop.Repositories.Repositories
{
    public class TagRepository : ITagRepository
    {
        private readonly KoiFarmShopDbContext _dbContext;

        public TagRepository(KoiFarmShopDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<TbTag>> GetTagsAsync()
        {
            try
            {
                return await _dbContext.TbTags.ToListAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return new List<TbTag>();
            }
        }

        public async Task<int> AddTagAsync(TbTag tag)
        {
            try
            {
                await _dbContext.TbTags.AddAsync(tag);
                await _dbContext.SaveChangesAsync();
                return tag.Id; // Assuming Id is the primary key and is auto-generated
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<int> RemoveTagAsync(int tagId)
        {
            var tag = await _dbContext.TbTags.FindAsync(tagId);
            if (tag == null)
            {
                return 0; // Return 0 to indicate that the record was not found
            }

            try
            {
                _dbContext.TbTags.Remove(tag);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }

        public async Task<bool> DeleteTagAsync(int tagId)
        {
            var tag = await _dbContext.TbTags.FindAsync(tagId);
            if (tag == null)
            {
                return false; // Return false to indicate that the record was not found
            }

            try
            {
                _dbContext.TbTags.Remove(tag);
                await _dbContext.SaveChangesAsync();
                return true; // Return true to indicate success
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return false; // Return false to indicate failure
            }
        }

        public async Task<int> UpdateTagAsync(TbTag tag)
        {
            try
            {
                _dbContext.TbTags.Update(tag);
                return await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                // Log exception (ex) here if needed
                return 0; // Return 0 to indicate failure
            }
        }
    }
}