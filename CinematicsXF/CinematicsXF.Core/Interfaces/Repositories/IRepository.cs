﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CinematicsXF.Core
{
    public interface IRepository
    {
        void Init(IRepository repository);
        Task SaveAsync<T>(string id, T model);
        Task<T> LoadAsync<T>(string id);
        Task<T> LoadAsync<T>(Func<T, bool> predExpr);
        Task DeleteAsync<T>(string id);
        Task DeleteAllAsync<T>();
        Task<IEnumerable<T>> GetAllAsync<T>();
        Task<IEnumerable<T>> GetAllAsync<T>(Func<T, bool> predExpr);
    }
}
