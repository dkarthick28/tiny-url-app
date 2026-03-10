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
        public Service(IRepository repository)
        {
              this._repository = repository;  
        }
    }
}
