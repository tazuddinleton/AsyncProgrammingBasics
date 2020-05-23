using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AsynchrounousProgrammingBasics
{
    public class NameController
    {
        private readonly NameRepository _nameRepository;
        public NameController()
        {
            _nameRepository = new NameRepository();
        }
        public async Task<List<string>> GetNames()
        {
            return await _nameRepository.GetNames();
        }

        public async Task<List<string>> GetAddresses()
        {
            return await _nameRepository.GetNames();
        }
    }
}
