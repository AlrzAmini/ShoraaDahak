﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoraaDahak.Core.Convertors
{
    public class FixText
    {
        public static string EmailFixer(string email)
        {
            return email.Trim().ToLower();
        }
    }
}
