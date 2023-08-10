using System;
using System.IO;

namespace RepositoryGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            var dbContext = @"ClubMembershipContext";
            var modelsPath = @"C:\Users\Acer\Desktop\Projects\ASP.NET\ClubMemebership\BusinessObject\Models"; // TODO: Update with your Models directory path
            var repoInterfacePath = @"C:\Users\Acer\Desktop\Projects\ASP.NET\ClubMemebership\BusinessObject\IRepositories"; // TODO: Update where you want the interfaces
            var repoImplementationPath = @"C:\Users\Acer\Desktop\Projects\ASP.NET\ClubMemebership\BusinessObject\Repositories"; // TODO: Update where you want the implementations

            foreach (var file in Directory.GetFiles(modelsPath, "*.cs"))
            {
                var modelName = Path.GetFileNameWithoutExtension(file);
                GenerateRepositoryInterface(modelName, repoInterfacePath);
                GenerateRepositoryImplementation(modelName, repoImplementationPath, dbContext);
            }
        }

        private static void GenerateRepositoryInterface(string modelName, string outputPath)
        {
            var content = $@"using System.Collections.Generic;
using ClubMemebership_QuocHB_WebRazorPage.Repo.Models;

 namespace ClubMemebership_QuocHB_WebRazorPage.Repo.IRepositories
{{
    public interface I{modelName}Repository
    {{
        IEnumerable<{modelName}> GetAll();
        {modelName} GetById(int id);
        void Add({modelName} entity);
        void Update({modelName} entity);
        void Delete(int id);
    }}
}}";

            File.WriteAllText(Path.Combine(outputPath, $"I{modelName}Repository.cs"), content);
        }

        private static void GenerateRepositoryImplementation(string modelName, string outputPath, string dbContext)
        {
            var content = $@"using System;
using System.Collections.Generic;
using System.Linq;
using ClubMemebership_QuocHB_WebRazorPage.Repo.Models;
using  ClubMemebership_QuocHB_WebRazorPage.Repo.IRepositories;

namespace ClubMemebership_QuocHB_WebRazorPage.Repo.Repositories
{{
    public class {modelName}Repository : I{modelName}Repository
    {{
    private {dbContext} context;
 
            public {modelName}Repository({dbContext} context)
            {{
                this.context = context;
            }}
        // TODO: Implement your DbContext and actual logic here
public void Add({modelName} entity)
        {{
            throw new NotImplementedException();
        }}

        public void Delete(int id)
        {{
            throw new NotImplementedException();
        }}

        public IEnumerable<{modelName}> GetAll()
        {{
            throw new NotImplementedException();
        }}

        public {modelName} GetById(int id)
        {{
            throw new NotImplementedException();
        }}

        public void Update({modelName} entity)
        {{
            throw new NotImplementedException();
        }}
    }}
}}";

            File.WriteAllText(Path.Combine(outputPath, $"{modelName}Repository.cs"), content);
        }
    }
}
