using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VuSaniClientApi.Models.DBModels
{
    /// <summary>
    /// Tracks which termination reminder emails have been sent (90, 60, 30, 7 days before and on the day).
    /// </summary>
    public class TerminationNotificationLog
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>Employee (user) whose termination date triggered the notification.</summary>
        public int UserId { get; set; }

        /// <summary>Days before termination: 90, 60, 30, 7, or 0 (on the day).</summary>
        public int IntervalDays { get; set; }

        public DateTime SentAt { get; set; } = DateTime.UtcNow;
    }
}
