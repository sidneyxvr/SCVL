using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Enum
{
    public class FormaPagamento
    {
        public static Dictionary<int, string> GetFormaPagamento()
        {
            Dictionary<int, string> d = new Dictionary<int, string>
            {
                {1, "Cartão de Crédito" },
                {2, "Cartão de Débito" }
            };
            return d;
        }
    }
}
