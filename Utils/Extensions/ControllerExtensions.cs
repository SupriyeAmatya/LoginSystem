using Microsoft.AspNetCore.Mvc;

namespace Login.Utils.Extensions;

public static class ControllerExtensions
{
    public static ObjectResult InternalServerError(
        this ControllerBase controllerBase,
        string errorMessage
    )
    {
        var failedNotificationResult = new ObjectResult(errorMessage);
        failedNotificationResult.StatusCode = StatusCodes.Status500InternalServerError;
        return failedNotificationResult;
    }

    public static ObjectResult OnlyOnSwagger(
        this ControllerBase controller,
        IConfiguration configuration
    )
    {
        var isDevelopment = configuration.GetSection("EnableSwagger").Value == "true";
        if (!isDevelopment)
        {
            var teaPotResponse = new ObjectResult("You cannot access this endpoint!");
            teaPotResponse.StatusCode = StatusCodes.Status418ImATeapot;

            return teaPotResponse;
        }

        return null;
    }
}
