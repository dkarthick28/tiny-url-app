using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.ViewModels;

namespace TinyUrl.Service.Interface
{
    public interface ITinyURLService
    {
        public Task<TinyURLDTOViewModel> AddTinyURL(TinyURLAddViewModel tinyURLAddViewModel);
        public Task<bool> DeleteTinyURLByCode(string code);
        public Task<bool> DeleteAllTinyURL();
        public Task<TinyURLDTOViewModel> GetTinyURLByCode(string code);
        public Task<List<TinyURLDTOViewModel>> GetAllTinyPubicURL();
        public Task<HashSet<string>> GetExistingShortCode();
        public Task<TinyURLDTOViewModel> UpdateTinyURLByCode(string code);
    }
}
