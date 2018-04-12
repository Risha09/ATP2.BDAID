﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ATP2.BDAID.Data;

namespace ATP2.BDAID.Repo.Base
{
    public class BaseRepo
    {
        private static BDAIDDbContext _context;
        public static BDAIDDbContext DbContext
        {
            get
            {
                if (_context == null)
                    _context = new BDAIDDbContext();
                return _context;
            }
        }
    }
}