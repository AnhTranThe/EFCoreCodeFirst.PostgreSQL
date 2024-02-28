// See https://aka.ms/new-console-template for more information
// Tạo thêm UserOrders => 1-n: 1 user có nhiều đơn hàng
// Tạo thêm Product => 1 table
// Tạo bảng UserOrderProduct (giống bảng product: quantity, note, discount) quan hệ 1-n với UserOrder 

using EFCoreCodeFirst.PostgreSQL.Data;

using (AppDbContext context = new())
{
    DummyData service = new(context);
    await service.SeedDataAsync();
}



