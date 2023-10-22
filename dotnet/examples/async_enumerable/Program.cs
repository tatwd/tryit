var app = WebApplication.Create(args);

app.MapGet("/stream",  () => GenObjects());

app.UseStaticFiles();

app.Run();

static async IAsyncEnumerable<object> GenObjects()
{
    for (var i = 0; i < 10; i++)
    {
        yield return new { index = i, ts = DateTime.Now};
        await Task.Delay(1000);
    }
}