﻿using AuctionApp.Models;

namespace AuctionApp.DAO
{
    public interface IUserDao
    {
        User GetUserByUsername(string username);
    }
}
