using Backend.BO.Commons;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Backend.BO.Entities
{
    [Table("clinic_feedback")]
    public class ClinicFeedback : IBaseEntity
    {
        [Column("clinic_fb_id")]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Column("clinic_id")]
        public int ClinicId { get; set; }

        [Column("customer_id")]
        public Guid CustomerId { get; set; }

        /// <summary>
        /// Feedback rating from 1 to 5 (mapping with 1 to 5 stars)
        /// </summary>
        [Column("rating")]
        public short Rating { get; set; }
        
        [Column("fb_description")]
        [MaxLength(300)]
        public string? FeedbackDescription { get; set; }

        [Column("fb_date")]
        [DataType(DataType.DateTime)]
        public DateTime FeedbackDate { get; set; }

        //public User Customer { get; set; } = null!;

        //public Clinic Clinic { get; set; } = null!;
    }
}
