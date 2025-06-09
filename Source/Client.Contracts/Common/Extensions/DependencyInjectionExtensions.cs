using Erdmier.GigHero.Client.Contracts.Assignments.Mappers;
using Erdmier.GigHero.Client.Contracts.Gigs.Mappers;
using Erdmier.GigHero.Client.Contracts.Gigs.Models.DTOs;
using Erdmier.GigHero.Domain.AssignmentAggregate;
using Erdmier.GigHero.Domain.AssignmentAggregate.Entities;
using Erdmier.GigHero.Domain.Gig;
using Erdmier.GigHero.Domain.Gig.ValueObjects;

using Microsoft.Extensions.DependencyInjection;

namespace Erdmier.GigHero.Client.Contracts.Common.Extensions;

public static class DependencyInjectionExtensions
{
    public static IServiceCollection AddClientShared(this IServiceCollection services)
    {
        services.RegisterMappers();

        return services;
    }

    private static IServiceCollection RegisterMappers(this IServiceCollection services)
    {
        #region Assignment Mappers

        services.AddSingleton<IMapper<ActualPayment, ActualPaymentDto>, ActualPaymentMapper>();
        services.AddSingleton<IMapper<AssignmentId, AssignmentIdDto>, AssignmentIdMapper>();
        services.AddSingleton<IMapper<Assignment, AssignmentDto>, AssignmentMapper>();
        services.AddSingleton<IMapper<ExpectedPayment, ExpectedPaymentDto>, ExpectedPaymentMapper>();
        services.AddSingleton<IMapper<PaymentId, PaymentIdDto>, PaymentIdMapper>();
        services.AddSingleton<IMapper<Payment, PaymentDto>, PaymentMapper>();
        services.AddSingleton<IMapper<TimeEntryEnd, TimeEntryEndDto>, TimeEntryEndMapper>();
        services.AddSingleton<IMapper<TimeEntryId, TimeEntryIdDto>, TimeEntryIdMapper>();
        services.AddSingleton<IMapper<TimeEntry, TimeEntryDto>, TimeEntryMapper>();
        services.AddSingleton<IMapper<TimeEntryStart, TimeEntryStartDto>, TimeEntryStartMapper>();

        #endregion

        #region Gig Mappers

        services.AddSingleton<IMapper<GigId, GigIdDto>, GigIdMapper>();
        services.AddSingleton<IMapper<Gig, GigDto>, GigMapper>();

        #endregion

        return services;
    }
}
