using Application.Interfaces.Mapeamento;
using Domain.Entites.Base;

namespace Application.Interfaces;

public interface IInputEntity<T> : BaseMapeamento where T : EntityBase
{
    public int? Id { get; set; }
}
