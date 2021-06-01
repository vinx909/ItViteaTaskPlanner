using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using ItViteaTaskPlanner.Data.Services;
using ItViteaTaskPlanner.Data.Services.Infrastructure.InMemory;
using ItViteaTaskPlanner.Data.Services.Infrastructure.Sql;

namespace ItViteaTaskPlanner.Web
{
    public class ContainerConfig
    {
        private enum InfrastructurOrigin
        {
            inMemory,
            sql
        }
        private const InfrastructurOrigin origin = InfrastructurOrigin.inMemory;

        internal static void RegisterContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            switch (origin)
            {
                case InfrastructurOrigin.inMemory:
                    builder.RegisterType<InMemoryAppointmentData>().As<IAppointmentData>().SingleInstance();
                    builder.RegisterType<InMemoryCategoryData>().As<ICategoryData>().SingleInstance();
                    builder.RegisterType<InMemoryDocumentsData>().As<IDocumentsData>().SingleInstance();
                    builder.RegisterType<InMemoryNoteData>().As<INoteData>().SingleInstance();
                    builder.RegisterType<InMemoryTaskData>().As<ITaskData>().SingleInstance();
                    break;

                case InfrastructurOrigin.sql:
                    builder.RegisterType<SqlAppointmentData>().As<IAppointmentData>().InstancePerRequest();
                    builder.RegisterType<SqlCategoryData>().As<ICategoryData>().InstancePerRequest();
                    builder.RegisterType<SqlDocumentsData>().As<IDocumentsData>().InstancePerRequest();
                    builder.RegisterType<SqlNoteData>().As<INoteData>().InstancePerRequest();
                    builder.RegisterType<SqlTaskData>().As<ITaskData>().InstancePerRequest();
                    builder.RegisterType<TaskPlannerDbContext>().InstancePerRequest();
                    break;
            }

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}