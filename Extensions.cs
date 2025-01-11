using Microsoft.AspNetCore.Components;

namespace HashRoutingDemo
{
#nullable enable
    public static class Extensions
    {
        public static void NavigateToHashRoute(this NavigationManager navigationManager, string hashRoute, NavigationManagerOptions? options = null)
        {
            options ??= new();

            var uri = new Uri(navigationManager.Uri);
            var hashRouteAlreadyExists = !string.IsNullOrEmpty(uri.Fragment);

            navigationManager.NavigateTo(hashRouteAlreadyExists ? uri.AbsoluteUri : $"{uri.AbsoluteUri}#{hashRoute}", options.ForceReload, options.Refresh);
        }
    }
#nullable disable
    public class NavigationManagerOptions
    {
        public bool ForceReload { get; set; }
        public bool Refresh { get; set; }
    }
}
