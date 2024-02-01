using Ardi.Application.PolicyManagement.Dto;
using Ardi.Domain.PolicyHolderManagement;

namespace Ardi.Application.PolicyHolderManagement.Dto;

public class PolicyHolderDtoModel : PolicyHolderBaseDtoModel
{
    public IEnumerable<PolicyDtoModel>? Policies { get; set; }

    public static PolicyHolderDtoModel MapToDto(PolicyHolder policyHolder, bool includeNavProperties = true)
    {
        var model = new PolicyHolderDtoModel()
        {
            Id = policyHolder.Id,
            FirstName = policyHolder.FirstName,
            LastName = policyHolder.LastName,
            PersonalNumber = policyHolder.PersonalNumber,
            DateOfBirth = policyHolder.DateOfBirth,
            ContactNumber = policyHolder.ContactNumber,
            EmailAddress = policyHolder.EmailAddress,
        };

        if (includeNavProperties)
        {
            model.Policies = policyHolder.Policies != null && policyHolder.Policies.Count != 0 ? policyHolder.Policies.Select(x => PolicyDtoModel.MapToDto(x)).ToList() : default;
        }

        return model;
    }
}