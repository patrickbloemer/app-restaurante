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

        //Retorna Lista de Cargo
        public static List<Cargo> RetornaCargo()
        {
            return entities.Cargos.ToList();
        }

        // Buscar Cargo Por Nome
        public static Cargo BurcarCargoPorNome(Cargo cargo)
        {
            return entities.Cargos.FirstOrDefault(x => x.Nome.Equals(cargo.Nome));
        }

        // Busca Cargo por ID
        public static Cargo BuscaCargoPorId(int? id)
        {
            return entities.Cargos.Find(id);
        }

        // Verifica se existem Cargo Cadastrados
        public static bool VerificaExistenciaDeCargo() {
            List<Cargo> listAux = new List<Cargo>();
            listAux = CargoDAO.RetornaCargo();
            if (listAux.Count == 0) {
                return true;
            } else {
                return false;
            }
        }

        // Verifica Funcionários em Cargo
        public static bool VerificaSeExisteFuncionariosEmCargo(Cargo cargo, IQueryable<Funcionario> funcionarios)
        {
            
            foreach (var item in funcionarios)
            {
                if(item.Cargo.Id == cargo.Id)
                {
                    return true;
                }
            }

            return false;
        }

        // Lista Funcionários no Cargo
        public static List<Funcionario> RetornaFuncionariosCadastradosNoCargo(Cargo cargo)
        {
            List<Funcionario> funcionarios = new List<Funcionario>();
            List<Funcionario> TodosFuncionarios = FuncionarioDAO.RetornaFuncionarios();

            foreach (var item in TodosFuncionarios)
            {
                if(item.Cargo.Id == cargo.Id)
                {
                    funcionarios.Add(item);
                }
            }
            return funcionarios.ToList();

        }

        // Cadastrar Cargo
        public static bool CadastrarCargo(Cargo cargo)
        {
            try
            {
                if (CargoDAO.BurcarCargoPorNome(cargo) == null)
                {
                    entities.Cargos.Add(cargo);
                    entities.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {
                return false;
            }
        }

        // Primeiro Cargo 
        public static bool PrimeiroCargo()
        {
            try
            {
                Cargo cargo = new Cargo();

                cargo.Id = 1;
                cargo.Nome = "Admin";
                cargo.Descricao = "Admin";
                cargo.Inativo = false;

                entities.Cargos.Add(cargo);
                entities.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}