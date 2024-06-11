using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("certificate")]
    public class Certificate : IBaseEntity
    {
        [Column("certificate_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("certificate_name")]
        [MaxLength(300)]
        public required string CertificateName { get; set; }

        [Column("issued_date")]
        public DateTime IssuedDate { get; set; }

        [Column("expired_date")]
        public DateTime? ExpiredDate { get; set; }

        [Column("certificate_image", TypeName = "text")]
        public string? CertificateImage { get; set; }

        [Column("doctor_id")]
        public Guid DoctorId { get; set; }

        public User Doctor { get; set; } = null!;
    }
}
