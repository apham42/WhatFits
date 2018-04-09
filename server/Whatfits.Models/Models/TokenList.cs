using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Whatfits.Models.Interfaces;

namespace Whatfits.Models.Models
{
    /// <summary>
    /// This model represents a list of tokens for each user
    /// and its corresponding salt.
    /// </summary>
    public class TokenList : ITokenList
    {
        [Key]
        public int TokenListID { get; set; }
        // Foreign Key to Credential Table
        [ForeignKey("Credential")]
        public int UserID { get; set; }

        // Stores the Token for user
        public string Token { get; set; }

        // Stores the Salt for the Token
        public string Salt { get; set; }

        // Navigational Property
        public virtual Credential Credential { get; set; }
    }
}
