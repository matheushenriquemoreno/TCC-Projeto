using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Mapeamento
{
    public interface BaseMapeamento
    {
        /// <summary>
        /// Metódo para configurar as regras de negócio, referente ao mapeamento entre Entidade de origem e destino.
        /// </summary>
        public void Mapear();
    }
}
