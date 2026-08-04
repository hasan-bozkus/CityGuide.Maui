using System;
using System.Collections.Generic;
using System.Text;

namespace CityGuide.Maui.Services
{
    public static class CurrentSession
    {
        public static int UserId { get; set; }
        public static string FullName { get; set; } = string.Empty;
        public static string Email { get; set; } = string.Empty;

        public static void Clear()
        {
            UserId = 0;
            FullName = string.Empty;
            Email = string.Empty;
        }
    }
}
