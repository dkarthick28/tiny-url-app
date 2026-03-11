using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Repository.Interface;
using TinyUrl.Service.Interface;
using TinyUrl.ViewModels;

namespace TinyUrl.Service.Services
{
    public class TinyURLService: ITinyURLService
    {
        private readonly ITinyURLRepository _repository;
        private readonly IMapper _mapper;
        public TinyURLService(ITinyURLRepository repository, IMapper mapper)
        {
              this._repository = repository;  
              this._mapper = mapper;
        }

        public async Task<TinyURLDTOViewModel> AddTinyURL(TinyURLAddViewModel tinyURLAddViewModel)
        {
            var shortCode = await GenerateUniqueCode(6);
            var tinyurl = _mapper.Map<TinyUrl.Repository.Model.TinyUrl>(tinyURLAddViewModel);
            tinyurl.ShortCode = shortCode;
            var result = await _repository.AddTinyURL(tinyurl);
            var resp= _mapper.Map<TinyURLDTOViewModel>(result);
            return resp;
        }

        public async Task<bool> DeleteAllTinyURL()
        {
            var result = await _repository.DeleteAllTinyURL();
            return result;
        }

        public async Task<bool> DeleteTinyURLByCode(string code)
        {
           var result= await _repository.DeleteTinyURLByCode(code);
           return result;
        }

        public async Task<List<TinyURLDTOViewModel>> GetAllTinyPubicURL()
        {
            var result = await _repository.GetAllTinyPubicURL();
            var resp = _mapper.Map<List<TinyURLDTOViewModel>>(result);
            return resp;
        }

        public async Task<HashSet<string>> GetExistingShortCode()
        {
            var result = await _repository.GetExistingShortCode();
            return result;
        }

        public async Task<TinyURLDTOViewModel> GetTinyURLByCode(string code)
        {
            var result = await _repository.GetTinyURLByCode(code);
            var resp = _mapper.Map<TinyURLDTOViewModel>(result);
            return resp;
        }

        public async Task<TinyURLDTOViewModel> UpdateTinyURLByCode(string code)
        {
            var result = await _repository.UpdateTinyURLByCode(code);
            var resp = _mapper.Map<TinyURLDTOViewModel>(result);
            return resp;
        }

        private async Task<string> GenerateUniqueCode(int length)
        {
            string code;
            int noOfAttempts = 1000;
            HashSet<string> _existingShortCode = await GetExistingShortCode();

            do
            {
                code = GenerateRandomCode(length);

                if (noOfAttempts < 0)
                    throw new InvalidOperationException("Unable to generate a Unique code after ");
                noOfAttempts--;
            } while (_existingShortCode.Contains(code));

            return code;
        }

        private string GenerateRandomCode(int length)
        {
        char[] _shortcode = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789".ToCharArray();

        char[] charCode = new char[length];
            using (var ran = RandomNumberGenerator.Create())
            {
                byte[] randomBytes = new byte[length];
                ran.GetBytes(randomBytes);
                for (int i = 0; i < length; i++)
                    charCode[i] = _shortcode[randomBytes[i] % charCode.Length];
            }

            return new string(charCode);
        }

        
    }
}

