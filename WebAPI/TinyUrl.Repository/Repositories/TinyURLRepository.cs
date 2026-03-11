using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.XPath;
using TinyUrl.Repository.Interface;
using TinyUrl.Repository.Model;

namespace TinyUrl.Repository.Repositories
{
    public class TinyURLRepository : ITinyURLRepository
    {
        private readonly AppDBContext _dbContext;

        public TinyURLRepository(AppDBContext dbContext)
        {
            this._dbContext = dbContext;
        }
        public async Task<Model.TinyUrl> AddTinyURL(Model.TinyUrl tinyUrlModel)
        {
           
            _dbContext.TinyUrls.Add(tinyUrlModel);
            await _dbContext.SaveChangesAsync();
            return tinyUrlModel;
        }

        public async  Task<bool> DeleteAllTinyURL()
        {
            var allUrls = await _dbContext.TinyUrls.AsNoTracking().ToListAsync();
            _dbContext.TinyUrls.RemoveRange(allUrls);
            var result= await _dbContext.SaveChangesAsync();
            return result > 0;
        }

        public async Task<bool> DeleteTinyURLByCode(string code)
        {
            var tinyUrl = await _dbContext.TinyUrls.SingleOrDefaultAsync(x => x.ShortCode == code);

            if (tinyUrl == null)
                return false; 
            _dbContext.TinyUrls.Remove(tinyUrl);
            return await _dbContext.SaveChangesAsync() > 0;
        }

        public async Task<List<Model.TinyUrl>> GetAllTinyPubicURL()
        {
            var allUrls = await _dbContext.TinyUrls.Where(z=>z.IsPrivate==false).AsNoTracking().ToListAsync();
            return allUrls;

        }

        public async Task<HashSet<string>> GetExistingShortCode()
        {
            var shortCode = await _dbContext.TinyUrls.Select(w => w.ShortCode).ToHashSetAsync();
            return shortCode;
        }

        public async Task<Model.TinyUrl> GetTinyURLByCode(string code)
        {
            var tinyUrl = await _dbContext.TinyUrls.AsNoTracking().SingleOrDefaultAsync(x => x.ShortCode == code);
            return tinyUrl;
        }

        public async Task<Model.TinyUrl> UpdateTinyURLByCode(string code)
        {
            var tinyUrl = await _dbContext.TinyUrls.AsNoTracking().SingleOrDefaultAsync(x => x.ShortCode == code);
            if (tinyUrl != null) 
            { 
            tinyUrl.TotalClickCount = tinyUrl.TotalClickCount + 1;
            _dbContext.TinyUrls.Update(tinyUrl);
            await  _dbContext.SaveChangesAsync();
            }
            return tinyUrl;
        }
    }
}
