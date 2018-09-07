using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Enum
{
    public class StatusVenda
    {
        public static Dictionary<int, string> GetStatusVenda()
        {
            Dictionary<int, string> d = new Dictionary<int, string>
            {
                {0, "Pedido Aceito" },
                {1, "Aguardando Despacho" },
                {2, "Despachado" },
                {3, "Em Trânsito" },
                {4, "Entregue" },
                {5, "Cancelado" }
            };
            return d;
        }
    }
}
