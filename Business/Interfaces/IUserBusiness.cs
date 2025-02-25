﻿using SistemaDeRecarga.Model;

public interface IUserBusiness
{
    Task<IEnumerable<User>> GetAllUserAsync();
    Task<User> CreateUserAsync(User user);
    Task UpdateUserAsync(User user);
    Task DeleteUserAsync(int id);
}