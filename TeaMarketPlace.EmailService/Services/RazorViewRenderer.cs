using MySandBoxApp.Core.Interfaces;
using MySandBoxApp.Core.Models;
using RazorLight;

namespace TeaMarketPlace.EmailService.Services
{
    public class RazorViewRenderer : IRazorViewRenderer
    {
        public readonly RazorLightEngine _engine;

        public RazorViewRenderer()
        {

            string projectPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory).Parent.FullName;
            string assemblyLocation = Path.GetDirectoryName(typeof(RazorViewRenderer).Assembly.Location);
            string viewsPath = Path.Combine(assemblyLocation, "EmailFileTemplates");

            _engine = new RazorLightEngineBuilder()
                .UseFileSystemProject(viewsPath)
                .SetOperatingAssembly(typeof(RazorViewRenderer).Assembly)
                .UseMemoryCachingProvider()
                .Build();
        }

        public async Task<Stream> RenderViewToStringAsync(List<ChildNotificationResponse> childrenModel)
        {
            string renderedString = await _engine.CompileRenderAsync("DBPage.cshtml", childrenModel);

            var memoryStream = new MemoryStream();
            using (var writer = new StreamWriter(memoryStream, leaveOpen: true))
            {
                await writer.WriteAsync(renderedString);
            }

            memoryStream.Position = 0;
            return memoryStream;
        }
    }

}
