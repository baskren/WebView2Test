
namespace WebView2Test;

public sealed partial class MainPage : Page
{
    string html = string.Empty;
    
    public MainPage()
    {
        this.InitializeComponent();

#if DESKTOP
        myWebView.NavigationCompleted += (_, _) => myWebView.InvalidateArrange();
#endif

        if (GetType().Assembly.GetManifestResourceStream("WebView2Test.Resources.html5-test-page.html") is not
            Stream stream)
            return;

        using (var reader = new StreamReader(stream))
        {
            html = reader.ReadToEnd();
        }
        
        
        Loaded += async (_, _) =>
        {
            await myWebView.EnsureCoreWebView2Async();
            myWebView.NavigateToString(html);
        };
    }

}
