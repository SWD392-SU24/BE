﻿using Backend.BO.Commons;
using Backend.BO.Payloads.Requests;

namespace Backend.DAL.Repositories.Contracts
{
    public interface IUserRepository : IRepository<User>
    {
        //Task<User?> Authenticate(AuthRequest request);
    }
}