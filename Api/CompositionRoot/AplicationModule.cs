﻿using Application.Coach.Commands;
using Application.Coach.Events;
using Application.IdentityAndAccess.Services;
using Application.Notification;
using Application.Queries.Training.GetTrainingsForUser;
using ApplicationQueries.IdentityAndAccess;
using ApplicationQueries.Runners;
using ApplicationQueries.SharedViewModels;
using ApplicationQueries.Training;
using Autofac;
using Persistence.DapperHandlers.QueryHandlers;
using PlainCQRS.Core.Commands;
using PlainCQRS.Core.Events;
using PlainCQRS.Core.Queries;
using System.Collections.Generic;
using AuthenticationService = Application.IdentityAndAccess.Services.AuthenticationService;

namespace TraingAppBackEnd.CompositionRoot
{
    public class AplicationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            RegisterCommands(builder);
            RegisterQueries(builder);
            RegisterServices(builder);
            RegisterEvents(builder);
        }

        private static void RegisterCommands(ContainerBuilder builder)
        {
            builder.RegisterType<CreateRunnerCommandHandler>()
                .As<ICommandHandlerAsync<CreateRunnerCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateCoachCommandHandler>()
                .As<ICommandHandlerAsync<CreateCoachCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<CreateTrainingCommandHandler>()
                .As<ICommandHandlerAsync<CreateTrainingCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<UpdateRunnerCommandHandler>()
                .As<ICommandHandlerAsync<UpdateRunnerCommand>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<DeleteRunnerCommandHandler>()
                .As<ICommandHandlerAsync<DeleteRunnerCommand>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterQueries(ContainerBuilder builder)
        {
            builder.RegisterType<FindApplicationUserQueryHandler>()
                .As<IQueryHandlerAsync<FindApplicationUserQuery, ApplicationUserViewModel>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetRunnersQueryHandler>()
                .As<IQueryHandlerAsync<GetRunnersQuery, IEnumerable<RunnerViewModel>>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetTrainingsQueryHandler>()
                .As<IQueryHandlerAsync<GetTrainingsQuery, IEnumerable<TrainingViewModel>>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<GetCoachesQueryHandler>()
                .As<IQueryHandlerAsync<GetCoachesQuery, List<CoachWithEmailViewModel>>>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<AuthenticationService>()
                .As<IAuthenticationService<LoginRequest>>()
                .InstancePerLifetimeScope();

            builder.RegisterType<PasswordService>()
                .As<IPasswordService>()
                .InstancePerLifetimeScope();
        }

        private static void RegisterEvents(ContainerBuilder builder)
        {
            builder.RegisterType<TrainingCreatedEventHandler>()
                .As<IEventHandlerAsync<TrainingCreated>>()
                .InstancePerLifetimeScope();
        }
    }
}
