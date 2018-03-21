using System.ComponentModel.DataAnnotations;

namespace Whatfits.Models.Models
{
    public class TokenBlackList
    {
        [Key]
        public int TokenBlackListID { get; set; }
        public string Tokens { get; set; }
    }
}
