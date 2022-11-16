using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Serve.API.Models
{
    public partial class ServeDbContext : DbContext
    {
        public ServeDbContext()
        {
        }

        public ServeDbContext(DbContextOptions<ServeDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Appointment> Appointments { get; set; } = null!;
        public virtual DbSet<AppointmentHandler> AppointmentHandlers { get; set; } = null!;
        public virtual DbSet<AppointmentProduct> AppointmentProducts { get; set; } = null!;
        public virtual DbSet<AppointmentService> AppointmentServices { get; set; } = null!;
        public virtual DbSet<AspNetRole> AspNetRoles { get; set; } = null!;
        public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; } = null!;
        public virtual DbSet<AspNetUser> AspNetUsers { get; set; } = null!;
        public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; } = null!;
        public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; } = null!;
        public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; } = null!;
        public virtual DbSet<CollaborativeTool> CollaborativeTools { get; set; } = null!;
        public virtual DbSet<Customer> Customers { get; set; } = null!;
        public virtual DbSet<EmployeePermission> EmployeePermissions { get; set; } = null!;
        public virtual DbSet<EmployeeRole> EmployeeRoles { get; set; } = null!;
        public virtual DbSet<EmployeeUnavailableDate> EmployeeUnavailableDates { get; set; } = null!;
        public virtual DbSet<Event> Events { get; set; } = null!;
        public virtual DbSet<EventType> EventTypes { get; set; } = null!;
        public virtual DbSet<Notification> Notifications { get; set; } = null!;
        public virtual DbSet<Organization> Organizations { get; set; } = null!;
        public virtual DbSet<OrganizationEmployee> OrganizationEmployees { get; set; } = null!;
        public virtual DbSet<OrganizationMedium> OrganizationMedia { get; set; } = null!;
        public virtual DbSet<OrganizationUnavailableDate> OrganizationUnavailableDates { get; set; } = null!;
        public virtual DbSet<Product> Products { get; set; } = null!;
        public virtual DbSet<Reminder> Reminders { get; set; } = null!;
        public virtual DbSet<ReminderStatus> ReminderStatuses { get; set; } = null!;
        public virtual DbSet<ReminderType> ReminderTypes { get; set; } = null!;
        public virtual DbSet<Schedule> Schedules { get; set; } = null!;
        public virtual DbSet<Service> Services { get; set; } = null!;
        public virtual DbSet<Task> Tasks { get; set; } = null!;
        public virtual DbSet<Timesheet> Timesheets { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLlocalDB;Database=ServeDb;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>(entity =>
            {
                entity.ToTable("Appointment");

                entity.Property(e => e.Address).HasMaxLength(500);

                entity.Property(e => e.AppointmentTitle)
                    .HasMaxLength(40)
                    .IsUnicode(false);

                entity.Property(e => e.CancelReason)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Country).HasMaxLength(50);

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasMaxLength(50);

                entity.Property(e => e.Longitude).HasMaxLength(50);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.Property(e => e.State).HasMaxLength(50);

                entity.Property(e => e.Url).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Appointments)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK__Appointme__Clien__300424B4");
            });

            modelBuilder.Entity<AppointmentHandler>(entity =>
            {
                entity.ToTable("AppointmentHandler");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentHandlers)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_AppointmentHandler_Appointment");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.AppointmentHandlers)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_AppointmentHandler_OrganizationEmployee");
            });

            modelBuilder.Entity<AppointmentProduct>(entity =>
            {
                entity.ToTable("AppointmentProduct");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Product)
                    .WithMany(p => p.AppointmentProducts)
                    .HasForeignKey(d => d.ProductId)
                    .HasConstraintName("FK_AppointmentProduct_Product");
            });

            modelBuilder.Entity<AppointmentService>(entity =>
            {
                entity.Property(e => e.Cost).HasColumnType("decimal(10, 2)");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.AppointmentServices)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK__ServicePr__AppId__36B12243");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.AppointmentServices)
                    .HasForeignKey(d => d.ServiceId)
                    .HasConstraintName("FK__ServicePr__Servi__35BCFE0A");
            });

            modelBuilder.Entity<AspNetRole>(entity =>
            {
                entity.HasIndex(e => e.NormalizedName, "RoleNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedName] IS NOT NULL)");

                entity.Property(e => e.Name).HasMaxLength(256);

                entity.Property(e => e.NormalizedName).HasMaxLength(256);
            });

            modelBuilder.Entity<AspNetRoleClaim>(entity =>
            {
                entity.HasIndex(e => e.RoleId, "IX_AspNetRoleClaims_RoleId");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.AspNetRoleClaims)
                    .HasForeignKey(d => d.RoleId);
            });

            modelBuilder.Entity<AspNetUser>(entity =>
            {
                entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

                entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                    .IsUnique()
                    .HasFilter("([NormalizedUserName] IS NOT NULL)");

                entity.Property(e => e.Email).HasMaxLength(256);

                entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

                entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

                entity.Property(e => e.UserName).HasMaxLength(256);

                entity.HasMany(d => d.Roles)
                    .WithMany(p => p.Users)
                    .UsingEntity<Dictionary<string, object>>(
                        "AspNetUserRole",
                        l => l.HasOne<AspNetRole>().WithMany().HasForeignKey("RoleId"),
                        r => r.HasOne<AspNetUser>().WithMany().HasForeignKey("UserId"),
                        j =>
                        {
                            j.HasKey("UserId", "RoleId");

                            j.ToTable("AspNetUserRoles");

                            j.HasIndex(new[] { "RoleId" }, "IX_AspNetUserRoles_RoleId");
                        });
            });

            modelBuilder.Entity<AspNetUserClaim>(entity =>
            {
                entity.HasIndex(e => e.UserId, "IX_AspNetUserClaims_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserClaims)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserLogin>(entity =>
            {
                entity.HasKey(e => new { e.LoginProvider, e.ProviderKey });

                entity.HasIndex(e => e.UserId, "IX_AspNetUserLogins_UserId");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserLogins)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<AspNetUserToken>(entity =>
            {
                entity.HasKey(e => new { e.UserId, e.LoginProvider, e.Name });

                entity.HasOne(d => d.User)
                    .WithMany(p => p.AspNetUserTokens)
                    .HasForeignKey(d => d.UserId);
            });

            modelBuilder.Entity<CollaborativeTool>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ToolName).HasMaxLength(50);

                entity.Property(e => e.ToolUrl).HasMaxLength(200);
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => e.CustomerEmail, "AK_EMAIL")
                    .IsUnique();

                entity.Property(e => e.AuthType).HasMaxLength(50);

                entity.Property(e => e.CustomerEmail)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CustomerName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(50)
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<EmployeePermission>(entity =>
            {
                entity.ToTable("EmployeePermission");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.EmployeePermissions)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmployeePermission_Organization");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.EmployeePermissions)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("FK_EmployeePermission_OrganizationEmployeeRole");
            });

            modelBuilder.Entity<EmployeeRole>(entity =>
            {
                entity.ToTable("EmployeeRole");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(100);

                entity.HasOne(d => d.OrganizationEmployee)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.OrganizationEmployeeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationEmployeeRole_OrganizationEmployee");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.EmployeeRoles)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationEmployeeRole_Organization");
            });

            modelBuilder.Entity<EmployeeUnavailableDate>(entity =>
            {
                entity.ToTable("EmployeeUnavailableDate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EndDateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.EmployeeUnavailableDates)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_EmployeeUnavailableDate_OrganizationEmployee");
            });

            modelBuilder.Entity<Event>(entity =>
            {
                entity.ToTable("Event");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EventUrl).HasMaxLength(100);

                entity.Property(e => e.ScheduledAt).HasColumnType("datetime");

                entity.Property(e => e.TriggeredAt).HasColumnType("datetime");

                entity.HasOne(d => d.EventType)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.EventTypeId)
                    .HasConstraintName("FK_Event_EventType");

                entity.HasOne(d => d.Reminder)
                    .WithMany(p => p.Events)
                    .HasForeignKey(d => d.ReminderId)
                    .HasConstraintName("FK_Event_Reminder");
            });

            modelBuilder.Entity<EventType>(entity =>
            {
                entity.ToTable("EventType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EventDescription).HasMaxLength(150);

                entity.Property(e => e.EventName).HasMaxLength(100);
            });

            modelBuilder.Entity<Notification>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.EventId).HasMaxLength(400);

                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_Notifications_Appointment");

                entity.HasOne(d => d.Employee)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.EmployeeId)
                    .HasConstraintName("FK_Notifications_OrganizationEmployee");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_Notifications_Organization");

                entity.HasOne(d => d.Reminder)
                    .WithMany(p => p.Notifications)
                    .HasForeignKey(d => d.ReminderId)
                    .HasConstraintName("FK_Notifications_Reminder");
            });

            modelBuilder.Entity<Organization>(entity =>
            {
                entity.ToTable("Organization");

                entity.Property(e => e.AuthenticationType).HasMaxLength(50);

                entity.Property(e => e.BusinessBio).HasMaxLength(100);

                entity.Property(e => e.BusinessDescription).HasMaxLength(500);

                entity.Property(e => e.BusinessEmail).HasMaxLength(50);

                entity.Property(e => e.BusinessName).HasMaxLength(50);

                entity.Property(e => e.FacebookUrl).HasMaxLength(150);

                entity.Property(e => e.Industry).HasMaxLength(100);

                entity.Property(e => e.InstagramUrl).HasMaxLength(150);

                entity.Property(e => e.PhoneNumber).HasMaxLength(20);

                entity.Property(e => e.ProfilePicture).HasMaxLength(100);

                entity.Property(e => e.WebsiteUrl).HasMaxLength(100);

                entity.Property(e => e.WhatsappUrl).HasMaxLength(150);

                entity.HasOne(d => d.CreatorNavigation)
                    .WithMany(p => p.Organizations)
                    .HasForeignKey(d => d.Creator)
                    .HasConstraintName("FK_Organization_UserProfile");
            });

            modelBuilder.Entity<OrganizationEmployee>(entity =>
            {
                entity.ToTable("OrganizationEmployee");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationEmployees)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_OrganizationEmployee_Organization");

                entity.HasOne(d => d.Permission)
                    .WithMany(p => p.OrganizationEmployees)
                    .HasForeignKey(d => d.PermissionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationEmployee_EmployeePermission");

                entity.HasOne(d => d.Profile)
                    .WithMany(p => p.OrganizationEmployees)
                    .HasForeignKey(d => d.ProfileId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationEmployee_UserProfile");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.OrganizationEmployees)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrganizationEmployee_EmployeeRole");
            });

            modelBuilder.Entity<OrganizationMedium>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.MediaCaption).HasMaxLength(100);

                entity.Property(e => e.MediaDescription).HasMaxLength(100);

                entity.Property(e => e.MediaName).HasMaxLength(100);

                entity.Property(e => e.MediaType).HasMaxLength(50);

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationMedia)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_OrganizationMedia_Organization");
            });

            modelBuilder.Entity<OrganizationUnavailableDate>(entity =>
            {
                entity.ToTable("OrganizationUnavailableDate");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.EnddateTime).HasColumnType("datetime");

                entity.Property(e => e.StartDateTime).HasColumnType("datetime");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.OrganizationUnavailableDates)
                    .HasForeignKey(d => d.OrganizationId)
                    .HasConstraintName("FK_OrganizationUnavailableDate_Organization");
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Amount).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.ProductName).HasMaxLength(50);

                entity.HasOne(d => d.Appointment)
                    .WithMany(p => p.Products)
                    .HasForeignKey(d => d.AppointmentId)
                    .HasConstraintName("FK_Product_Appointment");
            });

            modelBuilder.Entity<Reminder>(entity =>
            {
                entity.ToTable("Reminder");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Message).HasMaxLength(500);

                entity.Property(e => e.UpdatedAt).HasColumnType("datetime");

                entity.HasOne(d => d.Event)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.EventId)
                    .HasConstraintName("FK_Reminder_Event");

                entity.HasOne(d => d.ReminderStatus)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.ReminderStatusId)
                    .HasConstraintName("FK_Reminder_ReminderStatus");

                entity.HasOne(d => d.ReminderTypeNavigation)
                    .WithMany(p => p.Reminders)
                    .HasForeignKey(d => d.ReminderType)
                    .HasConstraintName("FK_Reminder_ReminderType");
            });

            modelBuilder.Entity<ReminderStatus>(entity =>
            {
                entity.ToTable("ReminderStatus");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(100);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<ReminderType>(entity =>
            {
                entity.ToTable("ReminderType");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Schedule>(entity =>
            {
                entity.HasKey(e => e.SchId)
                    .HasName("PK__Schedule__CAD9870BAB31DAFB");

                entity.ToTable("Schedule");

                entity.Property(e => e.FinishAt)
                    .HasColumnType("datetime")
                    .HasColumnName("FinishAT")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.StartFrom)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.ToTable("Service");

                entity.Property(e => e.BaseFee).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Currency).HasMaxLength(10);

                entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.ServiceName)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity.ToTable("Task");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Duration).HasColumnType("datetime");

                entity.Property(e => e.TaskDescription).HasMaxLength(150);

                entity.Property(e => e.TaskTittle).HasMaxLength(100);
            });

            modelBuilder.Entity<Timesheet>(entity =>
            {
                entity.ToTable("Timesheet");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ApprovedAt).HasColumnType("datetime");

                entity.Property(e => e.AttendanceByDay).HasMaxLength(50);

                entity.Property(e => e.ShiftEnd)
                    .HasMaxLength(10)
                    .IsFixedLength();

                entity.Property(e => e.ShiftStart).HasColumnType("datetime");

                entity.HasOne(d => d.Task)
                    .WithMany(p => p.Timesheets)
                    .HasForeignKey(d => d.TaskId)
                    .HasConstraintName("FK_Timesheet_Task");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AuthType).HasMaxLength(50);

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("CREATED_AT");

                entity.Property(e => e.Password)
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CustId");

                entity.HasOne(d => d.Organization)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.OrganizationId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_OrgId");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.ToTable("UserProfile");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.ProfilePicture).HasMaxLength(100);

                entity.Property(e => e.UserId).HasMaxLength(256);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
