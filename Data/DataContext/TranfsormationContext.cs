using Data.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Text;

namespace Data.DataContext
{
    public class TransformationContext: DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<TrainingUser> TrainingUsers { get; set; }
        public DbSet<Workout> Workouts { get; set; }
        

        public TransformationContext() :base(@"Server=localhost\SQLEXPRESS;Database=Transformation;Trusted_Connection=True;")
        {
            Users = this.Set<User>();
            TrainingUsers = this.Set<TrainingUser>();
            Workouts = this.Set<Workout>();

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<TrainingUser>()
                    .HasKey(t => t.UserId);

            modelBuilder.Entity<TrainingUser>()
                .HasRequired(sd => sd.User)
                .WithOptional(s => s.TrainingUser);


            modelBuilder.Entity<Workout>()
                 .HasKey(t => t.UserId);

            modelBuilder.Entity<Workout>()
                .HasRequired(sd => sd.User)
                .WithOptional(s => s.Workout);


        }


    }
}
