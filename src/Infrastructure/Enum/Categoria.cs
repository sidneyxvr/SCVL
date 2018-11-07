using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Enum
{
    public class Categoria
    {
        public static Dictionary<string, string> GetCategoria()
        {
            Dictionary<string, string> d = new Dictionary<string, string>
            {
                {"Categoria 1", "Categoria 1" },
                {"Categoria 2", "Categoria 2" },
                {"Categoria 3", "Categoria 3" },
                {"Categoria 4", "Categoria 4" },
                {"Categoria 5", "Categoria 5" }
            };
            return d;
        }
    }
}
