using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class TodoItemService
{
    private readonly HttpClient _httpClient;

    public TodoItemService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<ItemData[]> GetToDoItems()
    {
        return await _httpClient.GetFromJsonAsync<ItemData[]>("api/ToDoItem");
    }

    public async Task<ItemData> GetToDoItem(int id)
    {
        return await _httpClient.GetFromJsonAsync<ItemData>($"api/ToDoItem/{id}");
    }

    public async Task<int> CreateToDoItem(ItemData todoItem)
    {
        var response = await _httpClient.PostAsJsonAsync("api/ToDoItem", todoItem);
        response.EnsureSuccessStatusCode();
        
        return await response.Content.ReadFromJsonAsync<int>();
    }

    public async Task UpdateToDoItem(int id, ItemData todoItem)
    {
        var response = await _httpClient.PutAsJsonAsync($"api/ToDoItem/{id}", todoItem);
        response.EnsureSuccessStatusCode();
    }

    public async Task DeleteToDoItem(int id)
    {
        var response = await _httpClient.DeleteAsync($"api/ToDoItem/{id}");
        response.EnsureSuccessStatusCode();
    }
}
