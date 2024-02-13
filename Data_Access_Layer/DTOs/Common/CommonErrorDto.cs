using System.Text.Json;

namespace Data_Access_Layer.DTOs.Common
{
    public class CommonErrorDto
    {
        public int Code { get; set; }
        public string? Message { get; set; }

        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
