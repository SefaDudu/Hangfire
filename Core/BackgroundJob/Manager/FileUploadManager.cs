using Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BackgroundJob.Manager
{
    public class FileUploadManager
    {
        private readonly IProjectService projectService;
        public FileUploadManager(IProjectService projectService)
        {
            this.projectService = projectService ?? throw new ArgumentNullException(nameof(projectService));
        }
        public async Task Process()
        {
            await projectService.ProjectUpload();
        }
    }
}
