using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO
{
    public class CargoDAO
    {
        private static Entities entities = Singleton.Instance.Entities;

        // Buscar Cargo Por Nome
        public static Cargo BurcarCargoPorNome(Cargo cargo)
        {
            return entities.Cargos.FirstOrDefault(x => x.nome.Equals(cargo.nome));
        }
    }
}