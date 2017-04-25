namespace RobotApollo.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class SpiderDB : DbContext
    {
        public SpiderDB()
            : base("name=SpiderDB")
        {
            Database.SetInitializer<SpiderDB>(new DropCreateDatabaseIfModelChanges<SpiderDB>());
        }

        public virtual DbSet<Movie> Movies { get; set; }
        public virtual DbSet<MoviePhoto> MoviePhotos { get; set; }
    }

}