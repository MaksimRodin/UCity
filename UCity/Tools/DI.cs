using UCity.Data.Repositories.EventsRepository;
using UCity.Logic;

namespace UCity.Tools
{
    public static class DI
    {
        public static void Init(WebApplicationBuilder builder)
        {
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            InitLogicDIs(builder);
            InitDataDIs(builder);
        }

        private static void InitLogicDIs(WebApplicationBuilder builder){
            builder.Services.AddScoped<IEventsLogic, EventsLogic>();
        }

        private static void InitDataDIs(WebApplicationBuilder builder){
            builder.Services.AddScoped<IEventsRepository, EventsRepository>();
        }
    }
}