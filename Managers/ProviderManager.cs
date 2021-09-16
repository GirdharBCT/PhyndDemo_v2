using AutoMapper;
using PhyndDemo_v2.Data;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PhyndDemo_v2.DTOs;

namespace PhyndDemo_v2.Managers
{
    public class ProviderManager : IProviderRepository
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
        
        public Provider GetProvider(int Id)
        {
            return context.Providers.FirstOrDefault(a => a.Id == Id);
        }

        public void AddProvider(Provider provider)
        { 
            var newProvider = mapper.Map<Provider>(provider);
            context.Providers.Add(newProvider);
            context.SaveChanges();
        }

        public void DeleteProvider(Provider provider)
        {
            context.Providers.Remove(provider);
            context.SaveChanges();
        }

        public void Update(Provider provider, ProviderDTO newProvider)
        {
            var entity = mapper.Map<Provider>(newProvider);

            provider.FirstName = entity.FirstName;
            provider.MiddleName = entity.MiddleName;
            provider.LastName = entity.LastName;
            provider.HospitalId = entity.HospitalId;
            provider.CreatedBy = entity.CreatedBy;
            provider.CreatedOn = entity.CreatedOn;
            provider.ModifiedBy = entity.ModifiedBy;
            provider.IsDeleted = entity.IsDeleted;

            context.SaveChanges();
        }
    }
}
