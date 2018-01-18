using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DB.Lab2
{
    public class EntityContext : DbContext
    {
        // Connection string to DB
        // Create a database called "DB Labb2" if you wanna skip changing the connection string
        private const string DbConnection = @"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=DB Labb2;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";

        public EntityContext() : base(DbConnection) { }
        public DbSet<Player> Players { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Score> Scores { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var playerConfig = modelBuilder.Entity<Player>();
            var mapConfig = modelBuilder.Entity<Map>();
            var scoreConfig = modelBuilder.Entity<Score>();

            #region API

            #region Player

            playerConfig.ToTable("Players");
            playerConfig.HasKey(p => p.Id);
            playerConfig.Property(p => p.Name)
                .HasColumnName("Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(50);
            playerConfig.Property(p => p.Moves)
                .HasColumnName("Moves")
                .HasColumnType("int");

            #endregion
            #region Map

            mapConfig.ToTable("Maps");
            mapConfig.HasKey(m => m.Id);
            mapConfig.Property(m => m.MapName)
                .HasColumnName("Map_Name")
                .HasColumnType("nvarchar")
                .HasMaxLength(250);
            mapConfig.Property(m => m.MaxMoves)
                .HasColumnName("Max_Moves")
                .HasColumnType("int");

            #endregion
            #region Score

            scoreConfig.ToTable("Scores");
            scoreConfig.HasKey(s => s.Id);

            scoreConfig.HasRequired(s => s.Map)
                .WithMany(m => m.Scores);
            scoreConfig.HasRequired(s => s.Player)
                .WithMany(p => p.Scores);
           
            scoreConfig.Property(s => s.PlayerScore)
                .HasColumnName("Player_Score")
                .HasColumnType("int");

            #endregion

            #endregion
        }
    }
}
