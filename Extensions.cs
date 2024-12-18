using Microsoft.AspNetCore.Components;

namespace HashRoutingDemo
{
    public static class Extensions
    {

#nullable enable
        public static void NavigateToHashRoute(this NavigationManager navigationManager, string hashRoute, NavigationManagerOptions? options = null)
        {
            options ??= new();

            var urlSegments = navigationManager.Uri.Split('?');
            var newUri = options.PreserveParams ?
                $"{urlSegments[0]}#{hashRoute}?{urlSegments[1]}"
                : $"{urlSegments[0]}#{hashRoute}";
            navigationManager.NavigateTo(newUri, options.ForceReload, options.Refresh);
        }
#nullable disable
    }
    public class NavigationManagerOptions
    {
        public bool ForceReload { get; set; }
        public bool Refresh { get; set; }
        public bool PreserveParams { get; set; } = true;
    }
}
