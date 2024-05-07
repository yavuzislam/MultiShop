﻿namespace MultiShop.Cargo.BusinessLayer.Abstract;

public interface IGenericService<T> where T : class
{
    List<T> TGetAll();
    T TGetById(int id);
    void TInsert(T entity);
    void TUpdate(T entity);
    void TDelete(int id);
}
