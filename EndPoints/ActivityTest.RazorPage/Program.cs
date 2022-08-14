using ActivityTest.RazorPage.Services.ActivityType;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddTransient<IActivityTypeService, ActivityTypeService>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient<IActivityTypeService, ActivityTypeService>();

var app = builder.Build();
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}
//app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();
app.MapRazorPages();
app.Run();
