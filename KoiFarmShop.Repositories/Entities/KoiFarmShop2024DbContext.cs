using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace KoiFarmShop.Repositories.Entities;

public partial class KoiFarmShop2024DbContext : DbContext
{
    public KoiFarmShop2024DbContext()
    {
    }

    public KoiFarmShop2024DbContext(DbContextOptions<KoiFarmShop2024DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<About> Abouts { get; set; }
	public virtual DbSet<Addresss> Addresss { get; set; }

	public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<Config> Configs { get; set; }

    public virtual DbSet<Consignment> Consignments { get; set; }

    public virtual DbSet<Contact> Contacts { get; set; }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<Footer> Footers { get; set; }

    public virtual DbSet<Invoice> Invoices { get; set; }

    public virtual DbSet<InvoiceDetail> InvoiceDetails { get; set; }

    public virtual DbSet<Koi> Kois { get; set; }

    public virtual DbSet<LoyaltyPoint> LoyaltyPoints { get; set; }

    public virtual DbSet<Manager> Managers { get; set; }

    public virtual DbSet<Menu> Menus { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<ProductCategory> ProductCategories { get; set; }

    public virtual DbSet<ProductComment> ProductComments { get; set; }

    public virtual DbSet<Promotion> Promotions { get; set; }

    public virtual DbSet<Rating> Ratings { get; set; }

    public virtual DbSet<Report> Reports { get; set; }

    public virtual DbSet<Slide> Slides { get; set; }

    public virtual DbSet<Supplier> Suppliers { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=KoiFarmShop2024Db;Integrated Security=True;MultipleActiveResultSets=True;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<About>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_About");

            entity.ToTable("About");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Description).HasMaxLength(50);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.MetaKeywords).HasMaxLength(250);

            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

		modelBuilder.Entity<Addresss>(entity =>
		{
			entity.HasKey(e => e.AddressId).HasName("PK_tb_Addresss");
			entity.Property(e => e.Company).HasMaxLength(50);
			entity.ToTable("Addresss");

			entity.Property(e => e.Address).HasMaxLength(50);

			entity.Property(e => e.CreatedDate)
				.HasDefaultValueSql("(getdate())")
				.HasColumnType("datetime");
			entity.Property(e => e.UpdateDate).HasColumnType("datetime");
			entity.Property(e => e.IsDefault).HasDefaultValue(false);

		});

		modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__TbBlog__54379E30436A86BD");

            entity.ToTable("Blog");

            entity.Property(e => e.Author).HasMaxLength(100);
            entity.Property(e => e.PublishedDate).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(100);
        });

        modelBuilder.Entity<Config>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Config");

            entity.ToTable("Config");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Type).HasMaxLength(50);
            entity.Property(e => e.Value).HasMaxLength(50);
        });

        modelBuilder.Entity<Consignment>(entity =>
        {
            entity.HasKey(e => e.ConsignmentId).HasName("PK__tb_Consi__EAEBA9A3D5FA63E5");

            entity.Property(e => e.ConsignmentId).HasColumnName("Consignment_id");
            entity.Property(e => e.ConsignmentDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("Consignment_date");
            entity.Property(e => e.CustomerId).HasColumnName("Customer_id");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Status)
                .HasMaxLength(10)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Contact>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Contact");

            entity.ToTable("Contact");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Feedback");

            entity.ToTable("Feedback");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Footer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Footer");

            entity.ToTable("Footer");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Invoice>(entity =>
        {
            entity.HasKey(e => e.InvoiceId).HasName("PK_tb_Invoice");

            entity.ToTable("Invoice");

            entity.Property(e => e.InvoiceId)
                .ValueGeneratedNever()
                .HasColumnName("InvoiceID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.DeleteDate).HasColumnType("datetime");
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<InvoiceDetail>(entity =>
        {
            entity.HasKey(e => new { e.InvoiceId, e.ProductId }).HasName("PK_tb_InvoiceDetail");

            entity.ToTable("InvoiceDetail");

            entity.Property(e => e.InvoiceId).HasColumnName("InvoiceID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<Koi>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Koi");

            entity.Property(e => e.Breed)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Character).HasColumnType("text");
            entity.Property(e => e.FeedlingAmount).HasColumnName("Feedling_amount");
            entity.Property(e => e.Gender)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.HealthStatus)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Health_status");
            entity.Property(e => e.KoiId).HasColumnName("Koi_id");
            entity.Property(e => e.Name)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Origin)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ScreenRate)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("Screen_rate");
            entity.Property(e => e.Size).HasColumnType("decimal(5, 2)");
        });

        modelBuilder.Entity<LoyaltyPoint>(entity =>
        {
            entity.HasKey(e => e.LoyaltyPointId).HasName("PK__TbLoyalt__A911B3F4FE5FBFA1");

            entity.ToTable("LoyaltyPoint");

            entity.Property(e => e.EarnedDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Manager>(entity =>
    {
        entity.HasKey(e => e.ManagerID).HasName("PK_Manager");

        entity.ToTable("Manager");

        entity.Property(e => e.ManagerID).HasColumnName("ManagerID");
        entity.Property(e => e.ManagerName).HasMaxLength(100);
        entity.Property(e => e.Email).HasMaxLength(100);
        entity.Property(e => e.Phone).HasMaxLength(20);
        entity.Property(e => e.CreatedAt).HasColumnType("datetime");
        entity.Property(e => e.UpdatedAt).HasColumnType("datetime");
    });

        modelBuilder.Entity<Menu>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Menu");

            entity.ToTable("Menu");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Description).HasMaxLength(500);
            entity.Property(e => e.Link).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.Target).HasMaxLength(50);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK_tb_Orders");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDate).HasColumnType("datetime");
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ProductId }).HasName("PK_tb_OrderDetail");

            entity.ToTable("OrderDetail");

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Price).HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductName).HasMaxLength(50);
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("Product");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Desiption).HasMaxLength(500);
            entity.Property(e => e.Detail).HasColumnType("ntext");
            entity.Property(e => e.Hot).HasColumnType("datetime");
            entity.Property(e => e.Image)
                .HasMaxLength(250)
                .HasColumnName("image");
            entity.Property(e => e.ListsImage).HasColumnType("xml");
            entity.Property(e => e.MateKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
			entity.Property(e => e.Loai).HasMaxLength(250);
			entity.Property(e => e.Price)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PromotionPrice)
                .HasDefaultValue(0m)
                .HasColumnType("decimal(18, 0)");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasColumnName("Seo Title");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.SupplierId).HasColumnName("SupplierID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductCategory>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("ProductCategory");

            entity.Property(e => e.CateId).HasColumnName("CateID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.MateKeywords).HasMaxLength(250);
            entity.Property(e => e.MetaDescriptioins).HasMaxLength(250);
            entity.Property(e => e.Name).HasMaxLength(250);
            entity.Property(e => e.ParentId).HasColumnName("ParentID");
            entity.Property(e => e.SeoTitle)
                .HasMaxLength(250)
                .HasColumnName("Seo Title");
            entity.Property(e => e.Status).HasDefaultValue(true);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<ProductComment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK_tb_ProductComment");

            entity.ToTable("ProductComment");

            entity.Property(e => e.CommentId).HasColumnName("CommentID");
            entity.Property(e => e.CreatedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Detail).HasMaxLength(500);
            entity.Property(e => e.Email).HasMaxLength(150);
            entity.Property(e => e.Name).HasMaxLength(150);
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Promotion>(entity =>
        {
            entity.HasKey(e => e.PromotionId).HasName("PK__TbPromot__52C42FCF5981C65E");

            entity.ToTable("Promotion");

            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.PromotionName).HasMaxLength(100);
            entity.Property(e => e.StartDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Rating>(entity =>
        {
            entity.HasKey(e => e.RatingId).HasName("PK__TbRating__FCCDF87C668B4F29");

            entity.ToTable("Rating");

            entity.Property(e => e.Feedback).HasMaxLength(255);
            entity.Property(e => e.RatingDate).HasColumnType("datetime");
        });

        modelBuilder.Entity<Report>(entity =>
        {
            entity.HasKey(e => e.ReportId).HasName("PK__TbReport__D5BD4805CE34849F");

            entity.ToTable("Report");

            entity.Property(e => e.GeneratedDate).HasColumnType("datetime");
            entity.Property(e => e.ReportName).HasMaxLength(100);
        });

        modelBuilder.Entity<Slide>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Slide");

            entity.ToTable("Slide");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Link).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
        });

        modelBuilder.Entity<Supplier>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Supplier");

            entity.ToTable("Supplier");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address)
                .HasMaxLength(50)
                .IsFixedLength();
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_Tag");

            entity.ToTable("Tag");

            entity.Property(e => e.Id)
                .HasMaxLength(50)
                .HasColumnName("ID");
            entity.Property(e => e.Name).HasMaxLength(500);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_tb_User");

            entity.ToTable("User");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Address).HasMaxLength(250);
            entity.Property(e => e.CreateDate).HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(50);
            entity.Property(e => e.Image).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(50);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.UpdateDate).HasColumnType("datetime");
            entity.Property(e => e.UserName).HasMaxLength(50);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
