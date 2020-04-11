using System;
using Microsoft.EntityFrameworkCore;
using Npgsql;

namespace SlackClone.Models
{
    public class SlackCloneDbContext : DbContext
    {

        public SlackCloneDbContext(DbContextOptions<SlackCloneDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<TeamMember> TeamMembers { get; set; }
        public DbSet<Channel> Channels { get; set; }
        public DbSet<ChannelMessage> ChannelMessages { get; set; }
        public DbSet<DirectMessage> DirectMessages { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TeamMember>()
                .HasKey(o => new { o.TeamName, o.MemberEmail });

            modelBuilder.Entity<TeamMember>()
                .HasOne(se => se.Team)
                .WithMany(s => s.Members)
                .HasForeignKey(se => se.MemberEmail);

            modelBuilder.Entity<TeamMember>()
                .HasOne(se => se.Member)
                .WithMany(e => e.Teams)
                .HasForeignKey(se => se.TeamName);


        }
    }
}