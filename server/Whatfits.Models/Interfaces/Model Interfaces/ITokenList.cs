namespace Whatfits.Models.Interfaces
{
    public interface ITokenList
    {
        string Token { get; set; }
        string Salt { get; set; }
    }
}
