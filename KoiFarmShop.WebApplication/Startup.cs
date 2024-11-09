using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KoiFarmShop.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using KoiFarmShop.Services.Interfaces;
using KoiFarmShop.Services.Services;
using KoiFarmShop.Repositories.Interfaces;
using KoiFarmShop.Repositories;
using KoiFarmShop.Repositories.Repositories;

namespace KoiFarmShop.WebApplication
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            services.AddDbContext<KoiFarmShop2024DbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddIdentity<User, IdentityRole>()
                .AddEntityFrameworkStores<KoiFarmShop2024DbContext>()
                .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = true;
                options.Password.RequireLowercase = false;
            });

            // Register application services
            services.AddScoped<IAboutRepository, AboutRepository>();
            services.AddScoped<IAboutService, AboutService>();

        

            services.AddScoped<IBlogRepository, BlogRepository>();
            services.AddScoped<IBlogService, BlogService>();

            services.AddScoped<IConfigRepository, ConfigRepository>();
            services.AddScoped<IConfigService, ConfigService>();

            services.AddScoped<IConsignmentRepository, ConsignmentRepository>();
            services.AddScoped<IConsignmentService, ConsignmentService>();

            services.AddScoped<IContactRepository, ContactRepository>();
            services.AddScoped<IContactService, ContactService>();

            services.AddScoped<IFeedbackRepository, FeedbackRepository>();
            services.AddScoped<IFeedbackService, FeedbackService>();

            services.AddScoped<IFooterRepository, FooterRepository>();
            services.AddScoped<IFooterService, FooterService>();

            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IInvoiceService, InvoiceService>();
            services.AddScoped<IInvoiceDetailRepository, InvoiceDetailRepository>();
            services.AddScoped<IInvoiceDetailService, InvoiceDetailService>();

            services.AddScoped<IKoiRepository, KoiRepository>();
            services.AddScoped<IKoiService, KoiService>();

            services.AddScoped<ILoyaltyPointRepository, LoyaltyPointRepository>();
            services.AddScoped<ILoyaltyPointService, LoyaltyPointService>();

            services.AddScoped<IManagerService, ManagerService>();
            services.AddScoped<IManagerRepository, ManagerRepository>();

            services.AddScoped<IMenuService, MenuService>();
            services.AddScoped<IMenuRepository, MenuRepository>();

            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();
            services.AddScoped<IOrderDetailService, OrderDetailService>();

            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();

            services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();
            services.AddScoped<IProductCategoryService, ProductCategoryService>();

            services.AddScoped<IProductCommentRepository, ProductCommentRepository>();
            services.AddScoped<IProductCommentService, ProductCommentService>();

            services.AddScoped<IPromotionRepository, PromotionRepository>();
            services.AddScoped<IPromotionService, PromotionService>();

            services.AddScoped<IRatingRepository, RatingRepository>();
            services.AddScoped<IRatingService, RatingService>();

            services.AddScoped<IReportRepository, ReportRepository>();
            services.AddScoped<IReportService, ReportService>();

            services.AddScoped<ISlideRepository, SlideRepository>();
            services.AddScoped<ISlideService, SlideService>();

            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();

            services.AddScoped<ITagRepository, TagRepository>();
            services.AddScoped<ITagService, TagService>();

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();

            services.AddControllersWithViews();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}