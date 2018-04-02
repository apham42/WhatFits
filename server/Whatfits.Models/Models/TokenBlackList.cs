using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
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
        public string Token { get; set; }
        [ForeignKey("Credential")]
        public int UserID { get; set; }
        // Navigational Property to Credential
        public virtual Credential Credential { get; set; }
    }
}
