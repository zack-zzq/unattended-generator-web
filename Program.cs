using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using unattended_generator_web;
using unattended_generator_web.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// 注册配置服务（Scoped，每个用户会话一个实例）
builder.Services.AddScoped<ConfigurationService>();

await builder.Build().RunAsync();