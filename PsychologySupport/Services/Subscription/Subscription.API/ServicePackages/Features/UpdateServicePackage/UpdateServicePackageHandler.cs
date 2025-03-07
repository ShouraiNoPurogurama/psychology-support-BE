﻿using BuildingBlocks.CQRS;
using Mapster;
using Subscription.API.Data;
using Subscription.API.Exceptions;
using Subscription.API.ServicePackages.Dtos;

namespace Subscription.API.ServicePackages.Features.UpdateServicePackage;

public record UpdateServicePackageCommand(ServicePackageDto ServicePackage) : ICommand<UpdateServicePackageResult>;

public record UpdateServicePackageResult(bool IsSuccess);

public class UpdateServicePackageHandler : ICommandHandler<UpdateServicePackageCommand, UpdateServicePackageResult>
{
    private readonly SubscriptionDbContext _context;

    public UpdateServicePackageHandler(SubscriptionDbContext context)
    {
        _context = context;
    }

    public async Task<UpdateServicePackageResult> Handle(UpdateServicePackageCommand request, CancellationToken cancellationToken)
    {
        var existingPackage = await _context.ServicePackages.FindAsync(request.ServicePackage.Id, cancellationToken)
                              ?? throw new SubscriptionNotFoundException("Service Package", request.ServicePackage.Id);

        existingPackage = request.ServicePackage.Adapt(existingPackage);

        _context.Update(existingPackage);

        var result = await _context.SaveChangesAsync(cancellationToken) > 0;

        return new UpdateServicePackageResult(result);
    }
}