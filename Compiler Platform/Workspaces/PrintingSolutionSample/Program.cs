using System.IO;
using System.Linq;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.MSBuild;
using static System.Console;

namespace PrintingSolutionSample
{
   internal static class Program
   {
      private static readonly Solution Solution =
         MSBuildWorkspace.Create().OpenSolutionAsync(@"..\..\..\Playground\Playground.sln").Result;      

      private static void Main()
      {
         // ������ �������
         WriteLine(Path.GetFileName(Solution.FilePath));

         // ���� ������������
         var dependencyGraph = Solution.GetProjectDependencyGraph();
         var sortedProjects = dependencyGraph.GetTopologicallySortedProjects();

         // ��� �������, ���������, � ������
         foreach (var project in sortedProjects.Select(projectId => Solution.GetProject(projectId)))
         {
            WriteLine("> {0}", project.Name);
            WriteLine("  > References");
            foreach (var projectReference in project.ProjectReferences)
            {
               WriteLine("     - {0}", Solution.GetProject(projectReference.ProjectId).Name);
            }

            WriteLine("  > Documents");
            foreach (var document in project.Documents)
            {
               WriteLine("   - {0}", document.Name);
            }
         }
      }
   }
}