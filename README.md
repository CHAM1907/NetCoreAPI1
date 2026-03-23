# Bài Thực Hành Số 3 - ASP.NET MVC

## 1. Cấu trúc thư mục

- Controllers: xử lý request
- Models: dữ liệu
- Views: giao diện
- wwwroot: file tĩnh
- Program.cs: cấu hình app

---

## 2. Routing

```csharp
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");