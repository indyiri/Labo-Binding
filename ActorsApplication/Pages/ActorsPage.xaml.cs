using ActorsApplication.Data;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace ActorsApplication.Pages;

public partial class ActorsPage : ContentPage
{

    public ActorsPage()
	{
		InitializeComponent();
	}

    public ObservableCollection<Actor> ActorsList { get; set; }

    protected override void OnAppearing()
    {
        ActorsList = new ObservableCollection<Actor>(InMemoryActors.GetActors());
        BindingContext = this;
    }

    private async void AddActorClicked(object sender, EventArgs e)
    {
        string lastName = await DisplayPromptAsync("Lastname", "");
        string firstName = await DisplayPromptAsync("Firstname", "");
        int birthYear = int.Parse(await DisplayPromptAsync("BirthYear", ""));
        string bio = "n/a";

        // Add the actor to the list
        ActorsList.Add(new Actor 
        { 
            LastName = lastName,
            FirstName = firstName,
            BirthYear = birthYear,
            ShortBio = bio
        });
    }
}