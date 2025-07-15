using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Ramon_Gonzalez_AP1_P2.Context;


namespace Ramon_Gonzalez_AP1_P2.Context
{
    public class ContextoFactory : IDesignTimeDbContextFactory<Contexto>
    {
        public Contexto CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<Contexto>();
            optionsBuilder.UseSqlServer("workstation id=Parcial2AP1.mssql.somee.com;packet size=4096;user id=Elpiord49_SQLLogin_1;pwd=qiyxavz7hf;data source=Parcial2AP1.mssql.somee.com;persist security info=False;initial catalog=Parcial2AP1;TrustServerCertificate=True");

            return new Contexto(optionsBuilder.Options);
        }
    }
}