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
            var newUri = "";
            var hashRouteAlreadyExists = urlSegments.Any(s => s.Contains(hashRoute));
            if (options.PreserveParams)
            {
                newUri = !hashRouteAlreadyExists ? $"{urlSegments[0]}#{hashRoute}?{urlSegments[1]}" : $"{urlSegments[0]}?{urlSegments[1]}";
            }
            else
            {
                newUri = !hashRouteAlreadyExists ? $"{urlSegments[0]}#{hashRoute}" : urlSegments[0];
            }

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
