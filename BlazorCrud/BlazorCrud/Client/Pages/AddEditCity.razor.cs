using BlazorCrud.Server.Models;
using Microsoft.AspNetCore.Components;
using System.Net.Http.Json;
using System.Xml.Serialization;

namespace BlazorCrud.Client.Pages
{
    public class AddEditCityBase : ComponentBase
    {
        [Inject]
        HttpClient Http { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        [Parameter]
        public int cityID { get; set; }

        protected string Title = "Add City";
        public City city = new();

        protected override async Task OnInitializedAsync()
        {
        }

        protected override async Task OnParametersSetAsync()
        {
            if (cityID != 0)
            {
                Title = "Edit";
                city = await Http.GetFromJsonAsync<City>("api/City/" + city);
            }
        }

        protected async Task SaveCity()
        {
            if (city.CityId != 0)
            {
                await Http.PutAsJsonAsync("api/City", city);
            }
            else
            {
                await Http.PostAsJsonAsync("api/City", city);
            }
            Cancel();
        }

        public void Cancel()
        {
            NavigationManager.NavigateTo("/home");
        }
    }
}
