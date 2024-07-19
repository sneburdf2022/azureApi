using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio.Entidade
{
    public class ItemIncluir
    {
        public string op { get; set; } = "add";
        public string path { get; set; } = "/fields/System.Title";
        public string? from { get; set; } = null;
        public string value { get; set; } = "Exemplo task";
    }
}
/*
 [
  {
    "op": "add",
    "path": "/fields/System.Title",
    "from": null,
    "value": "Exemplo task"
  }
]
 */