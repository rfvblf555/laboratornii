using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace HttpRequestsSending.Models;
public class ProductResponce
{
    [JsonPropertyName("product_id")]
    public int Id { get; set; }
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("description")]
    public string Description { get; set; }
    [JsonPropertyName("created_at")]
    public string? CreatedAt { get; set; }
    [JsonPropertyName("update_at")]
    public string? UpdateAt { get; set; }
}
