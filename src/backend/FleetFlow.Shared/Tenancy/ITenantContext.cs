namespace FleetFlow.Shared.Tenancy;

/// <summary>Provides access to the current company/tenant for the active request.</summary>
public interface ITenantContext
{
    Guid CompanyId { get; }
}
