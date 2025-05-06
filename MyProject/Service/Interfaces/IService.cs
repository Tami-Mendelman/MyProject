﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Interfaces
{
    //הלוגיקה העיסקית כאן
    public interface IService<T>
    {
       Task< T> GetById(int id);
       Task< List<T> >GetAll();
       Task< T> AddItem(T item);
        Task DeleteItem(int id);
        Task UpdateItem(int id, T item);
    }
}
