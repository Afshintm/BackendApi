﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Infrastructure
{
    public interface IConfig
    {
        string TestUserName { get; }
    }
}