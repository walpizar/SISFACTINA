using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Service
{
    public interface IService<T>
    {
        bool Agregar(T entity);
        bool Modificar(T entity);
        bool Eliminar(T entity);
        IEnumerable<T> ConsultarTodos(string idCliente);
        T ConsultarById(T entity);
    }
}
