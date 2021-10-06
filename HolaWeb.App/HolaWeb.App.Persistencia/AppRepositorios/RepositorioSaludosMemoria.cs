using System;
using System.Collections.Generic;
using System.Linq;
using HolaWeb.App.Dominio;

namespace HolaWeb.App.Persistencia.AppRepositorios
{
    public class RepositorioSaludosMemoria : IRepositorioSaludos
    {
        List<Saludo> saludos;

        public RepositorioSaludosMemoria()
        {
            saludos = new List<Saludo>()
            {
                new Saludo{id=1,EnEspañol="Buenos Dias",EnIngles="Good Morning",EnItaliano="Bungiorno",EnRuso="Привет"},
                new Saludo{id=2,EnEspañol="Buenas Tardes",EnIngles="Good Afternoon",EnItaliano="Buon Pomeriggio",EnRuso="Добрый день"},
                new Saludo{id=3,EnEspañol="Buenas Noches",EnIngles="Good Evening",EnItaliano="Buona Notte",EnRuso="Добрый вечер"},
                new Saludo{id=4,EnEspañol="Hasta Mañana",EnIngles="until tomorrow",EnItaliano="fino a domani",EnRuso="до завтра"}
            };
        }
        public IEnumerable<Saludo> GetAll()
        {
            return saludos;
        }

        public Saludo GetSaludoPorId(int saludoId)
        {
            return saludos.SingleOrDefault(s => s.id == saludoId);
        }

        public IEnumerable<Saludo> GetSaludosPorFiltro(string filtro)
        {
            var saludos = GetAll();
            
            if (saludos!=null)
            {
                if(!String.IsNullOrEmpty(filtro))
                {
                    saludos = saludos.Where(s=>s.EnEspañol.Contains(filtro) | s.EnIngles.Contains(filtro) | s.EnItaliano.Contains(filtro));
                }
            }
            return saludos;
        }
    }
}