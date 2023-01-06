using Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryWrapper : IRepositoryWrapper
    {
        private IQuoteRequestRepository _quote;
        private ILocationRepository _location;

        public IQuoteRequestRepository QuoteRepo
        {
            get
            {
                if (_quote == null)
                {
                    _quote = new QuoteRequestRepository(); 
                }
                return _quote;
            }
        }

        public ILocationRepository LocationRepo
        {
            get
            {
                if (_location == null)
                {
                    _location = new LocationRepository();
                }
                return _location;
            }
        }

        public RepositoryWrapper() { }
    }
}
