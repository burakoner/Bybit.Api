namespace Bybit.Api.Asset;

/// <summary>
/// Travel rule beneficiary information for withdrawals.
/// </summary>
public record BybitAssetWithdrawalBeneficiary
{
    [JsonProperty("beneficiaryTransactionPurpose", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionPurpose { get; set; }

    [JsonProperty("beneficiaryRepresentativeFirstName", NullValueHandling = NullValueHandling.Ignore)]
    public string? RepresentativeFirstName { get; set; }

    [JsonProperty("beneficiaryRepresentativeLastName", NullValueHandling = NullValueHandling.Ignore)]
    public string? RepresentativeLastName { get; set; }

    [JsonProperty("vaspEntityId", NullValueHandling = NullValueHandling.Ignore)]
    public string? VaspEntityId { get; set; }

    [JsonProperty("beneficiaryName", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    [JsonProperty("beneficiaryLegalType", NullValueHandling = NullValueHandling.Ignore)]
    public string? LegalType { get; set; }

    [JsonProperty("beneficiaryWalletType", NullValueHandling = NullValueHandling.Ignore)]
    public string? WalletType { get; set; }

    [JsonProperty("beneficiaryUnhostedWalletType", NullValueHandling = NullValueHandling.Ignore)]
    public string? UnhostedWalletType { get; set; }

    [JsonProperty("beneficiaryPoiNumber", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityNumber { get; set; }

    [JsonProperty("beneficiaryPoiType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityType { get; set; }

    [JsonProperty("beneficiaryPoiIssuingCountry", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityIssuingCountry { get; set; }

    [JsonProperty("beneficiaryPoiExpiredDate", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityExpiredDate { get; set; }

    [JsonProperty("beneficiaryAddressCountry", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressCountry { get; set; }

    [JsonProperty("beneficiaryAddressState", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressState { get; set; }

    [JsonProperty("beneficiaryAddressCity", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressCity { get; set; }

    [JsonProperty("beneficiaryAddressBuilding", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressBuilding { get; set; }

    [JsonProperty("beneficiaryAddressStreet", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressStreet { get; set; }

    [JsonProperty("beneficiaryAddressPostalCode", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressPostalCode { get; set; }

    [JsonProperty("beneficiaryDateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
    public string? DateOfBirth { get; set; }

    [JsonProperty("beneficiaryPlaceOfBirth", NullValueHandling = NullValueHandling.Ignore)]
    public string? PlaceOfBirth { get; set; }
}
