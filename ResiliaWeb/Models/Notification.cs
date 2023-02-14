using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResiliaWeb.Models
{
    [Table("notifications")]
    public class Notification
	{
        public enum EnumPriority { Normal = 0, High };

        [Column("notification_id")]
        public Guid Id { get; set; }

        [Column("notification_date")]
        public DateTime Date { get; set; }

        [Column("priority")]
        public EnumPriority Priority { get; set; }

        [Column("text")]
        public string? Text { get; set; }
    }
}

