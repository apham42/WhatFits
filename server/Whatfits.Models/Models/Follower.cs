namespace Whatfits.Models.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class Follower
    {
        // Foreign Key
        public int UserID { get; set; }
        public User User { get; set; }
        // Primary Key
        public int FollowerID { get; set; }

        public int FollowingPerson { get; set; }

    }
}
