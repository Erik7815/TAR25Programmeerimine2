using System;
using System.Collections.Generic;
using System.Text;

namespace Kindergarden.Core.Dto
{
    public class FileToApiDto
    {
        public Guid Id { get; set; }
        public string? ExistingFilePath { get; set; }
        public Guid? KindergardenId { get; set; }
    }
}
