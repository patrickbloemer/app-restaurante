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

        //Retorna Lista de Cargos
        public static List<Cargo> RetornaCargos()
        {
            return entities.Cargos.ToList();
        }

        // Buscar Cargo Por Nome
        public static Cargo BurcarCargoPorNome(Cargo cargo)
        {
            return entities.Cargos.FirstOrDefault(x => x.nome.Equals(cargo.nome));
        }

        // Busca Cargo por ID
        public static Cargo BuscaCargoPorId(int id)
        {
            return entities.Cargos.Find(id);
        }

        // Verifica se existem Cargos Cadastrados
        public static bool VerificaExistenciaDeCargos() {
            List<Cargo> listAux = new List<Cargo>();
            listAux = CargoDAO.RetornaCargos();
            if (listAux.Count == 0) {
                return true;
            } else {
                return false;
            }
        }

        // Verifica Funcionários em Cargos
        public static bool VerificaSeExisteFuncionariosEmCargo(Cargo cargo)
        {
            List<Funcionario> funcionarios = FuncionarioDAO.RetornaFuncionarios();
            foreach (var item in funcionarios)
            {
                if(item.cargoId == cargo.cargoId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}