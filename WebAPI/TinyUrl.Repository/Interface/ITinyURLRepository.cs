using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Repository.Model;

namespace TinyUrl.Repository.Interface
{
    public interface ITinyURLRepository
    {
        public Task<TinyUrl.Repository.Model.TinyUrl> AddTinyURL(TinyUrl.Repository.Model.TinyUrl tinyURLAddViewModel);
        public Task<bool> DeleteTinyURLByCode(string code);
        public Task<bool> DeleteAllTinyURL();
        public Task<TinyUrl.Repository.Model.TinyUrl> GetTinyURLByCode(string code);
        public Task<List<TinyUrl.Repository.Model.TinyUrl>> GetAllTinyPubicURL();
        public Task<HashSet<string>> GetExistingShortCode();
        public Task<TinyUrl.Repository.Model.TinyUrl> UpdateTinyURLByCode(string code);
    }
}
