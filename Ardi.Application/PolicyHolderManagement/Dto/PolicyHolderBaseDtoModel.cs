using Ardi.Domain.PolicyHolderManagement;

namespace Ardi.Application.PolicyHolderManagement.Dto;

public class PolicyHolderBaseDtoModel
{
    public Guid Id { get; set; }
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string PersonalNumber { get; set; }
    public required DateTime DateOfBirth { get; set; }
    public required string ContactNumber { get; set; }
    public string? EmailAddress { get; set; }

    public static PolicyHolderBaseDtoModel MapToDto(PolicyHolder policyHolder)
    {
        return PolicyHolderDtoModel.MapToDto(policyHolder, false);
    }
}