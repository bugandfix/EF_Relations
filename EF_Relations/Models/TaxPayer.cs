
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

public class TaxPayer
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
    public int Id { get; set; }
    public string? FullName { get; set; }
    public TaxRecord Taxrecord { get; set; }
}

public class TaxRecord
{

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int Id { get; set; }
    public string? TaxCode { get; set; }

    public decimal TotalTaxPaid { get; set; }

    //[ForeignKey("TaxPayer")]
    public int TaxPayerID { get; set; }

    [JsonIgnore]
    public TaxPayer? Taxpayer { get; set; }
}