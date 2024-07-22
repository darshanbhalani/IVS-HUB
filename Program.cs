using IVS_HUB.Hubs;
namespace IVS_HUB
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddSignalR();
            builder.Services.AddCors(
            option =>
            {
                option.AddPolicy(
                "AllowRequests", builder => builder.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader().AllowCredentials());
            });

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }


            app.UseRouting();

            app.UseCors("AllowRequests");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapHub<LiveElectionHub>("/liveElectionHub");

            app.MapControllers();

            app.Run();
        }
    }
}
