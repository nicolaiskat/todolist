// TodoListService.cs
using System.Net.Http.Json;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

// Tjek i Program.cs hvad dit namespace bør hedde
namespace todolist_blazor_app.Data;

public class ToDoListService
{
    private readonly HttpClient http;
    private readonly IConfiguration configuration;
    private readonly string baseAPI = "";

    public ToDoListService(HttpClient http, IConfiguration configuration)
    {
        this.http = http;
        this.configuration = configuration;
        // Denne konfiguration læses fra filen "appsettings.json". Se mere i opgave 5.
        this.baseAPI = configuration["base_api"];
    }

    public async Task<ToDoListTask[]?> GetTodoListTasks()
    {
        string url = $"{baseAPI}tasks/";
        return await http.GetFromJsonAsync<ToDoListTask[]>(url);
    }

    public async Task<ToDoListTask[]?> GetTodo(string id)
    {
        string url = $"{baseAPI}tasks/{id}";
        return await http.GetFromJsonAsync<ToDoListTask[]>(url);
    }

    public async Task PostTodoListTasks(ToDoListTask newTask)
    {
        string url = $"{baseAPI}tasks/";
        await http.PostAsJsonAsync<ToDoListTask>(url, newTask);
    }

    public async Task PutTodoListTasks(ToDoListTask newTask)
    {
        string url = $"{baseAPI}tasks/{newTask.id}";
        await http.PutAsJsonAsync<ToDoListTask>(url, newTask);
    }

    public async Task DeleteTodoListTasks(ToDoListTask newTask)
    {
        string url = $"{baseAPI}tasks/{newTask.id}";
        await http.DeleteAsync(url);
    }
}