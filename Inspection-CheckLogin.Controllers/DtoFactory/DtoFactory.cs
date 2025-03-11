using System;
using InspectionCheckLogin.Messages;

namespace InspectionCheckLogin.Controllers.DtoFactory;
public class DtoFactory : IDtoFactory
{
    public object CreateDto(string dtoType, params object[] args)
    {
        if (args == null || args.Length == 0)
            throw new ArgumentException("Arguments cannot be null or empty.");

        switch (dtoType.ToLower())
        {
        
            case "logindto":
                if (args.Length < 2 || !(args[0] is string) || !(args[1] is string))
                    throw new ArgumentException("Invalid arguments for LoginRequest.");

                return new LoginRequest
                {
                    Email = (string)args[0],
                    Password = (string)args[1]
                };

            default:
                throw new ArgumentException($"Invalid DTO type: {dtoType}");
        }
    }

    public object UseDto(string dtoType, object dto)
    {
        if (dto == null)
            throw new ArgumentException("DTO object cannot be null.");

        switch (dtoType.ToLower())
        {
            case "logindto":
                return dto;
            default:
                throw new ArgumentException($"Invalid DTO type: {dtoType}");
        }
    }
}
