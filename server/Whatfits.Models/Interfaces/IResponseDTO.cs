using System.Collections.Generic;

namespace Whatfits.Models.Interfaces
{
    public interface IResponseDTO
    {
        List<string> Messages { get; set; }
        bool IsSuccessful { get; set; }
    }
}
