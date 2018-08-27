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
                {0, "Notificar" },
                {1, "Aguardando Pagamento" },
                {2, "Pagamento Aceito" },
                {3, "Aguardando Despacho" },
                {4, "Despachado" },
                {5, "Em Trânsito" },
                {6, "Entregue" },
                {7, "Cancelado" }
            };
            return d;
        }
    }
}
