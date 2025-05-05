
namespace WebView2Test;

public sealed partial class MainPage : Page
{

    public MainPage()
    {
        this.InitializeComponent();

#if DESKTOP
        myWebView.NavigationCompleted += (_, _) => myWebView.InvalidateArrange();
#endif
    }

}
