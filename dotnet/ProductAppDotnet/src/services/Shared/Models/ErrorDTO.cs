using System;
using System.Collections.Generic;
using System.Text;

namespace Shared.Models
{
    public class ErrorDTO
    {
        public ErrorDTO()
        {
            Errors = new List<string>();
        }

        public List<string> Errors { get; set; }

        public int Status { get; set; }

        public bool IsShow { get; set; }
    }
}
