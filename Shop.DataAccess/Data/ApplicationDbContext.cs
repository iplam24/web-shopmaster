using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using Shop.Models.Models;
using WebShop.Models;

namespace WebShop.Data
{
    public class ApplicationDbContext:IdentityDbContext<IdentityUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<ShoppingCart> ShoppingCarts { get; set; }
        
        public DbSet<OrderDetail> OrderDetails { get; set; }
        public DbSet<OrderHeader> orderHeaders { get; set; }

        public DbSet<ProductImage> ProductImages { get; set; }
        public DbSet<News> newss { get; set; }
        public DbSet<News> advise { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>().HasData(


                new Category { Id = 1, Name = "Bánh Sự Kiện", DisplayOrder = 1 },

                new Category { Id = 2, Name = "Bánh kem tươi hoa quả", DisplayOrder = 2 },

                new Category { Id = 3, Name = "Bánh sinh nhật bé trai,bé gái", DisplayOrder = 3 },

                new Category { Id = 4, Name = "Bánh sinh nhật kem bơ", DisplayOrder = 4 },

                new Category { Id = 5, Name = "Bánh sinh nhật nam, nữ", DisplayOrder = 5 },

                new Category { Id = 6, Name = "Bánh Tiramisu", DisplayOrder = 6 },

                new Category { Id = 7, Name = "Bánh kem số & chữ", DisplayOrder = 7 },

                new Category { Id = 8, Name = "Bánh bông lan trứng muối", DisplayOrder = 8 },

                new Category { Id = 9, Name = "Bánh tạo hình fondant", DisplayOrder = 9 },

                new Category { Id = 10, Name = "Bánh Mousse  ", DisplayOrder = 10 },
                new Category { Id = 11, Name = "Bánh sinh nhật  ", DisplayOrder = 11 }

                );


            modelBuilder.Entity<Product>().HasData(

                new Product

                {

                    Id = 1,

                    Title = "Bánh sự kiện - Trang trí hoa quả",

                    Description = "Bánh sự kiện là 1 loại bánh để trang trí  ",

                    Size = "S",

                    Price = 90000,

                    CategoryId = 1

                },

                new Product

                {

                    Id = 2,

                    Title = "Bánh kem tươi hoa quả - Trang trí dâu tây",

                    Description = "Bánh kem tươi hoa quả là sự kết hợp giữa kem whipping và hoa quả tươi tạo nên 1 sự kết hợp rất hài hòa. Bánh kem tươi qua quả phù hợp cho người lớn  ",

                    Size = "S",

                    Price = 35600,

                    CategoryId = 2

                },

                new Product

                {

                    Id = 3,

                    Title = "Bánh kem tươi hoa quả - Full hoa quả",

                    Description = "Bánh kem tươi hoa quả là sự kết hợp giữa kem whipping và hoa quả tươi tạo nên 1 sự kết hợp rất hài hòa. Bánh kem tươi qua quả phù hợp cho người lớn  ",

                    Size = "S",

                    Price = 39500,

                    CategoryId = 2

                },

                 new Product

                 {

                     Id = 4,

                     Title = "Bánh kem tươi hoa quả - Full hoa quả",

                     Description = "Bánh kem tươi hoa quả là sự kết hợp giữa kem whipping và hoa quả tươi tạo nên 1 sự kết hợp rất hài hòa. Bánh kem tươi qua quả phù hợp cho người lớn  ",

                     Size = "M",

                     Price = 42500,

                     CategoryId = 2

                 },

                  new Product

                  {

                      Id = 5,

                      Title = "Bánh sinh nhật bé trai",

                      Description = "Bánh sinh nhật bé trai được tạo hình phù hợp cho các bé trai. ",

                      Size = "S",

                      Price = 36500,

                      CategoryId = 3

                  },

                  new Product

                  {

                      Id = 6,

                      Title = "Bánh sinh nhật bé trai",

                      Description = "Bánh sinh nhật bé trai được tạo hình phù hợp cho các bé trai",

                      Size = "M",

                      Price = 39500,

                      CategoryId = 3

                  },

                  new Product

                  {

                      Id = 7,

                      Title = "Bánh sinh nhật bé gái",

                      Description = "Bánh sinh nhật bé gái được tạo hình phù hợp cho các bé gái.",

                      Size = "S",

                      Price = 36500,

                      CategoryId = 3

                  },

                  new Product

                  {

                      Id = 8,

                      Title = "Bánh sinh nhật bé gái - Trang trí gấu dâu",

                      Description = "Bánh sinh nhật bé gái được tạo hình phù hợp cho các bé gái.",

                      Size = "M",

                      Price = 39500,

                      CategoryId = 3

                  },

                  new Product

                  {

                      Id = 9,

                      Title = "Bánh sinh nhật kem bơ",

                      Description = "Bánh sinh nhật kem bơ. Đây là 1 dòng kem bơ ăn ngậy hơi béo, với dòng kem bơ chúng ta có thể để được ở ngoài lâu. Dòng kem này khá kén người ăn ",

                      Size = "S",

                      Price = 395000,

                      CategoryId = 4

                  },

                  new Product

                  {

                      Id = 10,

                      Title = "Bánh sinh nhật kem bơ - Tạo hình con mèo",

                      Description = "Bánh sinh nhật kem bơ. Đây là 1 dòng kem bơ ăn ngậy hơi béo, với dòng kem bơ chúng ta có thể để được ở ngoài lâu. Dòng kem này khá kén người ăn ",

                      Size = "M",

                      Price = 425000,

                      CategoryId = 4

                  },

                  new Product

                  {

                      Id = 11,

                      Title = "Bánh sinh nhật nam - Bánh vẽ hình chibi",

                      Description = "Bánh sinh nhật bé gái được tạo hình phù hợp cho các bạn nam ",

                      Size = "S",

                      Price = 365000,

                      CategoryId = 5

                  },

                  new Product

                  {

                      Id = 12,

                      Title = "Bánh sinh nhật nam - Bánh trang trí hình nộm",

                      Description = "Bánh sinh nhật bé gái được tạo hình phù hợp cho các bạn nam ",

                      Size = "M",

                      Price = 425000,

                      CategoryId = 5

                  },

                  new Product

                  {

                      Id = 13,

                      Title = "Bánh Tiramisu - Mix vị",

                      Description = "Bánh Tiramisu là 1 loại bánh có nguồn gốc từ ý, chiếc bánh này được làm thành 1 ổ bánh to và trang trí hấp dẫn thành tâm điểm của 1 bữa tiệc sinh nhật. Nhưng phần cốt bánh mềm xốp được thấm đẫm với hương cà phê và rượu rum, cùng với phần kem được phết ở giữa béo ngậy",

                      Size = "S",

                      Price = 365000,

                      CategoryId = 6

                  },

                  new Product

                  {

                      Id = 14,

                      Title = "Bánh Tiramisu - Vị cacao, Trang trí hoa quả",

                      Description = "Bánh Tiramisu là 1 loại bánh có nguồn gốc từ ý, chiếc bánh này được làm thành 1 ổ bánh to và trang trí hấp dẫn thành tâm điểm của 1 bữa tiệc sinh nhật. Nhưng phần cốt bánh mềm xốp được thấm đẫm với hương cà phê và rượu rum, cùng với phần kem được phết ở giữa béo ngậy",

                      Size = "S",

                      Price = 365000,

                      CategoryId = 6

                  },

                  new Product

                  {

                      Id = 15,

                      Title = "Bánh kem số & chữ - Tạo hình số 7",

                      Description = "Bánh kem số & chữ là bánh được cắt thành hình chữ hoặc số theo yêu cầu của khách hàng. Bánh được làm bằng kem whippng và có mứt và hoa quả làm nhân ở giữa",

                      Size = "S",

                      Price = 395000,

                      CategoryId = 7

                  },

                  new Product

                  {

                      Id = 16,

                      Title = "Bánh kem số & chữ - Cắt hình chữ A ",

                      Description = "Bánh kem số & chữ là bánh được cắt thành hình chữ hoặc số theo yêu cầu của khách hàng. Bánh được làm bằng kem whippng và có mứt và hoa quả làm nhân ở giữa",

                      Size = "M",

                      Price = 495000,

                      CategoryId = 7

                  },

                  new Product

                  {

                      Id = 17,

                      Title = "Bánh bông lan trứng muối ",

                      Description = "Bánh bông lan trứng muối là sự hòa quyện giữa vị mặn của trứng với vị ngọt dịu của vỏ bánh bông lan",

                      Size = "S",

                      Price = 295000,

                      CategoryId = 8

                  },

                  new Product

                  {

                      Id = 18,

                      Title = "Bánh tạo hình fondant - Bánh tạo hình cốc bia ",

                      Description = "Bánh tạo hình fondant được làm từ chất liệu fondant nặn thành những hình thù đáng yêu ngộ nghĩng",

                      Size = "S",

                      Price = 395000,

                      CategoryId = 9

                  },

                   new Product

                   {

                       Id = 19,

                       Title = "Bánh tạo hình fondant - Bánh trang trí tạo hình con thỏ ",

                       Description = "Bánh tạo hình fondant được làm từ chất liệu fondant nặn thành những hình thù đáng yêu ngộ nghĩng",

                       Size = "M",

                       Price = 495000,

                       CategoryId = 9

                   },

                   new Product

                   {

                       Id = 20,

                       Title = "Bánh Mousse - Vị sữa chua trang trí nho sữa ",

                       Description = "Bánh Mousse là 1 loại bánh lạnh trở nên thịnh hành trong những năm trở lại đây, chiếc bánh mousse có ưu điểm dễ làm, nhanh gọn và không cần sử dụng đến lò nướng. Đây được xem là lựa chọn hàng đầu cho những người mới làm bánh hay chưa thạo làm bánh sinh nhật. Bánh Mousse là họ hàng của dòng bánh lạnh nên vị man mát, béo ngậy của kem tươi hòa cùng với những hương bị đã tạo nen sự độc đáo",

                       Size = "M",

                       Price = 495000,

                       CategoryId = 10

                   },

                    new Product

                    {

                        Id = 21,

                        Title = "Bánh Mousse - Vị xoài trang trí bằng các miếng xoài ",

                        Description = "Bánh Mousse là 1 loại bánh lạnh trở nên thịnh hành trong những năm trở lại đây, chiếc bánh mousse có ưu điểm dễ làm, nhanh gọn và không cần sử dụng đến lò nướng. Đây được xem là lựa chọn hàng đầu cho những người mới làm bánh hay chưa thạo làm bánh sinh nhật. Bánh Mousse là họ hàng của dòng bánh lạnh nên vị man mát, béo ngậy của kem tươi hòa cùng với những hương bị đã tạo nen sự độc đáo",

                        Size = "L",

                        Price = 535000,

                        CategoryId = 10

                    }

                );
        }
    }
}
