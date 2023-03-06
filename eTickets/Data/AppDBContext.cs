using eTickets.Models;
using Microsoft.EntityFrameworkCore;
using System;

namespace eTickets.Data {
    public class AppDBContext:DbContext {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            modelBuilder.Entity<Actor_Movie>().HasKey(am => new {
                am.ActorId,
                am.MovieId
            });

            modelBuilder.Entity<Actor_Movie>().HasOne(m => m.Movie).WithMany(am => am.Actors_Movies).HasForeignKey(m => m.MovieId);

            base.OnModelCreating(modelBuilder);
        }
    }
}
