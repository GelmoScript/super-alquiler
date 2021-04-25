using System;
namespace SuperAlquiler.Entities
{
    public interface IClonador<T>
    {
        T Clonar();
    }
}
