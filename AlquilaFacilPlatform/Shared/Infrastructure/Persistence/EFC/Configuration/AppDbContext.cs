using AlquilaFacilPlatform.Booking.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration.Extensions;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Subscriptions.Domain.Model.Entities;
using AlquilaFacilPlatform.IAM.Domain.Model.Aggregates;
using AlquilaFacilPlatform.IAM.Domain.Model.Entities;
using AlquilaFacilPlatform.Locals.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Locals.Domain.Model.Entities;
using AlquilaFacilPlatform.Management.Domain.Model.Aggregates;
using AlquilaFacilPlatform.Management.Domain.Model.Entities;
using AlquilaFacilPlatform.Notifications.Domain.Models.Aggregates;
using AlquilaFacilPlatform.Profiles.Domain.Model.Aggregates;
using EntityFrameworkCore.CreatedUpdatedDate.Extensions;
using Microsoft.EntityFrameworkCore;

namespace AlquilaFacilPlatform.Shared.Infrastructure.Persistence.EFC.Configuration;

public class AppDbContext(DbContextOptions options) : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        base.OnConfiguring(builder);
        // Enable Audit Fields Interceptors
        builder.AddCreatedUpdatedInterceptor();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        
        // Place here your entities configuration
        
        builder.Entity<Plan>().HasKey(p => p.Id);
        builder.Entity<Plan>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Plan>().Property(p => p.Name).IsRequired();
        builder.Entity<Plan>().Property(p => p.Service).IsRequired();
        builder.Entity<Plan>().Property(p => p.Price).IsRequired();

        builder.Entity<Plan>().HasMany<Subscription>().WithOne().HasForeignKey(s => s.PlanId);
        
        builder.Entity<Subscription>().HasKey(s => s.Id);
        builder.Entity<Subscription>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Subscription>().Property(s => s.VoucherImageUrl).IsRequired();
        builder.Entity<Subscription>().HasOne<SubscriptionStatus>().WithMany()
            .HasForeignKey(s => s.SubscriptionStatusId);
        builder.Entity<Subscription>()
            .HasOne<Plan>().WithMany().HasForeignKey(s => s.PlanId);

        builder.Entity<SubscriptionStatus>().HasKey(s => s.Id);
        builder.Entity<SubscriptionStatus>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SubscriptionStatus>().Property(s => s.Status);

        builder.Entity<Invoice>().HasKey(i => i.Id);
        builder.Entity<Invoice>().Property(i => i.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Invoice>().Property(i => i.SubscriptionId).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Amount).IsRequired();
        builder.Entity<Invoice>().Property(i => i.Date).IsRequired();

        
        

        builder.Entity<Subscription>().HasOne<Invoice>().WithOne().HasForeignKey<Invoice>(i => i.SubscriptionId);

        //Local Context

        builder.Entity<LocalCategory>().HasKey(c => c.Id);
        builder.Entity<LocalCategory>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<LocalCategory>().Property(c => c.Name).IsRequired().HasMaxLength(30);
        builder.Entity<LocalCategory>().Property(c => c.PhotoUrl).IsRequired();


        builder.Entity<LocalCategory>().HasMany<Local>()
            .WithOne()
            .HasForeignKey(t => t.LocalCategoryId);
        
        
        
        
        builder.Entity<Local>().HasKey(p => p.Id);
        builder.Entity<Local>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Local>().Property(p => p.Features).IsRequired();
        builder.Entity<Local>().Property(p => p.Capacity).IsRequired();
        builder.Entity<Local>().OwnsOne(p => p.Price,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.PriceNight).HasColumnName("PriceNight");
            });
        builder.Entity<Local>().OwnsOne(p => p.LName,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.TypeLocal).HasColumnName("TypeLocal");
            });
        builder.Entity<Local>().OwnsOne(p => p.Address,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.District).HasColumnName("District");
                a.Property(s => s.Street).HasColumnName("Street");

            });
        builder.Entity<Local>().OwnsOne(p => p.Photo,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.PhotoUrlLink).HasColumnName("PhotoUrlLink");

            });
        builder.Entity<Local>().OwnsOne(p => p.Description,
            h =>
            {
                h.WithOwner().HasForeignKey("Id");
                h.Property(g => g.MessageDescription).HasColumnName("Description");

            });
        builder.Entity<Local>().OwnsOne(p => p.Place,
            a =>
            {
                a.WithOwner().HasForeignKey("Id");
                a.Property(s => s.Country).HasColumnName("Country");
                a.Property(s => s.City).HasColumnName("City");

            });

        builder.Entity<Local>().HasOne<User>().WithMany().HasForeignKey(l => l.UserId);

        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Comment>().OwnsOne(c => c.Text,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(g => g.Text).HasColumnName("Text");
            });
        
        builder.Entity<Comment>().OwnsOne(c => c.Rating,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(g => g.Rating).HasColumnName("Rating");
            });

        builder.Entity<Comment>().HasOne<User>().WithMany().HasForeignKey(u => u.UserId);
        builder.Entity<Comment>().HasOne<Local>().WithMany().HasForeignKey(l => l.LocalId);
        
        
        // Profile Context
        
        builder.Entity<Profile>().HasKey(p => p.Id);
        builder.Entity<Profile>().Property(p => p.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Profile>().OwnsOne(p => p.Name,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(p => p.Name).HasColumnName("FirstName");
                n.Property(p => p.FatherName).HasColumnName("FatherName");
                n.Property(p => p.MotherName).HasColumnName("MotherName");
            });
        builder.Entity<Profile>().OwnsOne(p => p.PhoneN,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.PhoneNumber).HasColumnName("PhoneNumber");
            });
        builder.Entity<Profile>().OwnsOne(p => p.DocumentN,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.NumberDocument).HasColumnName("NumberDocument");
            });
        builder.Entity<Profile>().OwnsOne(p => p.Birth,
            e =>
            {
                e.WithOwner().HasForeignKey("Id");
                e.Property(a => a.BirthDate).HasColumnName("BirthDate");
            });
        
        builder.Entity<Profile>().HasOne<User>().WithOne().HasForeignKey<Profile>(p => p.UserId);
        
        
        //IAM Context
        
        builder.Entity<User>().HasKey(u => u.Id);
        builder.Entity<User>().Property(u => u.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<User>().Property(u => u.Username).IsRequired();
        builder.Entity<User>().Property(u => u.PasswordHash).IsRequired();
        builder.Entity<User>().Property(u => u.Email).IsRequired();
        builder.Entity<UserRole>().HasMany<User>().WithOne().HasForeignKey(u => u.RoleId);

        builder.Entity<UserRole>().HasKey(ur => ur.Id);
        builder.Entity<UserRole>().Property(ur => ur.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<UserRole>().Property(ur => ur.Role).IsRequired();


        builder.Entity<Reservation>().HasKey(r => r.Id);
        builder.Entity<Reservation>().Property(r => r.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reservation>().Property(r => r.StartDate).IsRequired();
        builder.Entity<Reservation>().Property(r => r.EndDate).IsRequired();
        builder.Entity<Reservation>().Property(r => r.VoucherImageUrl).IsRequired();
        builder.Entity<User>().HasMany<Reservation>().WithOne().HasForeignKey(r => r.UserId);
        builder.Entity<Local>().HasMany<Reservation>().WithOne().HasForeignKey(r => r.LocalId);


        builder.Entity<Notification>().HasKey(n => n.Id);
        builder.Entity<Notification>().Property(n => n.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Notification>().Property(n => n.Title).IsRequired();
        builder.Entity<Notification>().Property(n => n.Description).IsRequired();
        
        builder.Entity<User>().HasMany<Notification>().WithOne().HasForeignKey(n => n.UserId);
        
        builder.Entity<Comment>().HasKey(c => c.Id);
        builder.Entity<Comment>().Property(c => c.Id).IsRequired().ValueGeneratedOnAdd();

        builder.Entity<Comment>().OwnsOne(c => c.Text,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(g => g.Text).HasColumnName("Text");
            });
        
        builder.Entity<Comment>().OwnsOne(c => c.Rating,
            n =>
            {
                n.WithOwner().HasForeignKey("Id");
                n.Property(g => g.Rating).HasColumnName("Rating");
            });

        builder.Entity<Comment>().HasOne<User>().WithMany().HasForeignKey(u => u.UserId);
        builder.Entity<Comment>().HasOne<Local>().WithMany().HasForeignKey(l => l.LocalId);

        builder.Entity<Report>().HasKey(report => report.Id);
        builder.Entity<Report>().Property(report => report.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Report>().Property(report => report.Description).IsRequired();
        builder.Entity<Report>().Property(report => report.Title).IsRequired();
        builder.Entity<Report>().Property(report => report.CreatedAt).IsRequired();
        builder.Entity<Report>().HasOne<User>().WithMany().HasForeignKey(r => r.UserId);
        builder.Entity<Report>().HasOne<Local>().WithMany().HasForeignKey(r => r.LocalId);

        builder.Entity<SensorState>().HasKey(s => s.Id);
        builder.Entity<SensorState>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SensorState>().Property(s => s.State).IsRequired().HasMaxLength(30);
        
        builder.Entity<SensorType>().HasKey(s => s.Id);
        builder.Entity<SensorType>().Property(s => s.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<SensorType>().Property(s => s.Type).IsRequired().HasMaxLength(30);
        
        
        builder.Entity<Sensor>().HasKey(sensor => sensor.Id);
        builder.Entity<Sensor>().Property(sensor => sensor.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Sensor>().OwnsOne(sensor => sensor.Code,
            c =>
            {
                c.WithOwner().HasForeignKey("Id");
                c.Property(s => s.Code).HasColumnName("Code");
            });
        builder.Entity<Sensor>().OwnsOne(sensor => sensor.Location,
            l =>
            {
                l.WithOwner().HasForeignKey("Id");
                l.Property(s => s.LocalLocation).HasColumnName("Location");
            });
        builder.Entity<Sensor>().HasOne<SensorType>().WithMany().HasForeignKey(s => s.TypeId);
        builder.Entity<Sensor>().HasOne<SensorState>().WithMany().HasForeignKey(s => s.StateId);
        builder.Entity<Sensor>().HasOne<Local>().WithMany().HasForeignKey(s => s.LocalId);

        builder.Entity<Reading>().HasKey(reading => reading.Id);
        builder.Entity<Reading>().Property(reading => reading.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Reading>().Property(reading => reading.Timestamp).IsRequired();
        builder.Entity<Reading>().OwnsOne(reading => reading.Value,
            l =>
            {
                l.WithOwner().HasForeignKey("Id");
                l.Property(v => v.Value).HasColumnName("Value");
            });
        builder.Entity<Reading>().OwnsOne(reading => reading.Unit,
            l =>
            {
                l.WithOwner().HasForeignKey("Id");
                l.Property(u => u.Unit).HasColumnName("Unit");
            });
        builder.Entity<Reading>().HasOne<Sensor>().WithMany().HasForeignKey(r => r.SensorId);
        
        builder.Entity<Restriction>().HasKey(restriction => restriction.Id);
        builder.Entity<Restriction>().Property(restriction => restriction.Id).IsRequired().ValueGeneratedOnAdd();
        builder.Entity<Restriction>().Property(restriction => restriction.NoiseLevel).IsRequired();
        builder.Entity<Restriction>().Property(restriction => restriction.SmokeDetection).IsRequired();
        builder.Entity<Restriction>().Property(restriction => restriction.RestrictedLocation).IsRequired();
        builder.Entity<Restriction>().HasOne<Local>().WithMany().HasForeignKey(r => r.LocalId);
        
        // Apply SnakeCase Naming Convention
        builder.UseSnakeCaseWithPluralizedTableNamingConvention();

    }
}
