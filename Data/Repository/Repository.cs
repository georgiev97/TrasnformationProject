using Data.DataContext;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repository
{
    public class Repository
    {
        private TransformationContext _context = null;

        public Repository(TransformationContext context)
        {
            _context = context;
        }

    }
}
