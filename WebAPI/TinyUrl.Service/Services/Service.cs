using AutoMapper;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TinyUrl.Repository.Interface;
using TinyUrl.Service.Interface;

namespace TinyUrl.Service.Services
{
    public class Service: IService
    {
        public readonly IRepository _repository;
        public readonly IMapper _mapper;
        public Service(IRepository repository, IMapper mapper)
        {
              this._repository = repository;  
              this._mapper = mapper;
        }
    }
}

