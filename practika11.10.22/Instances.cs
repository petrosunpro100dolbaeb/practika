﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace practika11._10._22
{
    internal class Instances
    {
        private static up_11_02Entities _db = null;

        public static up_11_02Entities db
        {
            get
            {
                if (_db == null)
                    _db = new up_11_02Entities();
                return _db;
            }
        }
    }
}
