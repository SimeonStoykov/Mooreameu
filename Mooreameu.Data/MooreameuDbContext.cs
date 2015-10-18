﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using Mooreameu.Model;

namespace Mooreameu.Data
{
    public class MooreameuDbContext : IdentityDbContext<User>
    {
        public MooreameuDbContext()
            : base("MooreameuDb", throwIfV1Schema: false)
        {
        }

        public virtual DbSet<Reward> Rewards { get; set; }

        public virtual DbSet<Notification> Notifications { get; set; }

        public virtual DbSet<Picture> Pictures { get; set; }

        public virtual DbSet<ProfilePicture> ProfilePictures { get; set; }

        public virtual DbSet<Contest> Contests { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityUserLogin>().HasKey<string>(l => l.UserId);
            modelBuilder.Entity<IdentityRole>().HasKey<string>(r => r.Id);
            modelBuilder.Entity<IdentityUserRole>().HasKey(r => new { r.RoleId, r.UserId });
            
            /*modelBuilder.Entity<ProfilePicture>()
                .HasKey(pp => pp.ProfilePictureId);

            modelBuilder.Entity<User>()
                .HasOptional(u => u.ProfilePicture)
                .WithRequired(pp => pp.Owner);

            modelBuilder.Entity<Reward>()
                .HasKey(r => r.RewardId);

            modelBuilder.Entity<Contest>()
                .HasOptional(c => c.Reward)
                .WithRequired(r => r.Contest);

            modelBuilder.Entity<Contest>()
                .HasRequired(c => c.Owner)
                .WithMany(o => o.CreatedContests)
                .HasForeignKey(c => c.OwnerId);

            modelBuilder.Entity<Picture>()
                .HasRequired(p => p.Contest)
                .WithMany(c => c.Pictures)
                .HasForeignKey(p => p.ContestId);

            modelBuilder.Entity<Picture>()
                .HasRequired(p => p.Owner)
                .WithMany(u => u.Pictures)
                .HasForeignKey(p => p.OwnerId);

            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Comittee)
                .WithOptional(u => u.ComitteeContest);

            /*modelBuilder.Entity<User>()
                .HasOptional(u => u.ComitteeContest)
                .WithMany(c => c.Comittee)
                .HasForeignKey(u => u.ComitteeContestId);#1#

            modelBuilder.Entity<Notification>()
                .HasRequired(n => n.User)
                .WithMany(u => u.Notifications)
                .HasForeignKey(n => n.UserId);

            modelBuilder.Entity<Contest>()
                .HasMany(c => c.Participants)
                .WithMany(u => u.ParticipatingInContests)
                .Map(cu =>
                {
                    cu.MapLeftKey("ContestRefId");
                    cu.MapRightKey("UserRefId");
                    cu.ToTable("ContestsParticipants");
                });

            modelBuilder.Entity<Reward>()
                .HasMany(r => r.Winners)
                .WithMany(u => u.Rewards)
                .Map(cr =>
                {
                    cr.MapLeftKey("RewardRefId");
                    cr.MapRightKey("UserRefId");
                    cr.ToTable("RewardsParticipants");
                });*/


            modelBuilder.Entity<User>().HasMany(u => u.ProfilePictures);
            modelBuilder.Entity<ProfilePicture>().HasRequired(p => p.Owner);
            modelBuilder.Entity<Reward>().HasKey(r => r.RewardId);
            modelBuilder.Entity<Contest>().HasRequired(c => c.Reward).WithRequiredPrincipal(r => r.Contest);

        }

        public static MooreameuDbContext Create()
        {
            return new MooreameuDbContext();
        }
    }
}
