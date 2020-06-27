using AutoMapper;
using Genpad.Services.Configurations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genpad.Services
{
    public abstract class ServiceBase
    {
        public IMapper Mapper { get; set;  }

        public ServiceBase()
        {
            InitMapper();
        }

        private void InitMapper()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));
            Mapper = config.CreateMapper();
        }
    }
}
