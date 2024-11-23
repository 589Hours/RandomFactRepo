using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RandomFactApp.Domain.Models;

namespace RandomFactApp.Domain.Clients
{
    public interface IRandomFactClient
    {
        Task<RandomFact> RetrieveRandomFactAsync(string language);
    }
}
