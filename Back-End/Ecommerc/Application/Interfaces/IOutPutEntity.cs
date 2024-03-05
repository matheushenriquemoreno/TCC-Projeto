using Application.Interfaces.Mapeamento;
using Domain.Entites.Base;

namespace Application.Interfaces;

public interface IOutPutEntity<T> : BaseMapeamento where T : EntityBase
{

}
