using ActorsApplication.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Microsoft.Maui.Controls;

namespace ActorsApplication.Pages;

public partial class ActorsPage : ContentPage
{

    public ActorsPage()
	{
		InitializeComponent();
        // ensure ActorsList is non-null for the XAML binding before OnAppearing
        ActorsList = new ObservableCollection<Actor>();
	}

    public ObservableCollection<Actor> ActorsList { get; set; }

    protected override void OnAppearing()
    {
        base.OnAppearing();
        ActorsList = new ObservableCollection<Actor>(InMemoryActors.GetActors());
        BindingContext = this;
    }

    private async void AddActorClicked(object sender, EventArgs e)
    {
        // Prompt for last name
        string? lastName = await DisplayPromptAsync("Lastname", "");
        if (lastName is null)
            return;

        // Prompt for first name
        string? firstName = await DisplayPromptAsync("Firstname", "");
        if (firstName is null)
            return;

        // Prompt for birth year and validate
        string? birthInput = await DisplayPromptAsync("BirthYear", "");
        if (birthInput is null)
            return;

        if (!int.TryParse(birthInput, out int birthYear))
        {
            await DisplayAlert("Invalid input", "Birth year must be a number.", "OK");
            return;
        }

        // Optional bio
        string? bio = await DisplayPromptAsync("Bio", "", initialValue: "n/a");
        if (bio is null)
            bio = "n/a";

        // Add the actor to the list (ObservableCollection will update the UI)
        ActorsList.Add(new Actor
        {
            LastName = lastName,
            FirstName = firstName,
            BirthYear = birthYear,
            ShortBio = bio
        });
    }

    private async void OnActorTapped(object sender, TappedEventArgs e)
    {
        if (sender is VisualElement ve && ve.BindingContext is Actor tappedActor)
        {
            // Navigate to the detail page and pass the actor instance
            await Navigation.PushAsync(new ActorDetailPage(tappedActor));
        }
    }
}