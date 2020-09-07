using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TawfikStoreBackEnd.Entities.Helpers
{
    public class ProductQueryData : IQueryData
    {
        public int pageNum { get; set; }

        public int pageSize { get; set; }

        public string sortBy { get; set; }

        public bool isSortAsc { get; set; }

        public string searchWith { get; set; }

        public int CategoryId { get; set; }


    }
}
