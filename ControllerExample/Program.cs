using ControllerExample;

var builder = WebApplication.CreateBuilder(args);
//builder.Services.AddTransient<HomeController>();  // this general way of adding controller.
                                                  // As we have many controllers(eg100) its not good to add each controller.
builder.Services.AddControllers();  // which will add controllers. .net core automatically detects controllers present and
                                    // it wil collect controllers and adds all of them.

var app = builder.Build();

/*
app.UseRouting();

//  Generally we add endpoints 
app.UseEndpoints(endpoint =>
{
 //   endpoint.Map("url1", async Context =>
  //  {
   //     await Context.Response.WriteAsync("endpoint adding for controller");  // but adding for each controller is not good approach.
                                                                                // to over come this  use the below code mapcontrollers.
                                                                                // all controllers added at a time .map controller enables the routing for each action method.


    endpoint.MapControllers();
    
});
*/

// The above commented code can be directly called by using the below code (Map Controller) which will automatically call app.UseRouting and MapControllers

app.MapControllers();

//app.MapGet("/", () => "Hello World!");

app.Run();
