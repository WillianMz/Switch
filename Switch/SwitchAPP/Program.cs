
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Switch.Domain.Entities;
using Switch.Infra.Data.Context;
using System;
using Microsoft.Extensions.Logging;
using Switch.Infra.CrossCutting.Logging;
using System.Collections.Generic;

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

            Usuario CriarUsuario(string nome)
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
            optionsBuilder.UseMySql("Server=localhost;userid=root;password=;database=SwitchDB", m => m.MigrationsAssembly("Switch.Infra.Data").MaxBatchSize(100));

            try
            {
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
                    dbcontext.Usuarios.AddRange(listaUsuarios);


                    dbcontext.SaveChanges();
                }
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }

            Console.WriteLine("Ok!");
            Console.ReadKey();
        }
    }
}
