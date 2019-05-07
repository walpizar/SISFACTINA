using System;
using System.Collections.Generic;
using System.Text;

namespace AppFacturadorApi.Data
{
    public interface IData<T>
    {
        bool Agregar(T entity);
        bool Modificar(T entity);
        bool Eliminar(T entity);
        IEnumerable<T> ConsultarTodos(string idCliente);
        T ConsultarById(T entity);
    }
}
