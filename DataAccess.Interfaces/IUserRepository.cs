﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUserRepository : IRepository<User,long>
    {
        Task<User?> GetByLoginAsync(string login);
    }
}
