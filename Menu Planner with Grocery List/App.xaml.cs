using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Microsoft.Live;
using System.Threading.Tasks;
using Windows.UI.ApplicationSettings;

// The Blank Application template is documented at http://go.microsoft.com/fwlink/?LinkId=234227

namespace Menu_Planner_with_Grocery_List
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        /// <summary>
        /// Initializes the singleton application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;

        }
            Rect _windowBounds;
            double _settingsWidth = 346;
            Popup _settingsPopup;

        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected async override void OnLaunched(LaunchActivatedEventArgs args)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active
            if (rootFrame == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                rootFrame = new Frame();
                Menu_Planner_with_Grocery_List.Common.SuspensionManager.RegisterFrame(rootFrame, "appFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    //TODO: Load state from previously suspended application
                    await Menu_Planner_with_Grocery_List.Common.SuspensionManager.RestoreAsync();
                }

                // Place the frame in the current Window
                Window.Current.Content = rootFrame;
            }

            if (rootFrame.Content == null)
            {
                // When the navigation stack isn't restored navigate to the first page,
                // configuring the new page by passing required information as a navigation
                // parameter
                if (!rootFrame.Navigate(typeof(MainPage), args.Arguments))
                {
                    throw new Exception("Failed to create initial page");
                }
            }
            // Ensure the current window is active
            Window.Current.Activate();

            // After the call to Window.Current.Activate() in the OnLaunched event handler,
            //  add this code to initialize the Flyout window size and register the event 
            //  handler methods.
            _windowBounds = Window.Current.Bounds;
            Window.Current.SizeChanged += OnWindowSizeChanged;
            SettingsPane.GetForCurrentView().CommandsRequested += AppCommandsRequested;
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            //TODO: Save application state and stop any background activity
            await Menu_Planner_with_Grocery_List.Common.SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        /// <summary>
        /// Invoked when the application is activated to display search results.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        async protected override void OnSearchActivated(Windows.ApplicationModel.Activation.SearchActivatedEventArgs args)
        {
            // TODO: Register the Windows.ApplicationModel.Search.SearchPane.GetForCurrentView().QuerySubmitted
            // event in OnWindowCreated to speed up searches once the application is already running

            // If the Window isn't already using Frame navigation, insert our own Frame
            var previousContent = Window.Current.Content;
            var frame = previousContent as Frame;

            // If the app does not contain a top-level frame, it is possible that this 
            // is the initial launch of the app. Typically this method and OnLaunched 
            // in App.xaml.cs can call a common method.
            if (frame == null)
            {
                // Create a Frame to act as the navigation context and associate it with
                // a SuspensionManager key
                frame = new Frame();
                Menu_Planner_with_Grocery_List.Common.SuspensionManager.RegisterFrame(frame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await Menu_Planner_with_Grocery_List.Common.SuspensionManager.RestoreAsync();
                    }
                    catch (Menu_Planner_with_Grocery_List.Common.SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }
            }

            frame.Navigate(typeof(SearchResultsPage), args.QueryText);
            Window.Current.Content = frame;

            // Ensure the current window is active
            Window.Current.Activate();
        }

        public void NotifyUser(string message)
        {
            this.statusText.Text = message;
        }

        public static async Task updateUserName(TextBlock userName, TextBlock statusText, Boolean signIn)
        {
            try
            {
                // Open Live Connect SDK client.
                LiveAuthClient LCAuth = new LiveAuthClient();
                LiveLoginResult LCLoginResult = await LCAuth.InitializeAsync();
                try
                {
                    LiveLoginResult loginResult = null;
                    if (signIn)
                    {
                        // Sign in to the user's Microsoft account with the requires scope.
                        //  
                        //  This call will display the Microsoft account sign-in screen if 
                        //   the user is not already signed in to their Microsoft account 
                        //   through Windows 8.
                        // 
                        //  This call will also display the consent dialog, if the user has 
                        //   has not already given consent to this app to access the data 
                        //   described by the scope.
                        // 
                        //  Change the parameter of LoginAsync to include the scopes 
                        //   required by your app.
                        loginResult = await LCAuth.LoginAsync(new string[] { "wl.skydrive", "wl.basic" });
                    }
                    else
                    {
                        // If we don't want the user to sign in, continue with the current sign-in state.
                        loginResult = LCLoginResult;
                    }
                    if (loginResult.Status == LiveConnectSessionStatus.Connected)
                    {
                        // create a client session to get the profile data.
                        LiveConnectClient connect = new LiveConnectClient(LCAuth.Session);

                        // Get the profile info of the user
                        LiveOperationResult operationResult = await connect.GetAsync("me");
                        dynamic result = operationResult.Result;
                        if (result != null)
                        {
                            //Update the text of the object passed in to the method.
                            userName.Text = string.Join(" ", "Hello", result.name, "!");
                        }
                        else
                        {
                            // Handle the case where the user name was not returned.
                            userName.Text = ("Hello User!");
                        }
                    }
                    else
                    {
                        // The user hasn't signed in so display this text in place of his or her name.
                        userName.Text = "You're not signed in.";
                    }
                }

                catch (LiveAuthException ex)
                {
                    statusText.Text = ex.Message;
                }
            }
            catch (LiveAuthException ex)
            {
                statusText.Text = ex.Message;
            }
        }

        void AppCommandsRequested(SettingsPane sender, SettingsPaneCommandsRequestedEventArgs args)
        {
            // if your app already has some settings defined, add these blocks of code to your existing handler in the order you want them to appear in the Settings pane.
            
            // Account settings command
            SettingsCommand cmd = new SettingsCommand("account", "Account", (x) =>
                {
                    _settingsPopup = new Popup();
                    _settingsPopup.Closed += OnPopupClosed;
                    Window.Current.Activated += OnWindowActivated;
                    _settingsPopup.IsLightDismissEnabled = true;
                    _settingsPopup.Width = _settingsWidth;
                    _settingsPopup.Height = _windowBounds.Height;

                    Account mypane = new Account();
                    mypane.Width = _settingsWidth;
                    mypane.Height = _windowBounds.Height;
                    
                    _settingsPopup.Child = mypane;
                    _settingsPopup.SetValue(Canvas.LeftProperty, _windowBounds.Width - _settingsWidth);
                    _settingsPopup.SetValue(Canvas.TopProperty, 0);
                    _settingsPopup.IsOpen = true;
                });
            args.Request.ApplicationCommands.Add(cmd);

            // Privacy settings command
            cmd = new SettingsCommand("privacy", "Privacy", (x) =>
                {
                    _settingsPopup=new Popup();
                    _settingsPopup.Closed+=OnPopupClosed;
                    Window.Current.Activated+=OnWindowActivated;
                    _settingsPopup.IsLightDismissEnabled=true;
                    _settingsPopup.Width=_settingsWidth;
                    _settingsPopup.Height=_windowBounds.Height;

                    Privacy mypane=new Privacy();
                    mypane.Width=_settingsWidth;
                    mypane.Height = _windowBounds.Height;

                    _settingsPopup.Child=mypane;
                    _settingsPopup.SetValue(Canvas.LeftProperty, _windowBounds.Width - _settingsWidth);
                    _settingsPopup.SetValue(Canvas.TopProperty, 0);
                    _settingsPopup.IsOpen = true;
                });
            args.Request.ApplicationCommands.Add(cmd);
        }

        // Catch resize events to update the Flyout window size
        void OnWindowSizeChanged(object sender, Windows.UI.Core.WindowSizeChangedEventArgs e)
        {
            _windowBounds = Window.Current.Bounds;
        }

        // Handle Flyout window activation
        private void OnWindowActivated(object sender, Windows.UI.Core.WindowActivatedEventArgs e)
        {
            if (e.WindowActivationState == Windows.UI.Core.CoreWindowActivationState.Deactivated)
            {
                _settingsPopup.IsOpen = false;
            }
        }

        // Handle Flyout window closing
        private void OnPopupClosed(object sender, object e)
        {
            Window.Current.Activated -= OnWindowActivated;
        }
    }
}
