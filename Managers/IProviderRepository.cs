using PhyndDemo_v2.DTOs;
using PhyndDemo_v2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PhyndDemo_v2.Managers
{
    public interface IProviderRepository
    {
        IEnumerable<Provider> GetProviders();
        Provider GetProvider(int id);
        void AddProvider(Provider provider);
        void Update(Provider provider, ProviderDTO providerDTO);
        void DeleteProvider(Provider provider);

    }
}
