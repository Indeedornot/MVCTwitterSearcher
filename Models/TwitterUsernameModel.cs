using System.ComponentModel.DataAnnotations;

namespace MVCTwitterSearcher.Models;

public class TwitterUsernameModel
{
    [MaxLength(50), MinLength(4)] public string Username { get; set; } = string.Empty;
}