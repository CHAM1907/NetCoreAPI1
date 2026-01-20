Cấu trúc thư mục dự án ASP.NET Core MVC
1. Tổng quan

Dự án ASP.NET Core MVC được tổ chức theo mô hình MVC (Model – View – Controller) nhằm tách biệt rõ ràng giữa:

Model: xử lý dữ liệu và logic nghiệp vụ

View: giao diện người dùng

Controller: điều phối luồng xử lý giữa Model và View

Cấu trúc thư mục tiêu chuẩn giúp dự án dễ bảo trì, mở rộng và làm việc nhóm.

2. Cấu trúc thư mục tổng quát
MyMvcApp/
│
├── Controllers/
│   └── HomeController.cs
│
├── Models/
│   └── ErrorViewModel.cs
│
├── Views/
│   ├── Home/
│   │   └── Index.cshtml
│   ├── Shared/
│   │   ├── _Layout.cshtml
│   │   └── Error.cshtml
│   ├── _ViewImports.cshtml
│   └── _ViewStart.cshtml
│
├── wwwroot/
│   ├── css/
│   ├── js/
│   └── images/
│
├── appsettings.json
├── Program.cs
├── MyMvcApp.csproj
└── README.md

3. Giải thích chi tiết từng thư mục
Controllers

Chứa các Controller xử lý request từ người dùng

Mỗi controller thường tương ứng với một nhóm chức năng

Ví dụ:

public class HomeController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

Models

Chứa các class biểu diễn dữ liệu

Bao gồm:

Entity

ViewModel

DTO

Ví dụ:

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
}

Views

Chứa các file giao diện .cshtml

Mỗi thư mục con tương ứng với tên Controller

Views/Home

Chứa các View cho HomeController

Views/Shared

Chứa các View dùng chung:

_Layout.cshtml: layout chung của website

Error.cshtml: trang hiển thị lỗi

_ViewImports.cshtml

Khai báo namespace và Tag Helper dùng chung cho các View

_ViewStart.cshtml

Xác định layout mặc định cho toàn bộ View

wwwroot

Chứa các tài nguyên tĩnh của ứng dụng:

CSS

JavaScript

Hình ảnh

Các file trong thư mục này có thể được truy cập trực tiếp từ trình duyệt

4. Các file cấu hình quan trọng
Program.cs

Điểm khởi động của ứng dụng

Cấu hình middleware, routing và dependency injection

appsettings.json

Chứa các cấu hình của ứng dụng:

Chuỗi kết nối cơ sở dữ liệu

Logging

Cấu hình môi trường

*.csproj

File cấu hình project

Quản lý:

Các gói NuGet

Target Framework

Cấu hình build

5. Mô hình hoạt động MVC
User Request
     ↓
Controller
     ↓
   Model
     ↓
   View
     ↓
User Response
------------------------------------------------
Định tuyến (Routing) trong ASP.NET MVC
1. Khái niệm định tuyến (Routing)

Định tuyến (Routing) là cơ chế ánh xạ URL do người dùng gửi lên tới:

Controller

Action

Tham số (parameters)

Routing quyết định request sẽ được xử lý bởi action nào trong ứng dụng ASP.NET MVC.

Ví dụ:

https://localhost:5001/Home/Index/5


URL trên được ánh xạ tới:

Controller: HomeController

Action: Index
---------------------------------------------------
Namespace trong C#
1. Khái niệm namespace

Namespace trong C# là một cơ chế dùng để tổ chức và nhóm các class, interface, struct, enum có liên quan với nhau.
Nó giúp:

Tránh trùng tên giữa các class

Quản lý mã nguồn rõ ràng, có cấu trúc

Dễ bảo trì và mở rộng chương trình

Ví dụ:

System.Console.WriteLine("Hello World");


Trong đó:

System là namespace

Console là class trong namespace System

2. Mục đích sử dụng namespace

Namespace được sử dụng để:

Phân chia các chức năng trong chương trình

Giảm xung đột tên khi dự án lớn

Tăng tính đọc hiểu của mã nguồn

Tái sử dụng mã dễ dàng

3. Cách khai báo namespace
3.1 Khai báo namespace đơn giản
namespace MyApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello");
        }
    }
}

3.2 Namespace lồng nhau
namespace MyApplication.Data
{
    class Database
    {
    }
}


Namespace MyApplication.Data nằm bên trong MyApplication.

4. Sử dụng namespace
4.1 Sử dụng từ khóa using
using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("Hello World");
    }
}


using giúp không cần ghi đầy đủ tên namespace khi sử dụng class.

4.2 Sử dụng đầy đủ namespace
System.Console.WriteLine("Hello World");


Cách này thường dùng khi:

Có xung đột tên class

Muốn rõ ràng namespace đang sử dụng

4.3 Alias namespace
using IO = System.IO;

IO.File.ReadAllText("test.txt");


Alias giúp rút gọn tên namespace dài.

5. Namespace và Assembly

Namespace: cách tổ chức logic mã nguồn

Assembly: file đã biên dịch (.dll, .exe)

Một assembly có thể chứa nhiều namespace
Một namespace cũng có thể trải trên nhiều assembly khác nhau

6. Namespace trong dự án ASP.NET MVC

Ví dụ cấu trúc namespace:

MyMvcApp
 ├── Controllers
 │    └── HomeController.cs   → namespace MyMvcApp.Controllers
 ├── Models
 │    └── Product.cs          → namespace MyMvcApp.Models
 └── Services
      └── ProductService.cs   → namespace MyMvcApp.Services


Ví dụ controller:

using MyMvcApp.Models;

namespace MyMvcApp.Controllers
{
    public class HomeController : Controller
    {
    }
}

Tham số: id = 5

2. Vai trò của Routing

Routing trong ASP.NET MVC có các vai trò chính:

Điều hướng request đến đúng controller/action

Tạo URL thân thiện với người dùng (SEO friendly)

Tách biệt logic xử lý khỏi cấu trúc URL vật lý

Hỗ trợ xây dựng RESTful API

3. Các loại định tuyến trong ASP.NET MVC
3.1 Convention-based Routing (Định tuyến theo quy ước)

Đây là cách định tuyến truyền thống, sử dụng mẫu URL cố định.

Cấu hình trong Program.cs:

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


Giải thích:

controller=Home: Controller mặc định

action=Index: Action mặc định

id?: Tham số tùy chọn

Ví dụ URL hợp lệ:

/Home/Index
/Product/Details/10

3.2 Attribute Routing (Định tuyến bằng thuộc tính)

Định tuyến được khai báo trực tiếp trên Controller hoặc Action bằng attribute.

Ví dụ:

[Route("products")]
public class ProductController : Controller
{
    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("details/{id}")]
    public IActionResult Details(int id)
    {
        return View();
    }
}


URL tương ứng:

/products
/products/details/5


Ưu điểm:

Linh hoạt

Dễ xây dựng RESTful API

Dễ kiểm soát URL

4. Routing trong ASP.NET Core MVC
4.1 Kích hoạt Routing

Trong Program.cs:

app.UseRouting();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});


Hoặc đơn giản hơn:

app.MapControllers();

4.2 Routing với Area

Area dùng để chia nhỏ ứng dụng MVC lớn thành các module.

Ví dụ cấu trúc:

Areas/
 └── Admin/
     ├── Controllers/
     │    └── DashboardController.cs
     └── Views/


Controller trong Area:

[Area("Admin")]
public class DashboardController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}


URL:

/Admin/Dashboard/Index

5. Tham số trong Routing
5.1 Tham số bắt buộc
[Route("product/details/{id}")]
public IActionResult Details(int id)

5.2 Tham số tùy chọn
[Route("blog/{id?}")]
public IActionResult Index(int? id)

6. Ràng buộc tham số (Route Constraints)

Ràng buộc giúp kiểm soát kiểu dữ liệu của tham số trong URL.

Ví dụ:

app.MapControllerRoute(
    name: "product",
    pattern: "product/{id:int}");


Hoặc:

[Route("order/{id:int}")]


Một số constraint phổ biến:

int

bool

datetime

guid

min, max, length
