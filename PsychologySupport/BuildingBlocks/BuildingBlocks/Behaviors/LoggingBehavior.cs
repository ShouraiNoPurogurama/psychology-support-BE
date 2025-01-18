﻿using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace BuildingBlocks.Behaviors;

public class LoggingBehavior<TRequest, TResponse>(ILogger logger)
    : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        logger.LogInformation("[START] Handle request={Request} - Response={Response}",
            typeof(TRequest).Name, typeof(TResponse).Name);

        var timer = new Stopwatch();

        timer.Start();
        var response = await next();
        timer.Stop();

        var timeTaken = timer.Elapsed;
        if (timeTaken.Seconds > 3)
        {
            logger.LogWarning("[PERFORMANCE] The request {Request} took {TimeTaken} seconds.",
                typeof(TRequest).Name, timeTaken.Seconds);
        }

        logger.LogInformation("[END] Handled {Request} with {Response}",
            typeof(TRequest).Name, typeof(TResponse).Name);

        return response;
    }
}