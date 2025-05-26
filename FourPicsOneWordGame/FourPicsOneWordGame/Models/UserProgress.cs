using System;

namespace FourPicsOneWordGame.Models
{
    public class UserProgress
    {
        public int UserProgressId { get; set; }
        public int UserId { get; set; }
        public int GameLevelId { get; set; }
        public bool IsCompleted { get; set; }
        public int Score { get; set; }
        public DateTime? CompletedDate { get; set; }
        public int HintsUsedInAttempt { get; set; }
    }
}