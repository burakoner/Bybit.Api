namespace Bybit.Api.Asset;

/// <summary>
/// Travel rule beneficiary information for withdrawals.
/// </summary>
public record BybitAssetWithdrawalBeneficiary
{
    /// <summary>
    /// Purpose of the beneficiary transaction.
    /// </summary>
    [JsonProperty("beneficiaryTransactionPurpose", NullValueHandling = NullValueHandling.Ignore)]
    public string? TransactionPurpose { get; set; }

    /// <summary>
    /// First name of the beneficiary company's representative.
    /// </summary>
    [JsonProperty("beneficiaryRepresentativeFirstName", NullValueHandling = NullValueHandling.Ignore)]
    public string? RepresentativeFirstName { get; set; }

    /// <summary>
    /// Last name of the beneficiary company's representative.
    /// </summary>
    [JsonProperty("beneficiaryRepresentativeLastName", NullValueHandling = NullValueHandling.Ignore)]
    public string? RepresentativeLastName { get; set; }

    /// <summary>
    /// Receiver exchange entity ID.
    /// </summary>
    [JsonProperty("vaspEntityId", NullValueHandling = NullValueHandling.Ignore)]
    public string? VaspEntityId { get; set; }

    /// <summary>
    /// Receiver exchange user KYC name.
    /// </summary>
    [JsonProperty("beneficiaryName", NullValueHandling = NullValueHandling.Ignore)]
    public string? Name { get; set; }

    /// <summary>
    /// Beneficiary legal type, such as individual or company.
    /// </summary>
    [JsonProperty("beneficiaryLegalType", NullValueHandling = NullValueHandling.Ignore)]
    public string? LegalType { get; set; }

    /// <summary>
    /// Beneficiary wallet type.
    /// </summary>
    [JsonProperty("beneficiaryWalletType", NullValueHandling = NullValueHandling.Ignore)]
    public string? WalletType { get; set; }

    /// <summary>
    /// Beneficiary unhosted wallet type.
    /// </summary>
    [JsonProperty("beneficiaryUnhostedWalletType", NullValueHandling = NullValueHandling.Ignore)]
    public string? UnhostedWalletType { get; set; }

    /// <summary>
    /// Beneficiary proof-of-identity document number.
    /// </summary>
    [JsonProperty("beneficiaryPoiNumber", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityNumber { get; set; }

    /// <summary>
    /// Beneficiary proof-of-identity document type.
    /// </summary>
    [JsonProperty("beneficiaryPoiType", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityType { get; set; }

    /// <summary>
    /// Beneficiary proof-of-identity issuing country.
    /// </summary>
    [JsonProperty("beneficiaryPoiIssuingCountry", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityIssuingCountry { get; set; }

    /// <summary>
    /// Beneficiary proof-of-identity expiry date.
    /// </summary>
    [JsonProperty("beneficiaryPoiExpiredDate", NullValueHandling = NullValueHandling.Ignore)]
    public string? ProofOfIdentityExpiredDate { get; set; }

    /// <summary>
    /// Beneficiary country.
    /// </summary>
    [JsonProperty("beneficiaryAddressCountry", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressCountry { get; set; }

    /// <summary>
    /// Beneficiary state.
    /// </summary>
    [JsonProperty("beneficiaryAddressState", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressState { get; set; }

    /// <summary>
    /// Beneficiary city.
    /// </summary>
    [JsonProperty("beneficiaryAddressCity", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressCity { get; set; }

    /// <summary>
    /// Beneficiary building address.
    /// </summary>
    [JsonProperty("beneficiaryAddressBuilding", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressBuilding { get; set; }

    /// <summary>
    /// Beneficiary street address.
    /// </summary>
    [JsonProperty("beneficiaryAddressStreet", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressStreet { get; set; }

    /// <summary>
    /// Beneficiary postal code.
    /// </summary>
    [JsonProperty("beneficiaryAddressPostalCode", NullValueHandling = NullValueHandling.Ignore)]
    public string? AddressPostalCode { get; set; }

    /// <summary>
    /// Beneficiary date of birth.
    /// </summary>
    [JsonProperty("beneficiaryDateOfBirth", NullValueHandling = NullValueHandling.Ignore)]
    public string? DateOfBirth { get; set; }

    /// <summary>
    /// Beneficiary place of birth.
    /// </summary>
    [JsonProperty("beneficiaryPlaceOfBirth", NullValueHandling = NullValueHandling.Ignore)]
    public string? PlaceOfBirth { get; set; }
}
