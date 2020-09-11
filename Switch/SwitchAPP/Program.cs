
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using System;
using Microsoft.Extensions.Logging;
using Switch.Infra.CrossCutting.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using SwitchAPP.Reports;
using MySql.Data.MySqlClient;

namespace SwitchAPP
{
    class Program
    {
        static void Main(string[] args)
        {
            //Console.WriteLine("Hello World!");

            Usuario usuario1;
            Usuario usuario2;
            Usuario usuario3;
            Usuario usuario4;
            Usuario usuario5;
            Usuario usuario6;

           
            usuario1 = CriarUsuario("usuario 1");
            usuario2 = CriarUsuario("usuario 2");
            usuario3 = CriarUsuario("usuario 3");
            usuario4 = CriarUsuario("usuario 4");
            usuario5 = CriarUsuario("usuario 5");
            usuario6 = CriarUsuario("usuario 6");

            //exemplo usando lista
            List<Usuario> listaUsuarios = new List<Usuario>()
            {
                usuario1, usuario2, usuario3, usuario4, usuario5, usuario6
            };


            var optionsBuilder = new DbContextOptionsBuilder<SwitchContext>();
            optionsBuilder.UseLazyLoadingProxies();
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=;database=SwitchDB", 
                            m => m.MigrationsAssembly("Switch.Infra.Data").MaxBatchSize(100));

            try
            {
                //using descarta da memoria, desde que a classe em uso implemente a interface IDispose
                using (var dbcontext = new SwitchContext(optionsBuilder.Options))
                {
                    dbcontext.GetService<ILoggerFactory>().AddProvider(new Logger());

                    //executa em batch, somente acima de 3 registros
                    //o EF em uma unica transação adiciona na base de dados

                    //Forma simples
                    //dbcontext.Usuarios.Add(usuario1);
                    //dbcontext.Usuarios.Add(usuario2);
                    //dbcontext.Usuarios.Add(usuario3);
                    //dbcontext.Usuarios.Add(usuario4);
                    //dbcontext.Usuarios.Add(usuario5);
                    //dbcontext.Usuarios.Add(usuario6);

                    //de outra forma, usando uma lista de objetos
                    //dbcontext.Usuarios.AddRange(listaUsuarios);

                    //salva todas as alterações na base de dados
                    //dbcontext.SaveChanges();

                    //consultas a base de dados
                    //exemplos
                    ////carrega tudo o que tem na base
                    //var resultado = dbcontext.Usuarios.ToList();

                    ////filtro por nome
                    //var resultado2 = dbcontext.Usuarios.Where(u => u.Nome == "usuario1");

                    ////evitar usar assim, isso traz impacto na performance
                    //foreach(var us in resultado2)//abre conexao
                    //{

                    //    //aqui poderia ter alguns metodos simples

                    //}//fecha conexao


                    ////filtro por nome
                    //var resultado3 = dbcontext.Usuarios.Where(u => u.Nome == "usuario1").ToList();

                    ////para abrir e fechar conexão, chamar o método ToList()
                    ////para que armaze o resultado da consulta na memória
                    ///

                    //var usuarioNovo = CriarUsuario("usuarioNovo1");
                    //dbcontext.Usuarios.Add(usuarioNovo);
                    //dbcontext.SaveChanges();

                    //var usuarioRetorno = dbcontext.Usuarios.Where(u => u.Nome == "usuarioNovo1").ToList();


                    //var usuario123 = CriarUsuario("usuario123");
                    //var usuario124 = CriarUsuario("usuario123");

                    //dbcontext.Usuarios.Add(usuario123);
                    //dbcontext.Usuarios.Add(usuario124);
                    //dbcontext.SaveChanges();

                    // var totalUser = dbcontext.Usuarios.Count(u => u.Nome == "usuario123");

                    //REMOVENDO DA BASE DE DADOS

                    //exemplo 1, usa o cache
                    //var usuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuario123");
                    //dbcontext.Usuarios.Remove(usuario);
                    //dbcontext.SaveChanges();

                    //exemplo 2, remove diretamente na base
                    //var usuario = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "usuario123");
                    //dbcontext.Remove<Usuario>(usuario);
                    //dbcontext.SaveChanges();

                    //totalUser = dbcontext.Usuarios.Count(u => u.Nome == "usuario123");


                    ///ATUALIZANDO DADOS
                    //var userWillian = CriarUsuario("userWillian");
                    //Console.WriteLine("Id do userWillian = " + userWillian.Id);
                    //Console.ReadKey();

                    //dbcontext.Usuarios.Add(userWillian);
                    //Console.WriteLine("Id do userWillian = " + userWillian.Id);
                    //Console.ReadKey();

                    //dbcontext.SaveChanges();
                    //Console.WriteLine("Id do userWillian = " + userWillian.Id);
                    //Console.ReadKey();

                    // var userWillian = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "userWillian");
                    // userWillian.Senha = "1234567321";
                    //exemplo2 atualiza todos os campos da tabela, pode ser menos performatico
                    //dbcontext.Update<Usuario>(userWillian);

                    //exemplo 1, salva as alteracos na base de forma simples
                    //neste caso apenas monta o SQL para atualizar o campo SENHA
                    //se a senha for a mesma nao será feito um novo SQL
                    //dbcontext.SaveChanges();

                    //MUDANÇAS DE ESTADO NA CONEXÃO
                    //dbcontext.Database.GetDbConnection().StateChange += program_StateChange;
                    //var usuarioss = dbcontext.Usuarios.ToList();
                    //var inst = dbcontext.InstituicoesEnsino.ToList();


                    //CARREGAMENTO ANSIOSO - EAGER LOADING
                    //carrega todas as informações de um objeto ao ser referenciada e coloca na memoria, pode ser lento
                    //referencia as inst.de ensino e carrega ao mesmo tempo todos os usuarios para cada instituicao de ensino
                    //var instituicao2 = dbcontext.InstituicoesEnsino.Include(i => i.Usuario).FirstOrDefault();
                    //var usuario12 = instituicao2.Usuario;


                    //LAZY LOADING - CARREGAMENTO PREGUISO, POR DEMANDA
                    //var us1 = dbcontext.Usuarios.FirstOrDefault();
                    //var inst1 = us1.InstituicoesEnsino;


                    //ADICIONAR INSTANCIA RELACIONADA
                    //var helena = CriarUsuario("Helena");
                    //helena.InstituicoesEnsino.Add(new InstituicaoEnsino() { Nome = "Esucri" });
                    //helena.Identificacao = new Identificacao() { Numero = "123456789" };
                    //dbcontext.Usuarios.Add(helena);
                    //dbcontext.SaveChanges();
                    //var userHelena = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Helena");

                    //ATUALIZAR INSTANCIA RELACIONADA
                    //var helena = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Helena");
                    ////helena.InstituicoesEnsino.Add(new InstituicaoEnsino() { Nome = "UNESC" });
                    ////helena.InstituicoesEnsino.Add(new InstituicaoEnsino() { Nome = "SATC" });
                    ////dbcontext.SaveChanges();
                    //var ie = helena.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "UNESC");
                    //ie.Nome = "CEDUP";
                    //dbcontext.SaveChanges();

                    //REMOVER ITEM DENTRO DE INSTANCIA RELACIONADA
                    //var helena = dbcontext.Usuarios.FirstOrDefault(u => u.Nome == "Helena");
                    //var ie = helena.InstituicoesEnsino.FirstOrDefault(i => i.Nome == "CEDUP");
                    //helena.InstituicoesEnsino.Remove(ie);
                    //dbcontext.SaveChanges();


                    //EXECUTANDO SQL NO EFCore COM PROJEÇÃO
                    //////var sql = "SELECT nome, sobrenome FROM usuarios";
                    ////////obtem conexao com base de dados
                    //////var connection = dbcontext.Database.GetDbConnection();
                    //////var listaDeUsuarios = new List<UsuarioDTO>();

                    //////using (var command = connection.CreateCommand())
                    //////{
                    //////    connection.Open();
                    //////    //passa o SQL
                    //////    command.CommandText = sql;
                    //////    using (var dataReader = command.ExecuteReader())
                    //////    {
                    //////        //verifica se tem linhas no dataReader
                    //////        if(dataReader.HasRows)
                    //////        {
                    //////            while(dataReader.Read())
                    //////            {
                    //////                //otendo dados de cada linha
                    //////                var userDTO = new UsuarioDTO();
                    //////                userDTO.Nome = dataReader["nome"].ToString();
                    //////                userDTO.Sobrenome = dataReader["sobrenome"].ToString();
                    //////                listaDeUsuarios.Add(userDTO);
                    //////            }
                    //////        }
                    //////    }
                    //////}
                    ///


                    //SQL INJECTION

                    //exemplo de SQL Injection
                    //var filtroPesquisa = "' or 1='1";

                    //var sql = "SELECT nome, sobrenome FROM usuarios WHERE nome = @nomeUsuario";

                    ////obtem conexao com base de dados
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaDeUsuarios = new List<UsuarioDTO>();

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();
                    //    //passa o SQL                        
                    //    command.CommandText = sql;

                    //    //parametros
                    //    MySqlParameter prm = new MySqlParameter("@nomeUsuario", MySqlDbType.VarChar);
                    //    prm.Value = filtroPesquisa;
                    //    command.Parameters.Add(prm);

                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        //verifica se tem linhas no dataReader
                    //        if (dataReader.HasRows)
                    //        {
                    //            while (dataReader.Read())
                    //            {
                    //                //otendo dados de cada linha
                    //                var userDTO = new UsuarioDTO();
                    //                userDTO.Nome = dataReader["nome"].ToString();
                    //                userDTO.Sobrenome = dataReader["sobrenome"].ToString();
                    //                listaDeUsuarios.Add(userDTO);
                    //            }
                    //        }
                    //    }
                    //}

                    ////COMANDOS PARA CHAMAR STORE PROCEDURES

                    ////obtem conexao com base de dados
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaDeUsuarios = new List<UsuarioDTO>();

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();
                    //    //chamar store procedure, ela deve existir na base de dados
                    //    command.CommandText = "call spObterTodosUsuarios()";
                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        //verifica se tem linhas no dataReader
                    //        if (dataReader.HasRows)
                    //        {
                    //            while (dataReader.Read())
                    //            {
                    //                //otendo dados de cada linha
                    //                var userDTO = new UsuarioDTO();
                    //                userDTO.Nome = dataReader["nome"].ToString();
                    //                userDTO.Sobrenome = dataReader["sobrenome"].ToString();
                    //                listaDeUsuarios.Add(userDTO);
                    //            }
                    //        }
                    //    }
                    //}


                    //COMANDOS PARA CHAMAR STORE PROCEDURES COM PARAMETRO

                    ////obtem conexao com base de dados
                    //var connection = dbcontext.Database.GetDbConnection();
                    //var listaDeUsuarios = new List<UsuarioDTO>();

                    //using (var command = connection.CreateCommand())
                    //{
                    //    connection.Open();

                    //    //chamar store procedure, ela deve existir na base de dados
                    //    command.CommandText = "call spObterUsuario(@usuarioID)";
                    //    MySqlParameter prm = new MySqlParameter("@usuarioID", MySqlDbType.Int32);
                    //    prm.Value = 38;
                    //    command.Parameters.Add(prm);

                    //    using (var dataReader = command.ExecuteReader())
                    //    {
                    //        //verifica se tem linhas no dataReader
                    //        if (dataReader.HasRows)
                    //        {
                    //            while (dataReader.Read())
                    //            {
                    //                //otendo dados de cada linha
                    //                var userDTO = new UsuarioDTO();
                    //                userDTO.Nome = dataReader["nome"].ToString();
                    //                userDTO.Sobrenome = dataReader["sobrenome"].ToString();
                    //                listaDeUsuarios.Add(userDTO);
                    //            }
                    //        }
                    //    }
                    //}


                    //PROJEÇÃO DE CONSULTA SQL COM STORE PROCEDURES

                    //obtem conexao com base de dados
                    var connection = dbcontext.Database.GetDbConnection();
                    var listaUsuariosInstituicaoEnsino = new List<UsuarioInstituicaoEnsinoDTO>();

                    using (var command = connection.CreateCommand())
                    {
                        connection.Open();

                        //chamar store procedure, ela deve existir na base de dados
                        command.CommandText = "call spObterUsuariosPorInstituicoes";
                        MySqlParameter prm = new MySqlParameter("@usuarioID", MySqlDbType.Int32);
                        prm.Value = 38;
                        command.Parameters.Add(prm);

                        using (var dataReader = command.ExecuteReader())
                        {
                            //verifica se tem linhas no dataReader
                            if (dataReader.HasRows)
                            {
                                while (dataReader.Read())
                                {
                                    //otendo dados de cada linha
                                    //sempre colocar ["NomeUsuario"] o mesmo que sera retornado no SQL
                                    var usuarioInstituicaoEnsinoDTO = new UsuarioInstituicaoEnsinoDTO();
                                    
                                    usuarioInstituicaoEnsinoDTO.NomeUsuario = dataReader["NomeUsuario"].ToString();
                                    usuarioInstituicaoEnsinoDTO.SobrenomeUsuario = dataReader["SobrenomeUsuario"].ToString();
                                    usuarioInstituicaoEnsinoDTO.NomeInstituicao = dataReader["NomeInstituicao"].ToString();
                                    
                                    listaUsuariosInstituicaoEnsino.Add(usuarioInstituicaoEnsinoDTO);
                                }
                            }
                        }
                    }

                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            //Console.WriteLine("Ok!");
            //Console.ReadKey();
        }

        private static void program_StateChange(object sender, System.Data.StateChangeEventArgs e)
        {
            Console.WriteLine("Estado atual da conexão " + e.CurrentState);
        }

        public static Usuario CriarUsuario(string nome)
        {
            return new Usuario()
            {
                Nome = nome,
                Sobrenome = "Sobrenome",
                Senha = "123456",
                Email = "teste@teste.com",
                DataNascimento = DateTime.Now,
                Sexo = Switch.Domain.Enums.SexoEnum.Masculino,
                UrlFoto = @"c:\temp"
            };
        }

    }
}
