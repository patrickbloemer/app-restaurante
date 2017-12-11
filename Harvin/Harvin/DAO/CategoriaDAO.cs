using Harvin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Harvin.DAO {
    public class CategoriaDAO {
        private static Entities db = new Entities();
        
        public static List<Categoria> ListaCategorias() {
            try {
                return db.Categorias.ToList();
            }
            catch (Exception e) {
                return null;
            }
        }
    }
}