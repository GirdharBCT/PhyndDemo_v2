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

        public IEnumerable<Provider> GetProviders()
        {
            return context.Providers.ToList();
        }
        
        public IEnumerable<Provider> GetProvider(int Id)
        {
            return context.Providers.FirstOrDefault(a => a.Id == Id);
        }

        public void AddProvider(Provider provider)
        { 
            if(provider == null)
            { 
                throw new ArgumentNullException(nameof(provider));
            }
            context.Providers.Add(provider);
        }

        public void DeleteProvider(Provider provider)
        {
            if (provider == null)
            {
                throw new ArgumentNullException(nameof(provider));
            }
            context.Providers.Remove(provider);
        }
        
        public Provider EditProvider(Provider provider) {
            var existingProvider=GetProvider(provider.Id);
            existingProvider.Firstname=provider.FirstName;
            return existingProvider;
        }
    }
}
