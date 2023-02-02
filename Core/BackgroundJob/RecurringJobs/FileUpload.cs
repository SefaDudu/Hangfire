using Core.BackgroundJob.Manager;
using Hangfire;
using Hangfire.AspNetCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.BackgroundJob.RecurringJobs
{
    public static class RecurringJobs
    {
        // burada işlem yapılacak method çağrılacak
        [Obsolete]
        public static void FileUpload()
        {
            RecurringJob.RemoveIfExists(nameof(FileUploadManager)); // yinelnen bir işlemi kaldırır.
            RecurringJob.AddOrUpdate<FileUploadManager>(nameof(FileUploadManager), file => file.Process(), "34 13 * * * ", TimeZoneInfo.Local);
        }
    }
}
