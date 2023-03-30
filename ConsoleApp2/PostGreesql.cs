using System.Security.Principal;
using Dapper;
using Npgsql;


namespace ConsoleApp2
{
    internal class PostGreesql
    {
        public static NpgsqlConnection Connection()
        {
            return new NpgsqlConnection("User ID=postgres;Password=root;Host=localhost;Port=5432;Database=Banco_clientes");
        }

        public static bool TestConnection()
        {
            try
            {
                Connection().Query("select version()");
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public static int inserirObjeto(Contas contas)
        {
            var query = @"insert into dados (name, saldo, age, localidade, cpf ) values (@name, @age, @saldo, @localidade, @cpf) RETURNING  id";
            var result = Connection().Query<int>(query, new
            {
                name = contas.name,
                saldo = contas.saldo,
                age = contas.age,
                localidade = contas.localidade,
                cpf = contas.cpf,
            }).FirstOrDefault();
            return result;
        }

        public static bool UpdateObj(Contas contas)
        {
            var query = @"update dados set name = @name, age = @age, saldo = @saldo, localidade = @localidade, cpf = @cpf  where id = @id";
            var result = Connection().Execute(query, new
            {
                id = contas.id,
                name = contas.name,
                age = contas.age,
                saldo = contas.saldo,
                localidade = contas.localidade,
                cpf = contas.cpf,
            });
            return result > 0;
        }

        public static List<Contas> ListAccounts()
        {
            var query = @"select * from dados";
            var list = Connection().Query<Contas>(query).ToList();
            return list;
        }


    }

}





