using System.ComponentModel.DataAnnotations;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// Records a list of tokens being blocked
    /// </summary>
    public class TokenBlackList : ITokenBlackList
    {
        [Key]
        public int TokenBlackListID { get; set; }
        // Stores the token being blocked
        public string Tokens { get; set; }
    }
}
