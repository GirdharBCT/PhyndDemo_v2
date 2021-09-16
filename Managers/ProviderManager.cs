using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public class ProviderManager
    {
        private readonly phynd2Context context;
        private readonly IMapper mapper;

        public ProviderManager(phynd2Context context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        p+ublic IEnumerable<Provider> GetProviders()
        {
            return context.Providers.ToList();
        }
        
        public IEnumerable<Provider> GetProvider(int id)
        {
            return context.Providers.FirstOrDefault(a => a.id == id);
        }

        public void AddProvider(Provider provider)
        { 
            if(provider == null)
            { 
                throw new ArgumentNullException(nameof(provider));
            }
            context.Providers.Add(provider);
        }
    }
}
