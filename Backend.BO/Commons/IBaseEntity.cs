using System.ComponentModel.DataAnnotations;

namespace Backend.BO.Commons
{
    public interface IBaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
